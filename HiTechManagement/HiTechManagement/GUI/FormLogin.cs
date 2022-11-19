using HiTechManagement.BLL;
using HiTechManagement.GUI;

namespace HiTechManagement
{
    public partial class FormLogin : Form
    {
        public FormLogin()
        {
            InitializeComponent();
        }

        private void buttonLogin_Click(object sender, EventArgs e)
        {
            string username = "";
            username = textBoxUsername.Text.Trim();
            User usr = new User();
            usr = usr.ValidateUserByName(username);

            if (usr != null)
            {
                
                if ((usr.Password == textBoxPassword.Text) && (usr.Username == textBoxUsername.Text))
                {
                    if(usr.Username == "Henry")
                    {
                        this.Hide();
                        FormUser empForm = new FormUser();
                        empForm.ShowDialog();
                    }
                    if(usr.Username == "Thomas")
                    {
                        this.Hide();
                        FormCustomer cusForm = new FormCustomer();
                        cusForm.ShowDialog();

                    }
                    if (usr.Username == "Peter")
                    {
                        this.Hide();
                        FormBook bkForm = new FormBook();
                        bkForm.ShowDialog();

                    }

                }
                else
                {
                    MessageBox.Show("Please Check the Credentials!", "Error", MessageBoxButtons.OK);
                }

            }
            
            else
            {
                MessageBox.Show("No User Found!");
            }
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}