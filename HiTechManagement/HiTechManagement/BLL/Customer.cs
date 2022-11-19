using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HiTechManagement.DAL;

namespace HiTechManagement.BLL
{
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
}
