using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsAppEntityFramework
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        HiTechManagementDBEntities database = new HiTechManagementDBEntities();
        private void buttonLogin_Click(object sender, EventArgs e)
        {
            var listUsers = from c in database.Users
                            select c;
            string username = "";
            username = textBoxUsername.Text.Trim();
            User usr = new User();

            if (usr != null)
            {

                //Here we would have used a funcito to validate the user instead of hardcoded validation.
                    if ((username == "Mary" ) && (textBoxPassword.ToString() == "12345"))
                    {
                        this.Hide();
                        FormOrders ordForm = new FormOrders();
                        ordForm.ShowDialog();
                    }
                    else if ((username == "Jennifer") && (textBoxPassword.ToString() == "12345"))
                    {
                        this.Hide();
                        FormOrders ordForm = new FormOrders();
                        ordForm.ShowDialog();
                    }


                    else
                    {
                        MessageBox.Show("Please Check the Credentials!", "Error", MessageBoxButtons.OK);
                    }

            }
            
        }
    }
}
