using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Emp_PayRoll_ADO.NET
{
    public class DepartmentDetails
    {
        public int departmentId;
        public string department;
        public DepartmentDetails(int departmentId, string department)
        {
            this.departmentId = departmentId;
            this.department = department;
        }

    }
}
