namespace WindowsFormsAppEntityFramework
{
    partial class FormOrders
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.textBoxOrderDate = new System.Windows.Forms.TextBox();
            this.buttonSave = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.orderDate = new System.Windows.Forms.Label();
            this.orderType = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.textBoxOrderType = new System.Windows.Forms.TextBox();
            this.requiredDate = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.textBoxRequiredDate = new System.Windows.Forms.TextBox();
            this.shippingDate = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.textBoxShippingDate = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.buttonSearch = new System.Windows.Forms.Button();
            this.buttonDelete = new System.Windows.Forms.Button();
            this.buttonUpdate = new System.Windows.Forms.Button();
            this.textBoxStatusId = new System.Windows.Forms.TextBox();
            this.StatusId = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxSearchId = new System.Windows.Forms.TextBox();
            this.listView1 = new System.Windows.Forms.ListView();
            this.buttonList = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.textBoxEmployeeId = new System.Windows.Forms.TextBox();
            this.CustomerId = new System.Windows.Forms.Label();
            this.textBoxCustomerID = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textBoxPayment = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.textBoxOrderId = new System.Windows.Forms.TextBox();
            this.columnHeader6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader7 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader8 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader9 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // textBoxOrderDate
            // 
            this.textBoxOrderDate.Location = new System.Drawing.Point(27, 93);
            this.textBoxOrderDate.Name = "textBoxOrderDate";
            this.textBoxOrderDate.Size = new System.Drawing.Size(100, 22);
            this.textBoxOrderDate.TabIndex = 0;
            this.textBoxOrderDate.TextChanged += new System.EventHandler(this.textBoxOrderDate_TextChanged);
            // 
            // buttonSave
            // 
            this.buttonSave.Location = new System.Drawing.Point(177, 19);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(83, 38);
            this.buttonSave.TabIndex = 1;
            this.buttonSave.Text = "Save";
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(187, 44);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 16);
            this.label1.TabIndex = 2;
            // 
            // orderDate
            // 
            this.orderDate.AutoSize = true;
            this.orderDate.Location = new System.Drawing.Point(24, 77);
            this.orderDate.Name = "orderDate";
            this.orderDate.Size = new System.Drawing.Size(83, 16);
            this.orderDate.TabIndex = 3;
            this.orderDate.Text = "Order Date";
            // 
            // orderType
            // 
            this.orderType.AutoSize = true;
            this.orderType.Location = new System.Drawing.Point(24, 129);
            this.orderType.Name = "orderType";
            this.orderType.Size = new System.Drawing.Size(86, 16);
            this.orderType.TabIndex = 6;
            this.orderType.Text = "Order Type";
            this.orderType.Click += new System.EventHandler(this.label3_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(350, 206);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(0, 13);
            this.label4.TabIndex = 5;
            // 
            // textBoxOrderType
            // 
            this.textBoxOrderType.Location = new System.Drawing.Point(27, 147);
            this.textBoxOrderType.Name = "textBoxOrderType";
            this.textBoxOrderType.Size = new System.Drawing.Size(100, 22);
            this.textBoxOrderType.TabIndex = 4;
            this.textBoxOrderType.TextChanged += new System.EventHandler(this.textBox2_TextChanged);
            // 
            // requiredDate
            // 
            this.requiredDate.AutoSize = true;
            this.requiredDate.Location = new System.Drawing.Point(24, 186);
            this.requiredDate.Name = "requiredDate";
            this.requiredDate.Size = new System.Drawing.Size(108, 16);
            this.requiredDate.TabIndex = 9;
            this.requiredDate.Text = "Required Date";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(358, 214);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(0, 13);
            this.label6.TabIndex = 8;
            // 
            // textBoxRequiredDate
            // 
            this.textBoxRequiredDate.Location = new System.Drawing.Point(27, 202);
            this.textBoxRequiredDate.Name = "textBoxRequiredDate";
            this.textBoxRequiredDate.Size = new System.Drawing.Size(100, 22);
            this.textBoxRequiredDate.TabIndex = 7;
            // 
            // shippingDate
            // 
            this.shippingDate.AutoSize = true;
            this.shippingDate.Location = new System.Drawing.Point(24, 243);
            this.shippingDate.Name = "shippingDate";
            this.shippingDate.Size = new System.Drawing.Size(105, 16);
            this.shippingDate.TabIndex = 12;
            this.shippingDate.Text = "Shipping Date";
            this.shippingDate.Click += new System.EventHandler(this.label7_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(427, 256);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(0, 13);
            this.label8.TabIndex = 11;
            // 
            // textBoxShippingDate
            // 
            this.textBoxShippingDate.Location = new System.Drawing.Point(27, 262);
            this.textBoxShippingDate.Name = "textBoxShippingDate";
            this.textBoxShippingDate.Size = new System.Drawing.Size(100, 22);
            this.textBoxShippingDate.TabIndex = 10;
            this.textBoxShippingDate.TextChanged += new System.EventHandler(this.textBox4_TextChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.textBoxOrderId);
            this.groupBox1.Controls.Add(this.textBoxPayment);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.textBoxEmployeeId);
            this.groupBox1.Controls.Add(this.CustomerId);
            this.groupBox1.Controls.Add(this.textBoxCustomerID);
            this.groupBox1.Controls.Add(this.buttonList);
            this.groupBox1.Controls.Add(this.listView1);
            this.groupBox1.Controls.Add(this.textBoxSearchId);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.buttonSearch);
            this.groupBox1.Controls.Add(this.buttonDelete);
            this.groupBox1.Controls.Add(this.buttonUpdate);
            this.groupBox1.Controls.Add(this.textBoxStatusId);
            this.groupBox1.Controls.Add(this.StatusId);
            this.groupBox1.Controls.Add(this.buttonSave);
            this.groupBox1.Controls.Add(this.shippingDate);
            this.groupBox1.Controls.Add(this.textBoxOrderDate);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.textBoxShippingDate);
            this.groupBox1.Controls.Add(this.orderDate);
            this.groupBox1.Controls.Add(this.requiredDate);
            this.groupBox1.Controls.Add(this.textBoxOrderType);
            this.groupBox1.Controls.Add(this.orderType);
            this.groupBox1.Controls.Add(this.textBoxRequiredDate);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(27, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(955, 478);
            this.groupBox1.TabIndex = 13;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Order Details";
            // 
            // buttonSearch
            // 
            this.buttonSearch.Location = new System.Drawing.Point(177, 250);
            this.buttonSearch.Name = "buttonSearch";
            this.buttonSearch.Size = new System.Drawing.Size(83, 36);
            this.buttonSearch.TabIndex = 17;
            this.buttonSearch.Text = "Search";
            this.buttonSearch.UseVisualStyleBackColor = true;
            this.buttonSearch.Click += new System.EventHandler(this.buttonSearch_Click);
            // 
            // buttonDelete
            // 
            this.buttonDelete.Location = new System.Drawing.Point(177, 134);
            this.buttonDelete.Name = "buttonDelete";
            this.buttonDelete.Size = new System.Drawing.Size(83, 36);
            this.buttonDelete.TabIndex = 16;
            this.buttonDelete.Text = "Delete";
            this.buttonDelete.UseVisualStyleBackColor = true;
            this.buttonDelete.Click += new System.EventHandler(this.buttonDelete_Click);
            // 
            // buttonUpdate
            // 
            this.buttonUpdate.Location = new System.Drawing.Point(177, 77);
            this.buttonUpdate.Name = "buttonUpdate";
            this.buttonUpdate.Size = new System.Drawing.Size(83, 38);
            this.buttonUpdate.TabIndex = 15;
            this.buttonUpdate.Text = "Update";
            this.buttonUpdate.UseVisualStyleBackColor = true;
            this.buttonUpdate.Click += new System.EventHandler(this.buttonUpdate_Click);
            // 
            // textBoxStatusId
            // 
            this.textBoxStatusId.Location = new System.Drawing.Point(27, 318);
            this.textBoxStatusId.Name = "textBoxStatusId";
            this.textBoxStatusId.Size = new System.Drawing.Size(100, 22);
            this.textBoxStatusId.TabIndex = 13;
            // 
            // StatusId
            // 
            this.StatusId.AutoSize = true;
            this.StatusId.Location = new System.Drawing.Point(24, 302);
            this.StatusId.Name = "StatusId";
            this.StatusId.Size = new System.Drawing.Size(67, 16);
            this.StatusId.TabIndex = 14;
            this.StatusId.Text = "Status Id";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(174, 191);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(98, 16);
            this.label2.TabIndex = 18;
            this.label2.Text = "Search by Id:";
            // 
            // textBoxSearchId
            // 
            this.textBoxSearchId.Location = new System.Drawing.Point(177, 217);
            this.textBoxSearchId.Name = "textBoxSearchId";
            this.textBoxSearchId.Size = new System.Drawing.Size(100, 22);
            this.textBoxSearchId.TabIndex = 19;
            // 
            // listView1
            // 
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader6,
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4,
            this.columnHeader5,
            this.columnHeader7,
            this.columnHeader8,
            this.columnHeader9});
            this.listView1.GridLines = true;
            this.listView1.HideSelection = false;
            this.listView1.Location = new System.Drawing.Point(283, 77);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(653, 329);
            this.listView1.TabIndex = 20;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            // 
            // buttonList
            // 
            this.buttonList.Location = new System.Drawing.Point(560, 33);
            this.buttonList.Name = "buttonList";
            this.buttonList.Size = new System.Drawing.Size(129, 38);
            this.buttonList.TabIndex = 21;
            this.buttonList.Text = "List Orders";
            this.buttonList.UseVisualStyleBackColor = true;
            this.buttonList.Click += new System.EventHandler(this.buttonList_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(24, 414);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(94, 16);
            this.label5.TabIndex = 25;
            this.label5.Text = "Employee Id";
            // 
            // textBoxEmployeeId
            // 
            this.textBoxEmployeeId.Location = new System.Drawing.Point(27, 433);
            this.textBoxEmployeeId.Name = "textBoxEmployeeId";
            this.textBoxEmployeeId.Size = new System.Drawing.Size(100, 22);
            this.textBoxEmployeeId.TabIndex = 24;
            // 
            // CustomerId
            // 
            this.CustomerId.AutoSize = true;
            this.CustomerId.Location = new System.Drawing.Point(24, 357);
            this.CustomerId.Name = "CustomerId";
            this.CustomerId.Size = new System.Drawing.Size(89, 16);
            this.CustomerId.TabIndex = 23;
            this.CustomerId.Text = "Customer Id";
            // 
            // textBoxCustomerID
            // 
            this.textBoxCustomerID.Location = new System.Drawing.Point(27, 373);
            this.textBoxCustomerID.Name = "textBoxCustomerID";
            this.textBoxCustomerID.Size = new System.Drawing.Size(100, 22);
            this.textBoxCustomerID.TabIndex = 22;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(174, 305);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(67, 16);
            this.label3.TabIndex = 27;
            this.label3.Text = "Payment";
            // 
            // textBoxPayment
            // 
            this.textBoxPayment.Location = new System.Drawing.Point(177, 321);
            this.textBoxPayment.Name = "textBoxPayment";
            this.textBoxPayment.Size = new System.Drawing.Size(100, 22);
            this.textBoxPayment.TabIndex = 26;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(24, 18);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(63, 16);
            this.label7.TabIndex = 29;
            this.label7.Text = "Order Id";
            // 
            // textBoxOrderId
            // 
            this.textBoxOrderId.Location = new System.Drawing.Point(27, 37);
            this.textBoxOrderId.Name = "textBoxOrderId";
            this.textBoxOrderId.Size = new System.Drawing.Size(100, 22);
            this.textBoxOrderId.TabIndex = 28;
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "ID";
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Date";
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Type";
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Exp. Dt";
            this.columnHeader3.Width = 77;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Arr.Dt";
            this.columnHeader4.Width = 66;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "StatusId";
            this.columnHeader5.Width = 77;
            // 
            // columnHeader7
            // 
            this.columnHeader7.Text = "CustomerId";
            this.columnHeader7.Width = 91;
            // 
            // columnHeader8
            // 
            this.columnHeader8.Text = "EmployeeId";
            this.columnHeader8.Width = 87;
            // 
            // columnHeader9
            // 
            this.columnHeader9.Text = "Payment";
            this.columnHeader9.Width = 72;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(994, 502);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label4);
            this.Name = "Form1";
            this.Text = "Form1";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxOrderDate;
        private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label orderDate;
        private System.Windows.Forms.Label orderType;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBoxOrderType;
        private System.Windows.Forms.Label requiredDate;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox textBoxRequiredDate;
        private System.Windows.Forms.Label shippingDate;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox textBoxShippingDate;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox textBoxStatusId;
        private System.Windows.Forms.Label StatusId;
        private System.Windows.Forms.Button buttonSearch;
        private System.Windows.Forms.Button buttonDelete;
        private System.Windows.Forms.Button buttonUpdate;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBoxEmployeeId;
        private System.Windows.Forms.Label CustomerId;
        private System.Windows.Forms.TextBox textBoxCustomerID;
        private System.Windows.Forms.Button buttonList;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.TextBox textBoxSearchId;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBoxPayment;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox textBoxOrderId;
        private System.Windows.Forms.ColumnHeader columnHeader6;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.ColumnHeader columnHeader7;
        private System.Windows.Forms.ColumnHeader columnHeader8;
        private System.Windows.Forms.ColumnHeader columnHeader9;
    }
}

