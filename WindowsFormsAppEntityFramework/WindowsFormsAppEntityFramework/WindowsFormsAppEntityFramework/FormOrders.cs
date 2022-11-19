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
    public partial class FormOrders : Form
    {
        public FormOrders()
        {
            InitializeComponent();

        }
        
       

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }




        HiTechManagementDBEntities database = new HiTechManagementDBEntities();


        // Real application.

        private void buttonSave_Click(object sender, EventArgs e)
        {
            var listCourse = from c in database.Orders
                             select c;

            //create a new order

            Order order = new Order();
            order.OderId = int.Parse(textBoxOrderId.Text);
            order.OrderDate = textBoxOrderDate.Text;
            //order.OrderDate = DateTime.Parse(textBoxOrderDate.Text);
            order.OrderType = textBoxOrderType.Text;
            order.RequiredDate = textBoxOrderDate.Text;
            order.ShippingDate = textBoxOrderDate.Text;
            //order.RequiredDate = DateTime.Parse(textBoxOrderDate.Text);
            //order.ShippingDate = DateTime.Parse(textBoxOrderDate.Text);
            order.StatusId = int.Parse(textBoxStatusId.Text);
            order.CustomerId = int.Parse(textBoxCustomerID.Text);
            order.EmployeeId = int.Parse(textBoxEmployeeId.Text);
            order.Payment = Convert.ToDecimal(textBoxPayment.Text);

            Order order1 = new Order();
            order1 = database.Orders.Find(int.Parse(textBoxOrderId.Text));
            if (order1 != null)
            {
                MessageBox.Show("OrderID already exists");
                textBoxOrderId.Clear();
                textBoxCustomerID.Clear();
                textBoxEmployeeId.Clear();
                textBoxOrderDate.Clear();
                textBoxOrderType.Clear();
                textBoxRequiredDate.Clear();
                textBoxShippingDate.Clear();
                textBoxStatusId.Clear();
                textBoxPayment.Clear();
            }
            else
            {
                database.Orders.Add(order);
                database.SaveChanges();
                MessageBox.Show("Order saved.");
            }


        }

        private void textBoxOrderDate_TextChanged(object sender, EventArgs e)
        {

        }

        private void buttonList_Click(object sender, EventArgs e)
        {
            //display the list of courses
            var listOrders = from o in database.Orders
                             select o;
            foreach (var o in listOrders)
            {
                ListViewItem item = new ListViewItem(o.OderId.ToString());
                
                item.SubItems.Add(o.OrderDate.ToString());
                item.SubItems.Add(o.OrderType.ToString());
                item.SubItems.Add(o.RequiredDate.ToString());
                item.SubItems.Add(o.ShippingDate.ToString());
                item.SubItems.Add(o.StatusId.ToString());
                item.SubItems.Add(o.CustomerId.ToString());
                item.SubItems.Add(o.EmployeeId.ToString());
                item.SubItems.Add(o.Payment.ToString());
                listView1.Items.Add(item);
               
            }
        }

        private void buttonUpdate_Click(object sender, EventArgs e)
        {
            //if you want to change course code make sure to validate the key that not exist in database because its primary key so, it sould be unique.

            Order orderUpdate = new Order();
            orderUpdate = database.Orders.Find(int.Parse(textBoxOrderId.Text));
            orderUpdate.OderId = int.Parse(textBoxOrderId.Text);
            orderUpdate.OrderDate = textBoxOrderDate.Text;
            orderUpdate.OrderType = textBoxOrderType.Text;
            orderUpdate.RequiredDate = textBoxRequiredDate.Text;
            orderUpdate.ShippingDate = textBoxShippingDate.Text;
            orderUpdate.StatusId = int.Parse(textBoxStatusId.Text);
            orderUpdate.CustomerId = int.Parse(textBoxCustomerID.Text);
            orderUpdate.EmployeeId = int.Parse(textBoxEmployeeId.Text);
            orderUpdate.Payment = Convert.ToDecimal(textBoxPayment.Text);
            //if you want to change course code make sure to validate the key that not exist in database because its primary key so, it sould be unique.
            database.SaveChanges();
            MessageBox.Show("RECORD UPDATED", "Confirmation");
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {

            Order orderDelete = new Order();
            orderDelete = database.Orders.Find(int.Parse(textBoxOrderId.Text));
            if (orderDelete != null)
            {
                database.Orders.Remove(orderDelete);
                database.SaveChanges();
                MessageBox.Show("Order Deleted","Confirmation");
            }

        }

        private void buttonSearch_Click(object sender, EventArgs e)
        {
            Order orderSearch = new Order();
            orderSearch = database.Orders.Find(int.Parse(textBoxSearchId.Text));
            if (orderSearch == null)
            {
                
                MessageBox.Show("No records Found!", "No records");
                return;
            }
            textBoxOrderId.Text = orderSearch.OderId.ToString() ;
            textBoxOrderDate.Text = orderSearch.OrderDate.ToString();
            textBoxOrderType.Text = orderSearch.OrderType.ToString();
            textBoxRequiredDate.Text = orderSearch.RequiredDate.ToString();
            textBoxShippingDate.Text = orderSearch.ShippingDate.ToString();
            textBoxStatusId.Text = orderSearch.StatusId.ToString();
            textBoxCustomerID.Text = orderSearch.CustomerId.ToString();
            textBoxEmployeeId.Text = orderSearch.EmployeeId.ToString();
            textBoxPayment.Text = orderSearch.Payment.ToString();
 
         
        }
    }
}
