using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using HiTechManagement.BLL;

namespace HiTechManagement.DAL
{
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
}
