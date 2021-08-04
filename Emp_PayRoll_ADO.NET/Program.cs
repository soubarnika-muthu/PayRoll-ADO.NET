using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Emp_PayRoll_ADO.NET
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Implementaion of PayRoll service using ADO.NET");
            PayRoll_Service payRoll = new PayRoll_Service();
            payRoll.GetAllData();
        }
    }
}
