using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Emp_PayRoll_ADO.NET
{
    public class PayRollJsonServer
    {
        RestClient client;
        public PayRollJsonServer()
        {
            client = new RestClient("http://localhost:3000");
        }
        IRestResponse GetAllEmployee()
        {
            RestRequest request = new RestRequest("/employees");
            IRestResponse response = client.Execute(request);
            return response;
        }
        public List<EmployeeSalaryDetails> ReadFromServer()
        {
            IRestResponse response = GetAllEmployee();
            var res = JsonConvert.DeserializeObject<List<EmployeeSalaryDetails>>(response.Content);
            return res;
        }
    }
}
