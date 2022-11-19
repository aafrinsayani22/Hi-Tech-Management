using HiTechManagement.BLL;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HiTechManagement.DAL
{
    internal class EmployeeDB
    {

        public static void SaveRecord(Employee emp)
        {
            // insert into Employees VALUES(6555, 'Mary', 'Green', 'Programmer Analyst')
            //1. connect DB
            SqlConnection conn = UtilityDB.ConnectDB();

            //2. create and customize an SqlCommand object
            SqlCommand cmdInsert = new SqlCommand();

            cmdInsert.CommandText = "INSERT INTO Employees (EmployeeId,FirstName,LastName,Phone,Email,JobId,StatusId)" +
                                    " VALUES (@EmployeeId,@FirstName,@LastName,@Phone,@Email,@JobId,@StatusId)";

            cmdInsert.Parameters.AddWithValue("@EmployeeId", emp.EmployeeId);
            cmdInsert.Parameters.AddWithValue("@FirstName", emp.FirstName);
            cmdInsert.Parameters.AddWithValue("@LastName", emp.LastName);
            cmdInsert.Parameters.AddWithValue("@Phone", emp.Phone);
            cmdInsert.Parameters.AddWithValue("@Email", emp.Email);
            cmdInsert.Parameters.AddWithValue("@JobId", emp.JobId);
            cmdInsert.Parameters.AddWithValue("@StatusId", emp.StatusId);

            cmdInsert.Connection = conn;
            // 3. perform the INSERT command
            cmdInsert.ExecuteNonQuery();

            //4. close the DB
            conn.Close();
            conn.Dispose();


        }

        public static bool IsDuplicateId(int eId)
        {
            Employee emp = SearchRecord(eId);

            if (emp != null)
            {
                return false;
            }
            return true;
        }

        public static Employee SearchRecord(int eId)
        {
            Employee emp = new Employee();

            SqlConnection conn = UtilityDB.ConnectDB();

            SqlCommand cmdSearchById = new SqlCommand();
            cmdSearchById.CommandText = "SELECT * from Employees WHERE EmployeeId =@EmployeeId";
            cmdSearchById.Connection = conn;
            cmdSearchById.Parameters.AddWithValue("@EmployeeId", eId);

            SqlDataReader reader = cmdSearchById.ExecuteReader();


            if (reader.Read())
            {
                emp.EmployeeId = Convert.ToInt32(reader["EmployeeId"]);
                emp.FirstName = reader["FirstName"].ToString();
                emp.LastName = reader["LastName"].ToString();
                emp.Phone = reader["Phone"].ToString();
                emp.Email = reader["Email"].ToString();
                emp.JobId = Convert.ToInt32(reader["JobId"]);
                emp.StatusId = Convert.ToInt32(reader["StatusId"]);
          

            }

            conn.Close();
            conn.Dispose();
            return emp;
        }


        public static void UpdateRecord(Employee emp)
        {
            // insert into Employees VALUES(6555, 'Mary', 'Green', 'Programmer Analyst')
            //1. connect DB
            SqlConnection conn = UtilityDB.ConnectDB();

            //2. create and customize an SqlCommand object
            SqlCommand cmdUpdate = new SqlCommand();

            cmdUpdate.CommandText = "UPDATE Employees " + "set EmployeeId = @EmployeeId, FirstName = @FirstName," +
                                                                        " LastName = @LastName,Phone = @Phone,JobId = @JobId,StatusId = @StatusId WHERE EmployeeId =@EmployeeId";

            cmdUpdate.Parameters.AddWithValue("@EmployeeId", emp.EmployeeId);
            cmdUpdate.Parameters.AddWithValue("@FirstName", emp.FirstName);
            cmdUpdate.Parameters.AddWithValue("@LastName", emp.LastName);
            cmdUpdate.Parameters.AddWithValue("@Phone", emp.Phone);
            cmdUpdate.Parameters.AddWithValue("@JobId", emp.JobId);
            cmdUpdate.Parameters.AddWithValue("@StatusId", emp.StatusId);

            cmdUpdate.Connection = conn;
            // 3. perform the INSERT command
            cmdUpdate.ExecuteNonQuery();

            //4. close the DB
            conn.Close();
            conn.Dispose();

        }

        public static List<Employee> GetAllRecords()
        {
            List<Employee> listE = new List<Employee>();

            SqlConnection conn = UtilityDB.ConnectDB();

            SqlCommand cmdSelect = new SqlCommand("SELECT * FROM Employees ", conn);

            // perform theselect quer
            SqlDataReader reader = cmdSelect.ExecuteReader();

            Employee emp;
            ///Employee emp = new Employee();


            while (reader.Read())
            {
                emp = new Employee();
                emp.EmployeeId = Convert.ToInt32(reader["EmployeeId"]);
                emp.FirstName = reader["FirstName"].ToString();
                emp.LastName = reader["LastName"].ToString();
                emp.Phone = reader["Phone"].ToString();
                emp.Email = reader["Email"].ToString();
                emp.JobId = Convert.ToInt32(reader["JobId"]);
                emp.StatusId = Convert.ToInt32(reader["StatusId"]);
      
                listE.Add(emp);
            }

            conn.Close();
            conn.Dispose();



            return listE;

        }

        public static void DeleteRecord(int empId)
        {
            SqlConnection conn = UtilityDB.ConnectDB();
            SqlCommand cmdDelete = new SqlCommand();

            Employee emp = new Employee();



            cmdDelete.CommandText = "DELETE FROM Employees WHERE EmployeeId=@EmployeeId";


            cmdDelete.Connection = conn;
            cmdDelete.Parameters.AddWithValue("@EmployeeId", empId);

            cmdDelete.ExecuteNonQuery();

            conn.Close();
            conn.Dispose();

        }

    }
}
