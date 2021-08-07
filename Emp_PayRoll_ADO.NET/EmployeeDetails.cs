﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Emp_PayRoll_ADO.NET
{
  public  class EmployeeDetails
    {
        public int employeeId { get; set; }
        public string employeeName { get; set; }
        public DateTime startDate { get; set; }
        public string gender { get; set; }
        public double phoneNumber { get; set; }
        public string address { get; set; }
        public string department { get; set; }
        public double basicPay { get; set; }
        public double taxablePay { get; set; }

    }
}