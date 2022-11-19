using HiTechManagement.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        public int StatusId { get => statusId; set => statusId = value;}

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
}
