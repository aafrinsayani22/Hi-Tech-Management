using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HiTechManagement.BLL;
using System.Data.SqlClient;
using HiTechManagement.DAL;


namespace HiTechManagement.DAL
{
    internal class UserDB
    {

        public static void SaveRecord(User usr)
        {
            // insert data into User table
            //1. connect DB
            SqlConnection conn = UtilityDB.ConnectDB();

            //2. create and customize an SqlCommand object
            SqlCommand cmdInsert = new SqlCommand();

            cmdInsert.CommandText = "INSERT INTO Users (UserId,Password,EmployeeID)" +
                                    " VALUES (@UserId,@Password,@EmployeeId)";

            cmdInsert.Parameters.AddWithValue("@UserId", usr.UserId);
            cmdInsert.Parameters.AddWithValue("@Password", usr.Password);
            cmdInsert.Parameters.AddWithValue("@EmployeeId", usr.EmployeeID);

            cmdInsert.Connection = conn;
            // 3. perform the INSERT command
            cmdInsert.ExecuteNonQuery();

            //4. close the DB
            conn.Close();
            conn.Dispose();


        }


        public static bool IsDuplicateId(int uId)
        {
     
            User usr = SearchRecord(uId);

            if (usr.UserId != null)
            {
                return false;
            }
            return true;
        }

        public static bool validUserName(string username)
        {

            User usr = SearchRecordByName(username);

            if (usr != null)
            {
                return false;
            }
            return true;
        }

        public static User SearchRecord(int uId)
        {
            User usr = new User();

            SqlConnection conn = UtilityDB.ConnectDB();

            SqlCommand cmdSearchById = new SqlCommand();
            cmdSearchById.CommandText = "SELECT * from Users WHERE UserId =@UserId";
            cmdSearchById.Connection = conn;
            cmdSearchById.Parameters.AddWithValue("@UserId", uId);

            SqlDataReader reader = cmdSearchById.ExecuteReader();


            if (reader.Read())
            {
                usr.UserId = Convert.ToInt32(reader["UserId"]);
                usr.EmployeeID = Convert.ToInt32(reader["EmployeeId"]);
                usr.Password = reader["Password"].ToString();
            
            }

            conn.Close();
            conn.Dispose();
            return usr;
        }

        public static User SearchRecordByName(String username)
        {
            User usr = new User();

            SqlConnection conn = UtilityDB.ConnectDB();

            SqlCommand cmdSearchById = new SqlCommand();
            cmdSearchById.CommandText = "SELECT * from Users  JOIN Employees ON Users.EmployeeId = Employees.EmployeeId WHERE Firstname = @FirstName;";
            cmdSearchById.Connection = conn;
            cmdSearchById.Parameters.AddWithValue("@FirstName", username);

            SqlDataReader reader = cmdSearchById.ExecuteReader();


            if (reader.Read())
            {
                usr.Username = reader["Firstname"].ToString();
 
                usr.Password = reader["Password"].ToString();

            }

            conn.Close();
            conn.Dispose();
            return usr;
        }

        public static void UpdateRecord(User usr)
        {
            // insert into Users VALUES(6555, 'Mary', 'Green', 'Programmer Analyst')
            //1. connect DB
            SqlConnection conn = UtilityDB.ConnectDB();

            //2. create and customize an SqlCommand object
            SqlCommand cmdUpdate = new SqlCommand();

            cmdUpdate.CommandText = "UPDATE Users " + "set UserId = @userId, Password = @Password," +
                                                                        " EmployeeId = @EmployeeId WHERE UserId =@UserId";

            cmdUpdate.Parameters.AddWithValue("@UserId", usr.UserId);
            cmdUpdate.Parameters.AddWithValue("@Password", usr.Password);
            cmdUpdate.Parameters.AddWithValue("@EmployeeId", usr.EmployeeID);


            cmdUpdate.Connection = conn;
            // 3. perform the INSERT command
            cmdUpdate.ExecuteNonQuery();

            //4. close the DB
            conn.Close();
            conn.Dispose();

        }

        public static void DeleteRecord(int usrId)
        {
            SqlConnection conn = UtilityDB.ConnectDB();
            SqlCommand cmdDelete = new SqlCommand();

            User usr = new User();



            cmdDelete.CommandText = "DELETE FROM Users WHERE UserId=@UserId";


            cmdDelete.Connection = conn;
            cmdDelete.Parameters.AddWithValue("@UserId", usrId);

            cmdDelete.ExecuteNonQuery();

            conn.Close();
            conn.Dispose();

        }

        public static List<User> GetAllRecords()
        {
            List<User> listE = new List<User>();

            SqlConnection conn = UtilityDB.ConnectDB();

            SqlCommand cmdSelect = new SqlCommand("SELECT * FROM Users ", conn);

            // perform theselect quer
            SqlDataReader reader = cmdSelect.ExecuteReader();

            User usr;
            ///Employee emp = new Employee();


            while (reader.Read())
            {
                usr = new User();
                usr.UserId = Convert.ToInt32(reader["UserId"]);
                usr.Password = reader["Password"].ToString();
                usr.EmployeeID = Convert.ToInt32(reader["EmployeeId"]);
     

                listE.Add(usr);
            }

            conn.Close();
            conn.Dispose();



            return listE;

        }


    }
}
