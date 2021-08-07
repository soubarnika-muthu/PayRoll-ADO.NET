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
        //Checking the result of the retrival based on date 
        [TestMethod]
        public void DisplayDataBasedOnData()
        {
            int expected = 3;
            DateTime startdate = new DateTime(2020, 07, 20);
            DateTime dateTime = new DateTime(2021, 07, 30);
            List<EmployeeDetails> list = payroll.DisplayDataBasedOnDate(startdate, dateTime);
            int actual = list.Count();
            Assert.AreEqual(expected, actual);

        }
        //implementing the parameterized test cases
        [DataRow(1, "2 3 2 ")] //Count of employee test
        [DataRow(2, "3000600 ")] //maximum salary test
        [DataRow(3, "100000 12000 78000")] // minimum salary test
        [DataRow(4, "100000 1009200 78000 ")] // Avg salary test
        [DataRow(5, "100000 3027600 78000 ")] //sum of salary test
        [DataTestMethod]
        public void AggregatefunctionTest(int choice, string expected)
        {

            //Act
            string actual = payroll.AggregareteFunction(choice);
            //Assert
            Assert.AreEqual(expected, actual);
        }
    }
}
