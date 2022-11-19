using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using HiTechManagement.BLL;
using HiTechManagement.Validator;

namespace HiTechManagement.GUI
{
    public partial class FormUser : Form
    {
        public FormUser()
        {
            InitializeComponent();
        }


        private void buttonAdd_Click(object sender, EventArgs e)
        {

            // Input Data validation for User Id

            string input = "";
            input = textBoxUserId.Text.Trim();
            string inputEmp = "";
            inputEmp = textBoxEmployeeID.Text.Trim();
            User usr = new User();
            Employee emp = new Employee();
            emp = emp.SearchEmployee(Convert.ToInt32(inputEmp));
            usr = usr.SearchUser(Convert.ToInt32(input));
            emp = new Employee();

            if (Validator.Validator.IsValid(input) == false)
            {
                MessageBox.Show("Invalid User ID", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBoxUserId.Clear();
                textBoxUserId.Focus();
                return;
            }
            
            if (usr.UserId.ToString() == input)
            {
                MessageBox.Show("User Id already exists!", "Duplicate User ID", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBoxUserId.Clear();
                textBoxUserId.Focus();
                return;
            }
            if (usr.EmployeeID.ToString() == inputEmp)
            {
                MessageBox.Show("Employee Id already exists!", "Duplicate User ID", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBoxEmployeeID.Clear();
                textBoxEmployeeID.Focus();
                return;
            }

            else if (Validator.Validator.IsValidID(inputEmp) == false)
            {
                MessageBox.Show("Invalid Employee ID", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBoxEmployeeID.Clear();
                textBoxEmployeeID.Focus();
                return;
            }
            
            


            // Perform Save Operation

            if (MessageBox.Show("Do you really want to add  this User? ", "Confirmation", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                //Employee emp = new Employee();

                usr.UserId = Convert.ToInt32(textBoxUserId.Text.Trim());
                usr.Password = textBoxPassword.Text;
                usr.EmployeeID = Convert.ToInt32(textBoxEmployeeID.Text.Trim());


                usr.SaveUser(usr);
                //emp.UpdateEmployee(emp);

                MessageBox.Show("User added Successfully!", "Added");

            }
        }

        private void buttonUpdate_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Do you really want to update this user? ", "Confirmation", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                User usr = new User();
                usr.UserId = Convert.ToInt32(textBoxUserId.Text.Trim());
                usr.Password = textBoxPassword.Text;
                usr.EmployeeID = Convert.ToInt32(textBoxEmployeeID.Text.Trim());


                usr.UpdateUser(usr);

                MessageBox.Show("User Updated Successfully!", "Update");

            }

        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            string input = "";

            input = textBoxUserId.Text.Trim();
            if (!Validator.Validator.IsValidId(input))
            {
                MessageBox.Show("Invalid User ID", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBoxUserId.Clear();
                textBoxUserId.Focus();
                return;
            }


            User usr = new User();
       
            usr = usr.SearchUser(Convert.ToInt32(input));

            if (usr != null)
            {

                if (MessageBox.Show("Do you really want to delete this User? ", "Confirmation", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {

                    usr.UserId = Convert.ToInt32(textBoxUserId.Text.Trim());
                    //emp.FirstName = textBoxFirstName.Text;
                    //emp.LastName = textBoxLastName.Text;
                    //emp.JobTitle = textBoxJobtitle.Text;

                    usr.DeleteUser(Convert.ToInt32(input));

                    MessageBox.Show("User Deleted Successfully!", "Delete");
                    textBoxUserId.Clear();
                    textBoxPassword.Clear();
                    textBoxEmployeeID.Clear();
                
                }
            }


            else
            {
                MessageBox.Show("User Not Found", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonSearch_Click(object sender, EventArgs e)
        {
            //if (comboBoxSearchoption.SelectedIndex == -1)
           // {
               // MessageBox.Show("Please select the search option.", "Missing search option", MessageBoxButtons.OK, MessageBoxIcon.Error);
               // return;
            //}
            // Input data validation
            string input = "";
            input = textBoxUserId.Text.Trim();

            if (!Validator.Validator.IsValidId(input))
            {
                MessageBox.Show("Invalid User ID", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBoxUserId.Clear();
                textBoxUserId.Focus();
                return;
            }

            User usr = new User();
            usr = usr.SearchUser(Convert.ToInt32(input));

            if (usr.UserId != 0)
            {
                //messagebox.show(emp.employeeid + "," +
                //                emp.firstname + "," +
                //                emp.lastname + "," +
                //                emp.jobtitle);

                textBoxUserId.Text = usr.UserId.ToString();
                textBoxPassword.Text = usr.Password;
                textBoxEmployeeID.Text = usr.EmployeeID.ToString();
             
       
               // buttonDelete.Enabled = true;
                //buttonUpdateUser.Enabled = true;


            }

            else
            {
                MessageBox.Show("User Not Found", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void listViewUsers_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void buttonListUsers_Click(object sender, EventArgs e)
        {
            User usr = new User();
            List<User> listUsr = usr.GetUserList();
            listViewUsers.Items.Clear();

            foreach (User anUsr in listUsr)
            {
                ListViewItem item = new ListViewItem(anUsr.UserId.ToString());
                item.SubItems.Add(anUsr.Password);
                item.SubItems.Add(anUsr.EmployeeID.ToString());

                listViewUsers.Items.Add(item);


            }
        }

        private void buttonSaveEmployee_Click(object sender, EventArgs e)
        {
            // Input Data validation

          

            
            Employee emp = new Employee();
            

            string input = "";
            input = textBoxEmpId.Text;

            // Perform Save Operation
            if(! (Validator.Validator.IsValidID(input)))
            {
                MessageBox.Show("Invalid Employee ID!", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    textBoxEmpId.Clear();
                    textBoxEmpId.Focus();
                    return;
            }

            if (emp.EmployeeId.ToString() == input)
            {
                MessageBox.Show("Employee Id already exists!", "Duplicate Employee ID", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBoxEmpId.Clear();
                textBoxEmpId.Focus();
                return;
            }
            if (MessageBox.Show("Do you really want to add  this employee? ", "Confirmation", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                //Employee emp = new Employee();

                emp.EmployeeId = Convert.ToInt32(textBoxEmpId.Text.Trim());
                emp.FirstName = textBoxFirstname.Text;
                emp.LastName = textBoxLastname.Text;
                emp.Phone = textBoxPhone.Text.Trim();
                emp.Email = textBoxEmail.Text;
                emp.JobId = Convert.ToInt32(textBoxJobId.Text.Trim());
                emp.StatusId = Convert.ToInt32(textBoxStatusId.Text.Trim());

                emp.SaveEmployee(emp);
                //emp.UpdateEmployee(emp);

                MessageBox.Show("Employee added Successfully!", "Added");

            }
            
        }

        private void buttonUpdateEmployee_Click(object sender, EventArgs e)
        {





            if (MessageBox.Show("Do you really want to update this employee? ", "Confirmation", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {

                Employee emp = new Employee();
                    emp.EmployeeId = Convert.ToInt32(textBoxEmpId.Text.Trim());
                    emp.FirstName = textBoxFirstname.Text;
                    emp.LastName = textBoxLastname.Text;
                    emp.Phone = textBoxPhone.Text;
                    emp.JobId = Convert.ToInt32(textBoxJobId.Text.Trim());
                    emp.StatusId = Convert.ToInt32(textBoxStatusId.Text.Trim());

                    emp.UpdateEmployee(emp);

                    MessageBox.Show("Employee Updated Successfully!", "Update");
            }
               

        }

        private void buttonDeleteEmployee_Click(object sender, EventArgs e)
        {
            string input = "";

            input = textBoxEmpId.Text.Trim();
            if (!Validator.Validator.IsValid(input))
            {
                MessageBox.Show("Invalid Employee ID", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBoxEmpId.Clear();
                textBoxEmpId.Focus();
                return;
            }


            Employee emp = new Employee();
            emp = emp.SearchEmployee(Convert.ToInt32(input));

            if (emp != null)
            {

                if (MessageBox.Show("Do you really want to delete this employee? ", "Confirmation", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {

                    emp.EmployeeId = Convert.ToInt32(textBoxEmpId.Text.Trim());
                    //emp.FirstName = textBoxFirstName.Text;
                    //emp.LastName = textBoxLastName.Text;
                    //emp.JobTitle = textBoxJobtitle.Text;

                    emp.DeleteEmployee(Convert.ToInt32(input));

                    MessageBox.Show("Employee Deleted Successfully!", "Delete");
                    textBoxEmpId.Clear();
                    textBoxFirstname.Clear();
                    textBoxLastname.Clear();
                    textBoxPhone.Clear();
                    textBoxStatusId.Clear();
                    textBoxEmail.Clear();
                    textBoxJobId.Clear();
                }
            }


            else
            {
                MessageBox.Show("Employee Not Found", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void buttonSearchEmployee_Click(object sender, EventArgs e)
        {
            // Input data validation
            string input = "";
            input = textBoxEmpId.Text.Trim();
            Employee emp = new Employee();
            emp = emp.SearchEmployee(Convert.ToInt32(input));

            if (emp.EmployeeId != 0)
            {
                //messagebox.show(emp.employeeid + "," +
                //                emp.firstname + "," +
                //                emp.lastname + "," +
                //                emp.jobtitle);

                textBoxEmpId.Text = emp.EmployeeId.ToString();
                textBoxFirstname.Text = emp.FirstName;
                textBoxLastname.Text = emp.LastName;
                textBoxPhone.Text = emp.Phone;
                textBoxEmail.Text = emp.Email;
                textBoxJobId.Text = emp.JobId.ToString();
                textBoxStatusId.Text = emp.StatusId.ToString();
           

                buttonDelete.Enabled = true;
                buttonUpdateEmployee.Enabled = true;


            }

            else
            {
                MessageBox.Show("Employee Not Found", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonListEployees_Click(object sender, EventArgs e)
        {
            Employee emp = new Employee();
            List<Employee> listEmp = emp.GetEmployeeList();
            listView1.Items.Clear();


            foreach (Employee anEmp in listEmp)
            {
                ListViewItem item = new ListViewItem(anEmp.EmployeeId.ToString());
                item.SubItems.Add(anEmp.FirstName);
                item.SubItems.Add(anEmp.LastName);
                item.SubItems.Add(anEmp.Phone);
                item.SubItems.Add(anEmp.Email);
                item.SubItems.Add(anEmp.JobId.ToString());
                item.SubItems.Add(anEmp.StatusId.ToString());
                listView1.Items.Add(item);
            }
        }

        private void buttonExit_Click(object sender, EventArgs e)
        {
            //Application.Exit();
            this.Hide();
            FormLogin loginForm = new FormLogin();
            loginForm.ShowDialog();
        }

        private void buttonExitEmp_Click(object sender, EventArgs e)
        {
            //Application.Exit();
            this.Hide();
            FormLogin loginForm = new FormLogin();
            loginForm.ShowDialog();
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }
    }
}
