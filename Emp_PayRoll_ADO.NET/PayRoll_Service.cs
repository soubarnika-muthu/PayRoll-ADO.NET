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
        public void UpdateSalary()
        {
            //assigning the details which has to be updated
            
            EmployeeDetails employee = new EmployeeDetails();
            employee.employeeName = "Terissa";
            employee.employeeId = 7;
            employee.basicPay = 3000000;
            using (sqlConnection)
                try
                {
                    this.sqlConnection.Open();
                    //passing query in terms of stored procedure
                    SqlCommand sqlCommand = new SqlCommand("SpUpdateSalaryPayrollDetail", sqlConnection);
                    //passing command type as stored procedure
                    sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
                   
                    //adding the parameter to the strored procedure
                    sqlCommand.Parameters.AddWithValue("@empid", employee.employeeId);
                    sqlCommand.Parameters.AddWithValue("@empname", employee.employeeName);
                    sqlCommand.Parameters.AddWithValue("@BasicPay", employee.basicPay);
                    //checking the result 
                    int result = sqlCommand.ExecuteNonQuery();
                    if (result > 0)
                        Console.WriteLine("Salary is updated");
                    else
                        Console.WriteLine("Updation failed");
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
                finally
                {
                    this.sqlConnection.Close();
                }
        }
    }
}
