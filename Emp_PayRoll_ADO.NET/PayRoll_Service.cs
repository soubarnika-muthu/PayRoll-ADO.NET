using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Emp_PayRoll_ADO.NET
{
    class PayRoll_Service
    {
        /// <summary>
        ///UC1- Creating the connection to database
        /// </summary>
        public static string connectionString = "Data Source=(localdb)\\ProjectsV13;Initial Catalog=Emp_Payroll_Database";
        //creating the object for sql connection class
        SqlConnection sqlConnection = new SqlConnection(connectionString);
       
        //UC2-Retrieve all data
        public void GetAllData()
        {
            //opening the sql connection
            this.sqlConnection.Open();
            //create the query to display data
            string query = @"select * from dbo.PayRollTable";
            //create object for employee detail class
            EmployeeDetails employee = new EmployeeDetails();
            try
            {
                //create the sql command object nd pass the querry and connection
                SqlCommand command = new SqlCommand(query, sqlConnection);
                //create data reader 
                SqlDataReader reader = command.ExecuteReader();
                //if it has data
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        //store each data in the employee details properties 
                        employee.employeeId = Convert.ToInt32(reader["id"]);
                        employee.employeeName = reader["name"].ToString();
                        employee.gender = reader["gender"].ToString();
                        employee.startDate = reader.GetDateTime(2);
                        employee.phoneNumber = Convert.ToDouble(reader["phoneNumber"]);
                        employee.address = reader.GetString(5);
                        employee.department = reader.GetString(6);
                        //display the result
                        Console.WriteLine("{0} {1} {2} {3} {4} {5} {6} ", employee.employeeId, employee.employeeName, employee.gender, employee.startDate, employee.phoneNumber, employee.address, employee.department);
                    }
                }
                else
                {
                    Console.WriteLine("No data vailable");
                }
                reader.Close();
            }
            //if any exception occurs catch and display exception message
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            //finally close the connection
            finally
            {
                this.sqlConnection.Close();
            }
        }
    }
}
