using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Configuration;

namespace HiTechManagement.DAL
{
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
