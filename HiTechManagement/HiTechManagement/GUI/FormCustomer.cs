using HiTechManagement.BLL;
using HiTechManagement.DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HiTechManagement.GUI
{
    
public partial class FormCustomer : Form
{
        SqlDataAdapter da;
        DataSet dsCustomerDB;
        DataTable dtCustomers;
        SqlCommandBuilder sqlBuilder; //build up INSERT/UPDATE/DELETE
        Customer aCustomer = new Customer();
        public FormCustomer()
        {
            InitializeComponent();
        }

        private void buttonSaveCustomer_Click(object sender, EventArgs e)
        {


            if ((Validator.Validator.IsValidName(textBoxCustomerName.Text)))
            {
                 DataRow dr = dtCustomers.NewRow();
               
                dr["CustomerName"] = textBoxCustomerName.Text.Trim();
                dr["Email"] = textBoxEmail.Text.Trim();
                dr["Phone"] = textBoxPhone.Text.Trim();
                dr["Address"] = textBoxAddress.Text.Trim();
                dr["PostalCode"] = textBoxPostalCode.Text.Trim();
                dr["City"] = textBoxCity.Text.Trim();
                dr["Fax"] = textBoxFax.Text.Trim();
                dr["CreditLimit"] = textBoxCreditLimit.Text.Trim();

                dtCustomers.Rows.Add(dr);
                MessageBox.Show(dr.RowState.ToString(), "RowState in Datatable");

                textBoxCustomerName.Clear();
                textBoxCity.Clear();
                textBoxAddress.Clear();
                textBoxCreditLimit.Clear();
                textBoxFax.Clear();
                textBoxEmail.Clear();
                textBoxPostalCode.Clear();
                textBoxPhone.Clear();
             
            }

            else
            {
                if (!(Validator.Validator.IsValidName(textBoxCustomerName.Text)))
                {
                    MessageBox.Show("Name contains only letters or space(s) to separate first name components ", "Invalid First Name", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    textBoxCustomerName.Clear();
                    textBoxCustomerName.Focus();
                    return;
                }



            }

        }

        private void buttonLoad_Click(object sender, EventArgs e)
        {
            // textBoxStudentId.Enabled = false;
            // create DataSet object
            dsCustomerDB = new DataSet("CustomerDS");
            //create a DataTable object
            dtCustomers = new DataTable("Customers");
            dsCustomerDB.Tables.Add(dtCustomers);

            //create columns and add columns to the datatable
            dtCustomers.Columns.Add("CustomerId", typeof(Int32));
            dtCustomers.Columns.Add("CustomerName", typeof(string));
            dtCustomers.Columns.Add("Phone", typeof(string));
            dtCustomers.Columns.Add("Email", typeof(string));
            dtCustomers.Columns.Add("Address", typeof(string));
            dtCustomers.Columns.Add("City", typeof(string));
            dtCustomers.Columns.Add("PostalCode", typeof(string));
            dtCustomers.Columns.Add("Fax", typeof(string));
            dtCustomers.Columns.Add("CreditLimit", typeof(Int32));
            dtCustomers.PrimaryKey = new DataColumn[] { dtCustomers.Columns["CustomerId"] };
            dtCustomers.Columns["CustomerId"].AutoIncrement = true;
            dtCustomers.Columns["CustomerId"].AutoIncrementSeed = 1111111;
            dtCustomers.Columns["CustomerId"].AutoIncrementStep = 1;
            da = new SqlDataAdapter("SELECT * FROM Customers", UtilityDB.ConnectDB());
            sqlBuilder = new SqlCommandBuilder(da);
        }

        private void buttonListCustomers_Click(object sender, EventArgs e)
        {
           //da.Fill(dsCustomerDB.Tables["Customers"]);
           //listViewCustomers.DataSource = dsCustomerDB.Tables["Customers"];
        }

        private void buttonUpdateCustomer_Click(object sender, EventArgs e)
        {
            int searchId = Convert.ToInt32(textBoxSearchById.Text);
            DataRow dr = dtCustomers.Rows.Find(searchId);
            dr["CustomerName"] = textBoxCustomerName.Text.Trim();
            dr["Address"] = textBoxAddress.Text.Trim();
            dr["City"] = textBoxCity.Text.Trim();
            dr["PostalCode"] = textBoxPostalCode.Text.Trim();
            dr["Phone"] = textBoxPhone.Text.Trim();
            dr["Fax"] = textBoxFax.Text.Trim();
            dr["CreditLimit"] = textBoxCreditLimit.Text.Trim();
            dr["Email"] = textBoxEmail.Text.Trim();
            MessageBox.Show(dr.RowState.ToString(), "RowState in Datatable");
            textBoxCustomerName.Clear();
            textBoxCity.Clear();
            textBoxAddress.Clear();
            textBoxCreditLimit.Clear();
            textBoxFax.Clear();
            textBoxEmail.Clear();
            textBoxPostalCode.Clear();
            textBoxPhone.Clear();
        }

        private void buttonDeleteCustomer_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Do you want to delete this student?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question).ToString() == "Yes")
            {
                //you have to check the courses registered by this student
                int sId = Convert.ToInt32(textBoxSearchById.Text);
                DataRow dr = dtCustomers.Rows.Find(sId);
                dr.Delete();
                MessageBox.Show(dr.RowState.ToString(), "RowState in Datatable");
                textBoxCustomerName.Clear();
                textBoxCity.Clear();
                textBoxAddress.Clear();
                textBoxCreditLimit.Clear();
                textBoxFax.Clear();
                textBoxEmail.Clear();
                textBoxPostalCode.Clear();
                textBoxPhone.Clear();
            }
        }

        private void buttonSearchCustomer_Click(object sender, EventArgs e)
        {
            if (!Validator.Validator.IsValidID(textBoxSearchById.Text.Trim()))
            {
                MessageBox.Show("Customer ID must be 7-digit number.", "Invalid ID", MessageBoxButtons.OK, MessageBoxIcon.Error
                                        );
                textBoxSearchById.Clear();
                textBoxSearchById.Focus();
                return;
            }

            int searchId = Convert.ToInt32(textBoxSearchById.Text);
            DataRow dr = dtCustomers.Rows.Find(searchId);
            if (dr != null)
            {
                textBoxCustomerName.Text = dr["CustomerName"].ToString();
                textBoxEmail.Text = dr["Email"].ToString();
                textBoxPhone.Text = dr["Phone"].ToString();
                textBoxAddress.Text = dr["Address"].ToString();
                textBoxCity.Text = dr["City"].ToString();
                textBoxFax.Text = dr["Fax"].ToString();
                textBoxPostalCode.Text = dr["PostalCode"].ToString();
                textBoxCreditLimit.Text = dr["CreditLimit"].ToString();
              


            }
            else
            {

                MessageBox.Show("Customer not found!", "Error : No StudentId");
                textBoxSearchById.Clear();
                textBoxSearchById.Focus();
            }
        }

        private void buttonExitCustomer_Click(object sender, EventArgs e)
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
