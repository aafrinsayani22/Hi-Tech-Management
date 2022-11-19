using HiTechManagement.DAL;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HiTechManagement.BLL
{
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
}
