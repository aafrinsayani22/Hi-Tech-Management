using HiTechManagement.BLL;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
}
