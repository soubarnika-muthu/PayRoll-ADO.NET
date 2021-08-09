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
                int expected = 8;
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
                int expected = 6;
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
            /* //implementing the insert ino table method
             [TestMethod]
             public void InsertIntoTableTest()
             {
                 int expected = 1;
                 //Assign
                 EmployeeDetails employee = new EmployeeDetails();
                 employee.employeeName = "joyal";
                 employee.address = "madurai";
                 employee.gender = "male";
                 employee.department = "HR";
                 employee.startDate = new DateTime(2021, 07, 27);
                 employee.basicPay = 110000;
                 employee.deduction = 2040;
                 employee.taxablePay = 1456;
                 employee.tax = 2345;
                 employee.phoneNumber = 9839883929;
                 int actual = payroll.InsertIntotable(employee);
                 //Assert
                 Assert.AreEqual(expected, actual);
             }*/

            //UC8-Insert into PayrollTable
            [TestMethod]
            public void InsertIntoPayrollTable()
            {
                int expected = 1;
                //Assign
                EmployeeDetails employee = new EmployeeDetails();
                employee.basicPay = 18000;
                employee.employeeId = 11;
                TransactionManagement transaction = new TransactionManagement();
                int actual = transaction.AddingRecord(employee);
                Assert.AreEqual(expected, actual);

            }
        //UC9-Insert into Tables with transaction
        [TestMethod]
        public void InsertIntoTables()
        {
            int expected = 1;
            //Assign
            EmployeeDetails employee = new EmployeeDetails { employeeId = 13, employeeName = "Tim", companyId = 1, departmentId = 3, phoneNumber = 8655535615, address = "MGRNagar", city = "madurai", state = "TamilNadu", startDate = "2017-12-05", gender = "M", basicPay = 34000 };
            TransactionManagement transaction = new TransactionManagement();
            int actual = transaction.AddingRecord(employee);
            Assert.AreEqual(expected, actual);

        }

        [TestMethod]
        //UC12- Cascading delete
        public void DeleteRecord()
        {
            int expected = 1;
            int actual = new TransactionManagement().DeleteUsingCasadeDelete(4);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        //UC12- Cascading delete
        public void AddindIsActiveField()
        {
            int expected = 1;
            int actual = new TransactionManagement().AddIsActiveColumn();
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void RetrivingDataBasedOnIsActiveField()
        {
            int expected = 8;
            List<EmployeeDetails> actual = new TransactionManagement().RetriveDataForAudit("Retrivealldata");
            Assert.AreEqual(expected, actual.Count);
        }
    }
}

