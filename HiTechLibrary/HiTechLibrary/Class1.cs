using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Configuration;
using System.Text.RegularExpressions; // use the class Regex
using Microsoft.VisualBasic; // Information.IsNumeric(input)
using HiTechManagement.BLL;
using HiTechManagement.DAL;
using HiTechManagement.Validator;

namespace HiTechManagement.BLL
{
    internal class Employee
    {
        private int employeeId;
        private string firstName;
        private string lastName;
        private String phone;
        private string email;
        private int jobId;
        private int statusId;

        // Properties
        public int EmployeeId { get => employeeId; set => employeeId = value; }
        public string FirstName { get => firstName; set => firstName = value; }
        public string LastName { get => lastName; set => lastName = value; }
        public String Phone { get => phone; set => phone = value; }
        public string Email { get => email; set => email = value; }
        public int JobId { get => jobId; set => jobId = value; }
        public int StatusId { get => statusId; set => statusId = value; }

        //custom methods

        public void SaveEmployee(Employee emp)
        {
            EmployeeDB.SaveRecord(emp);

        }

        public Employee SearchEmployee(int empId)
        {
            return EmployeeDB.SearchRecord(empId);

        }

        public bool IdExists(int id)
        {
            return EmployeeDB.IsDuplicateId(id);
        }

        public void UpdateEmployee(Employee emp)
        {
            EmployeeDB.UpdateRecord(emp);
        }
        public void DeleteEmployee(int eId)
        {
            EmployeeDB.DeleteRecord(eId);

        }

        public List<Employee> GetEmployeeList()
        {
            return EmployeeDB.GetAllRecords();
        }

    }
    internal class User
    {
        // Private variables
        private int userId;
        private string password;
        private int employeeID;
        private string username;

        // Properties
        public int UserId { get => userId; set => userId = value; }
        public string Password { get => password; set => password = value; }
        public int EmployeeID { get => employeeID; set => employeeID = value; }
        public String Username { get => username; set => username = value; }



        // Methods
        public void SaveUser(User usr)
        {
            UserDB.SaveRecord(usr);

        }
        public bool IdExists(int id)
        {
            return UserDB.IsDuplicateId(id);
        }

        public void UpdateUser(User emp)
        {
            UserDB.UpdateRecord(emp);
        }

        public void DeleteUser(int eId)
        {
            UserDB.DeleteRecord(eId);

        }

        public User SearchUser(int usrId)
        {
            return UserDB.SearchRecord(usrId);

        }

        public User ValidateUserByName(string username)
        {
            return UserDB.SearchRecordByName(username);

        }

        public List<User> GetUserList()
        {
            return UserDB.GetAllRecords();
        }



    }
    internal class Customer
    {
        public int CustomerId { get; set; }
        public string CustomerName { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string PostalCode { get; set; }
        public string Phone { get; set; }
        public string Fax { get; set; }
        public int CreditLimit { get; set; }
        public string Email { get; set; }


        public List<Customer> GetStudentList()
        {
            return CustomerDB.GetAllRecords();
        }
    }
    public class Book
    {

        // Private variables
        private int isbn;
        private string title;
        private decimal unitPrice;
        private int yearPublished;
        private int qoh;
        private int categoryId;
        private int publisherId;


        // Properties
        public int ISBN { get => isbn; set => isbn = value; }
        public string Title { get => title; set => title = value; }
        public decimal UnitPrice { get => unitPrice; set => unitPrice = value; }
        public int YearPublished { get => yearPublished; set => yearPublished = value; }
        public int QOH { get => qoh; set => qoh = value; }
        public int CategoryId { get => categoryId; set => categoryId = value; }
        public int PublisherId { get => publisherId; set => publisherId = value; }

        //custom methods

        public void SaveBook(Book bk)
        {
            BookDB.SaveRecord(bk);

        }
        public Book SearchBook(int ebk)
        {
            return BookDB.SearchRecord(ebk);

        }

        public bool IdExists(int id)
        {
            return BookDB.IsDuplicateId(id);
        }


        public void UpdateBook(Book bk)
        {
            BookDB.UpdateRecord(bk);
        }

        public void DeleteBook(int eId)
        {
            BookDB.DeleteRecord(eId);

        }

        public List<Book> GetBookList()
        {
            return BookDB.GetAllRecords();
        }


    }
}

namespace HiTechManagement.DAL
{
    internal class BookDB
    {

        public static void SaveRecord(Book bk)
        {
            // insert into Employees VALUES(6555, 'Mary', 'Green', 'Programmer Analyst')
            //1. connect DB
            SqlConnection conn = UtilityDB.ConnectDB();

            //2. create and customize an SqlCommand object
            SqlCommand cmdInsert = new SqlCommand();

            cmdInsert.CommandText = "INSERT INTO Books (ISBN,Title,UnitPrice,Year,QOH,CategoryId,PublisherId)" +
                                    " VALUES (@ISBN,@Title,@UnitPrice,@Year,@QOH,@CategoryId,@PublisherId)";

            cmdInsert.Parameters.AddWithValue("@ISBN", bk.ISBN);
            cmdInsert.Parameters.AddWithValue("@Title", bk.Title);
            cmdInsert.Parameters.AddWithValue("@UnitPrice", bk.UnitPrice);
            cmdInsert.Parameters.AddWithValue("@Year", bk.YearPublished);
            cmdInsert.Parameters.AddWithValue("@QOH", bk.QOH);
            cmdInsert.Parameters.AddWithValue("@CategoryId", bk.QOH);
            cmdInsert.Parameters.AddWithValue("@PublisherId", bk.PublisherId);


            cmdInsert.Connection = conn;
            // 3. perform the INSERT command
            cmdInsert.ExecuteNonQuery();

            //4. close the DB
            conn.Close();
            conn.Dispose();


        }

        public static bool IsDuplicateId(int bId)
        {
            Book bk = SearchRecord(bId);

            if (bk != null)
            {
                return false;
            }
            return true;
        }

        public static Book SearchRecord(int bId)
        {
            Book bk = new Book();

            SqlConnection conn = UtilityDB.ConnectDB();

            SqlCommand cmdSearchById = new SqlCommand();
            cmdSearchById.CommandText = "SELECT * from Books WHERE ISBN =@ISBN";
            cmdSearchById.Connection = conn;
            cmdSearchById.Parameters.AddWithValue("@ISBN", bId);

            SqlDataReader reader = cmdSearchById.ExecuteReader();


            if (reader.Read())
            {
                bk.ISBN = Convert.ToInt32(reader["ISBN"]);
                bk.Title = reader["Title"].ToString();
                bk.UnitPrice = Convert.ToDecimal(reader["UnitPrice"]);
                bk.YearPublished = Convert.ToInt32(reader["Year"]);
                bk.QOH = Convert.ToInt32(reader["QOH"]);
                bk.CategoryId = Convert.ToInt32(reader["CategoryId"]);
                bk.PublisherId = Convert.ToInt32(reader["PublisherId"]);

            }

            conn.Close();
            conn.Dispose();
            return bk;
        }

        public static void UpdateRecord(Book bk)
        {
            // insert into Employees VALUES(6555, 'Mary', 'Green', 'Programmer Analyst')
            //1. connect DB
            SqlConnection conn = UtilityDB.ConnectDB();

            //2. create and customize an SqlCommand object
            SqlCommand cmdUpdate = new SqlCommand();

            cmdUpdate.CommandText = "UPDATE Books " + "set ISBN = @ISBN, Title = @Title," +
                                                                        " UnitPrice = @UnitPrice,Year = @Year,QOH = @QOH, CategoryId = @CategoryId, PublisherId = @PublisherId WHERE ISBN =@ISBN";

            cmdUpdate.Parameters.AddWithValue("@ISBN", bk.ISBN);
            cmdUpdate.Parameters.AddWithValue("@Title", bk.Title);
            cmdUpdate.Parameters.AddWithValue("@UnitPrice", bk.UnitPrice);
            cmdUpdate.Parameters.AddWithValue("@Year", bk.YearPublished);
            cmdUpdate.Parameters.AddWithValue("@QOH", bk.QOH);
            cmdUpdate.Parameters.AddWithValue("@CategoryId", bk.CategoryId);
            cmdUpdate.Parameters.AddWithValue("@PublisherId", bk.PublisherId);

            cmdUpdate.Connection = conn;
            // 3. perform the INSERT command
            cmdUpdate.ExecuteNonQuery();

            //4. close the DB
            conn.Close();
            conn.Dispose();

        }

        public static void DeleteRecord(int ebk)
        {
            SqlConnection conn = UtilityDB.ConnectDB();
            SqlCommand cmdDelete = new SqlCommand();

            Book bk = new Book();



            cmdDelete.CommandText = "DELETE FROM Books WHERE ISBN=@ISBN";


            cmdDelete.Connection = conn;
            cmdDelete.Parameters.AddWithValue("@ISBN", ebk);

            cmdDelete.ExecuteNonQuery();

            conn.Close();
            conn.Dispose();

        }

        public static List<Book> GetAllRecords()
        {
            List<Book> listB = new List<Book>();

            SqlConnection conn = UtilityDB.ConnectDB();

            SqlCommand cmdSelect = new SqlCommand("SELECT * FROM Books ", conn);

            // perform theselect quer
            SqlDataReader reader = cmdSelect.ExecuteReader();

            Book bk;
            ///Employee emp = new Employee();


            while (reader.Read())
            {
                bk = new Book();
                bk.ISBN = Convert.ToInt32(reader["ISBN"]);
                bk.Title = reader["Title"].ToString();
                bk.UnitPrice = Convert.ToInt32(reader["Unitprice"]);
                bk.YearPublished = Convert.ToInt32(reader["Year"]);
                bk.QOH = Convert.ToInt32(reader["QOH"]);
                bk.CategoryId = Convert.ToInt32(reader["CategoryId"]);
                bk.PublisherId = Convert.ToInt32(reader["PublisherId"]);

                listB.Add(bk);
            }

            conn.Close();
            conn.Dispose();



            return listB;

        }

    }

    internal class CustomerDB
    {
        public static List<Customer> GetAllRecords()
        {
            List<Customer> listC = new List<Customer>();
            Customer aCustomer;
            using (SqlConnection conn = UtilityDB.ConnectDB())
            {
                SqlCommand cmdSelectAll = new SqlCommand("SELECT * FROM Customers", conn);
                SqlDataReader reader = cmdSelectAll.ExecuteReader();
                while (reader.Read())
                {
                    aCustomer = new Customer();
                    aCustomer.CustomerId = Convert.ToInt32(reader["CustomerId"]);
                    aCustomer.CustomerName = reader["CustomerName"].ToString();
                    aCustomer.Address = reader["Address"].ToString();
                    aCustomer.City = reader["City"].ToString();
                    aCustomer.PostalCode = reader["PostalCode"].ToString();
                    aCustomer.Phone = reader["Phone"].ToString();
                    aCustomer.Fax = reader["Fax"].ToString();
                    aCustomer.CreditLimit = Convert.ToInt32(reader["CreditLimit"].ToString());
                    aCustomer.Email = reader["Email"].ToString();
                    listC.Add(aCustomer);

                }

            }

            return listC;
        }
    }

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

            if (usr != null)
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

    internal class UtilityDB
    {
        public static SqlConnection ConnectDB()
        {
            /*  SqlConnection conn = new SqlConnection();
              conn.ConnectionString = "server=DESKTOP-MDNT271\\SQLSERVEREXPRESS;database=EmployeeDB;user=sa;password=123456";
              conn.Open();
              return conn;
              */
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = ConfigurationManager.ConnectionStrings["connectDB"].ConnectionString;
            conn.Open();
            return conn;
        }


    }
}


namespace HiTechManagement.Validator
{
    internal class Validator
    {
        // User ID: 4-digit number
        public static bool IsValidId(string input)
        {

            if (!(Regex.IsMatch(input, @"^\d{4}$")))
            {
                return false;

            }
            return true;
        }
        // Valid user name
        public static bool IsValidName(string input)
        {
            for (int i = 0; i < input.Length; i++)
            {
                if ((!Char.IsLetter(input[i])) && (!Char.IsWhiteSpace(input[i])))

                {

                    return false;

                }

            }
            return true;
        }

        // student ID : 7-digit number
        public static bool IsValid(string input)
        {
            if (input.Length != 4)
            {
                return false;
            }
            else // 7 : 1234abc/ abc1234/
            {
                for (int i = 0; i < input.Length; i++)
                {
                    if (!(Char.IsDigit(input[i])))
                    {
                        return false;
                    }

                }
            }
            return true;
        }

        public static bool IsValidID(string input)
        {
            if (input.Length != 7)
            {
                return false;
            }
            else // 7 : 1234abc/ abc1234/
            {
                for (int i = 0; i < input.Length; i++)
                {
                    if (!(Char.IsDigit(input[i])))
                    {
                        return false;
                    }

                }
            }
            return true;
        }



    }
}