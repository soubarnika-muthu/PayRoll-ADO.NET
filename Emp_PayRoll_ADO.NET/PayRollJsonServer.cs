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

        //writing into the server 
        public void WriteIntoJsonServer(EmployeeSalaryDetails employee)
        {
            RestRequest request = new RestRequest("/employees", Method.POST);
            //creating the json object
            JsonObject json = new JsonObject();
            //adding the data to json object
            json.Add("id", employee.id);
            json.Add("name", employee.name);
            json.Add("salary", employee.salary);
            request.AddParameter("application/json", json, ParameterType.RequestBody);
            IRestResponse response = client.Execute(request);
            var res = JsonConvert.DeserializeObject<EmployeeSalaryDetails>(response.Content);
            Console.WriteLine("" + res.id + "Added");
        }

        //Adding multiple data to the server
        public void AddingMultipleContactToServer(List<EmployeeSalaryDetails> employees)
        {
            foreach (var employee in employees)
            {
                WriteIntoJsonServer(employee);
            }
        }

        //Update the record using put method
        public bool UpdateValueInJsonServer(EmployeeSalaryDetails employee)
        {
            int result = 0;
            RestRequest request = new RestRequest("/employees/" + employee.id, Method.PUT);
            JsonObject json = new JsonObject();
            json.Add("id", employee.id);
            json.Add("name", employee.name);
            json.Add("salary", employee.salary);
            request.AddParameter("application/json", json, ParameterType.RequestBody);
            IRestResponse response = client.Execute(request);
            var res = JsonConvert.DeserializeObject<EmployeeSalaryDetails>(response.Content);
            return response.IsSuccessful;
        }
    }
}
