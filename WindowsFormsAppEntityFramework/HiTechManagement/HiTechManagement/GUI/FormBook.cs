using HiTechManagement.BLL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HiTechManagement.GUI
{
    public partial class FormBook : Form
    {
        public FormBook()
        {
            InitializeComponent();
        }

        private void buttonSaveBook_Click(object sender, EventArgs e)
        {
            // Input Data validation

            string input = "";
            input = textBoxISBN.Text.Trim();
            Book bk = new Book();
          
            bk = bk.SearchBook(Convert.ToInt32(input));
            

            if (!Validator.Validator.IsValidID(input))
            {
                MessageBox.Show("Invalid ISBN ID!", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBoxISBN.Clear();
                textBoxISBN.Focus();
                return;
            }
            

            else if (bk.ISBN.ToString() == input)
            {
                MessageBox.Show("ISBN Id already exists!", "Duplicate ISBN ID", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBoxISBN.Clear();
                return;
            }

            // Perform Save Operation

            if (MessageBox.Show("Do you really want to add  this Book? ", "Confirmation", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                //Employee emp = new Employee();

                bk.ISBN = Convert.ToInt32(textBoxISBN.Text.Trim());
                bk.Title = textBoxTitle.Text;
                bk.UnitPrice = Convert.ToDecimal(textBoxUnitPrice.Text);
                bk.YearPublished = Convert.ToInt32(textBoxYear.Text);
                bk.QOH = Convert.ToInt32(textBoxQOH.Text);
                bk.CategoryId = Convert.ToInt32(textBoxCategoryID.Text);
                bk.PublisherId = Convert.ToInt32(textBoxPublisherID.Text);

                bk.SaveBook(bk);
                //emp.UpdateEmployee(emp);

                MessageBox.Show("Employee added Successfully!", "Added");

            }
        }

        private void buttonUpdateCustomer_Click(object sender, EventArgs e)
        {
            string input = "";

            input = textBoxSearchById.Text.Trim();
            if (!Validator.Validator.IsValidID(input))
            {
                MessageBox.Show("Invalid Book ID", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBoxISBN.Clear();
                textBoxISBN.Focus();
                return;
            }


            Book bk = new Book();
            bk = bk.SearchBook(Convert.ToInt32(input));

            if (bk.ISBN != 0)
            {
                if (MessageBox.Show("Do you really want to update this Book? ", "Confirmation", MessageBoxButtons.YesNo) == DialogResult.Yes) 
                {
                    bk = new Book();
                    bk.ISBN = Convert.ToInt32(textBoxISBN.Text.Trim());
                    bk.Title = textBoxTitle.Text;
                    bk.UnitPrice = Convert.ToDecimal(textBoxUnitPrice.Text);
                    bk.YearPublished = Convert.ToInt32(textBoxYear.Text);
                    bk.QOH = Convert.ToInt32(textBoxQOH.Text);
                    bk.CategoryId = Convert.ToInt32(textBoxCategoryID.Text);
                    bk.PublisherId = Convert.ToInt32(textBoxPublisherID.Text);

                    bk.UpdateBook(bk);

                    MessageBox.Show("Book Updated Successfully!", "Update");

                }
            }
            else
            {
                MessageBox.Show("Book Not Found", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void buttonDeleteCustomer_Click(object sender, EventArgs e)
        {
            string input = "";

            input = textBoxSearchById.Text.Trim();
            if (!Validator.Validator.IsValidID(input))
            {
                MessageBox.Show("Invalid Book ID", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBoxISBN.Clear();
                textBoxISBN.Focus();
                return;
            }


            Book bk = new Book();
            bk = bk.SearchBook(Convert.ToInt32(input));

            if (bk.ISBN != 0)
            {

                if (MessageBox.Show("Do you really want to delete this Book? ", "Confirmation", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {

                    bk.ISBN = Convert.ToInt32(textBoxISBN.Text.Trim());
                    //emp.FirstName = textBoxFirstName.Text;
                    //emp.LastName = textBoxLastName.Text;
                    //emp.JobTitle = textBoxJobtitle.Text;

                    bk.DeleteBook(Convert.ToInt32(input));

                    MessageBox.Show("Book Deleted Successfully!", "Delete");
                    textBoxISBN.Clear();
                    textBoxTitle.Clear();
                    textBoxUnitPrice.Clear();
                    textBoxYear.Clear();
                    textBoxQOH.Clear();
                    textBoxCategoryID.Clear();
                    textBoxPublisherID.Clear();
                   
                }
            }


            else
            {
                MessageBox.Show("Book Not Found", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonListBooks_Click(object sender, EventArgs e)
        {
            Book bk = new Book();
            List<Book> listBk = bk.GetBookList();
            listViewBooks.Items.Clear();

            foreach (Book abk in listBk)
            {
                ListViewItem item = new ListViewItem(abk.ISBN.ToString());
                item.SubItems.Add(abk.Title);
                item.SubItems.Add(abk.UnitPrice.ToString());
                item.SubItems.Add(abk.YearPublished.ToString());
                item.SubItems.Add(abk.QOH.ToString());
                item.SubItems.Add(abk.CategoryId.ToString()); 
                item.SubItems.Add(abk.PublisherId.ToString());
                
                listViewBooks.Items.Add(item);
            }

        }

        private void buttonSearchCustomer_Click(object sender, EventArgs e)
        {
            // Input data validation
            string input = "";
            input = textBoxSearchById.Text.Trim();

            if (!Validator.Validator.IsValidID(input))
            {
                MessageBox.Show("Invalid Book ID", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBoxSearchById.Clear();
                textBoxSearchById.Focus();
                return;
            }

            Book bk = new Book();
            bk = bk.SearchBook(Convert.ToInt32(input));

            if (bk.ISBN != 0)
            {
                //messagebox.show(emp.employeeid + "," +
                //                emp.firstname + "," +
                //                emp.lastname + "," +
                //                emp.jobtitle);

                textBoxISBN.Text = bk.ISBN.ToString();
                textBoxTitle.Text = bk.Title;
                textBoxUnitPrice.Text = bk.UnitPrice.ToString();
                textBoxYear.Text = bk.YearPublished.ToString();
                textBoxQOH.Text = bk.QOH.ToString();
                textBoxCategoryID.Text = bk.CategoryId.ToString();
                textBoxPublisherID.Text = bk.PublisherId.ToString();

            }


            else
            {
                MessageBox.Show("Book Not Found", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonExitCustomer_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
