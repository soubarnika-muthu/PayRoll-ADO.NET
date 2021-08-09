using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using java.sql;


namespace Emp_PayRoll_ADO.NET
{
    public class PayRoll_Service
    {
        List<EmployeeDetails> employeeList = new List<EmployeeDetails>();
        /// <summary>
        ///UC1- Creating the connection to database
        /// </summary>
        public static string connectionString = "Data Source=(localdb)\\ProjectsV13;Initial Catalog=Emp_Payroll_Database";
        //creating the object for sql connection class
        SqlConnection sqlConnection = new SqlConnection(connectionString);

        //UC2-Retrieve all data
        public List<EmployeeDetails> GetAllData()
        {
            //opening the sql connection
            sqlConnection.Open();
            //create the query to display data
            string query = @"select * from dbo.PayRollTable";
            //create object for employee detail class
            EmployeeDetails employee = new EmployeeDetails();
            try
            {
                ///create the sql command object nd pass the querry and connection
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
                        employeeList.Add(employee);
                    }
                    reader.Close();
                    return employeeList;
                }
                else
                {
                    reader.Close();
                    return employeeList;
                }

            }
            //if any exception occurs catch and display exception message
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            //finally close the connection
            finally
            {
                sqlConnection.Close();
            }
        }
        public int UpdateSalary()
        {
            //assigning the details which has to be updated
            EmployeeDetails employee = new EmployeeDetails();
            employee.employeeName = "Terissa";
            employee.employeeId = 7;
            employee.basicPay = 3000600;
            using (sqlConnection)
                try
                {
                    //passing query in terms of stored procedure
                    SqlCommand sqlCommand = new SqlCommand("SpUpdateSalaryPayrollDetail", sqlConnection);
                    //passing command type as stored procedure
                    sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
                    sqlConnection.Open();
                    //adding the parameter to the strored procedure
                    sqlCommand.Parameters.AddWithValue("@empid", employee.employeeId);
                    sqlCommand.Parameters.AddWithValue("@empname", employee.employeeName);
                    sqlCommand.Parameters.AddWithValue("@basicPay", employee.basicPay);
                    //checking the result 
                    int result = sqlCommand.ExecuteNonQuery();

                    if (result == 1)
                        Console.WriteLine("salary updated");
                    else
                        Console.WriteLine("salary not updated");

                    return result;
                }
                catch (Exception e)
                {
                    throw new Exception(e.Message);
                }
                finally
                {
                    sqlConnection.Close();
                }
        }
        public List<EmployeeDetails> DisplayDataBasedOnDate(DateTime startdate, DateTime dateTime)
        {
            EmployeeDetails employee = new EmployeeDetails();


            using (sqlConnection)
                try
                {
                    //passing query in terms of stored procedure
                    SqlCommand sqlCommand = new SqlCommand("RetrieveDate", sqlConnection);
                    //passing command type as stored procedure
                    sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
                    sqlConnection.Open();
                    //adding the parameter to the strored procedure
                    sqlCommand.Parameters.AddWithValue("@startDate", startdate);
                    sqlCommand.Parameters.AddWithValue("@endDate", dateTime);
                    SqlDataReader reader = sqlCommand.ExecuteReader();
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
                            employeeList.Add(employee);
                        }
                        reader.Close();
                        return employeeList;
                    }
                    else
                    {
                        reader.Close();
                        return employeeList;
                    }

                }
                //if any exception occurs catch and display exception message
                catch (Exception e)
                {
                    throw new Exception(e.Message);
                }
                //finally close the connection
                finally
                {
                    sqlConnection.Close();
                }
        }
        public string AggregareteFunction(int choice)
        {
            switch (choice)
            {
                case 1:
                    string countQuery = "select Count(id) as CountOfEmployee from PayRollTable group by gender";
                    string count = new SqlAggregate(sqlConnection).AgregateFunctionCalculate(countQuery);
                    return count;
                case 2:
                    string query = "select Max(BasicPay) as MaximumSalary from PayRollTable group by gender";
                    string maxSalary = new SqlAggregate(sqlConnection).AgregateFunctionCalculate(query);
                    return maxSalary;
                case 3:
                    string minQuery = "select Min(BasicPay) as MinimumSalary from PayRollTable group by gender";
                    string minSalary = new SqlAggregate(sqlConnection).AgregateFunctionCalculate(minQuery);
                    return minSalary;
                case 4:
                    string avgQuery = "select Avg(BasicPay) as MaximumSalary from PayRollTable group by gender";
                    string avgSalary = new SqlAggregate(sqlConnection).AgregateFunctionCalculate(avgQuery);
                    return avgSalary;
                case 5:
                    string sumQuery = "select Sum(BasicPay) as MinimumSalary from PayRollTable group by gender";
                    string totalSalary = new SqlAggregate(sqlConnection).AgregateFunctionCalculate(sumQuery);
                    return totalSalary;
                default:
                    return ("invalidOption");
            }
        }

        public int InsertIntotable(EmployeeDetails employee)
        {
            using (sqlConnection)
                try
                {
                    //passing query in terms of stored procedure
                    SqlCommand sqlCommand = new SqlCommand("InsertintoTable", sqlConnection);
                    //passing command type as stored procedure
                    sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
                    sqlConnection.Open();
                    //adding the parameter to the strored procedure
                    sqlCommand.Parameters.AddWithValue("@name", employee.employeeName);
                    sqlCommand.Parameters.AddWithValue("@startDate", employee.startDate);
                    sqlCommand.Parameters.AddWithValue("@gender", employee.gender);
                    sqlCommand.Parameters.AddWithValue("@phonenumber", employee.phoneNumber);
                    sqlCommand.Parameters.AddWithValue("@address", employee.address);
                    sqlCommand.Parameters.AddWithValue("@department", employee.department);
                    sqlCommand.Parameters.AddWithValue("@Deduction", employee.deduction);
                    sqlCommand.Parameters.AddWithValue("@Tax", employee.tax);
                    sqlCommand.Parameters.AddWithValue("@TaxablePay", employee.taxablePay);
                    sqlCommand.Parameters.AddWithValue("@basicPay", employee.basicPay);
                    //checking the result 
                    int result = sqlCommand.ExecuteNonQuery();
                    if (result > 0)
                        return 1;
                    else
                        return 0;
                }
                catch (Exception e)
                {
                    throw new Exception(e.Message);
                }
                finally
                {
                    sqlConnection.Close();
                }
        }



    }
}




