using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Emp_PayRoll_ADO.NET;
using System.Collections.Generic;
using System.Linq;

namespace PayRollTest
{
    [TestClass]
    public class PayrollTestClass
    {
        PayRoll_Service payroll;
        [TestInitialize]
        public void setup()
        {
            payroll = new PayRoll_Service();
        }
        //checking whether all data is retrived
        [TestMethod]
        public void RetriveAllDetails()
        {
            //Assign
            int expected = 7;
            //Act
            List<EmployeeDetails> list = payroll.GetAllData();
            int actual = list.Count();
            //Assert
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        //checking whether the update is passed or not
        public void UpdateSalaryTest()
        {
            //Assign
            int expected = 1;
            //Act
            int actual = payroll.UpdateSalary();
            //Assert
            Assert.AreEqual(expected, actual);
        }
    }
}
