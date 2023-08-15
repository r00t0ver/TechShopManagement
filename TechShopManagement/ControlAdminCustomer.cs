using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TechShopManagement
{
    public partial class ControlAdminCustomer : UserControl
    {
        private DataBaseAccess dba { get; set; }
        private void Show()
        {
            try
            {
                var sql = "select * from CustomerList";
                DataSet ds = this.dba.ExecuteQuery(sql);
                this.dgvAdminCustomer.DataSource = ds.Tables[0];
                this.dgvAdminCustomer.ClearSelection();

            }
            catch (Exception ex)
            {
                MessageBox.Show("error " + ex.Message);
            }
        }
    
        public ControlAdminCustomer()
        {
            InitializeComponent();
            this.cbmSearchCustomerBy.SelectedIndex = 1;
            this.dba = new DataBaseAccess();
        }

        private void ControlAdminCustomer_Load(object sender, EventArgs e)
        {
            this.Show();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {

            try
            {
                var quer = "select * from CustomerList where CustomerId ='" + this.txtCustomerId.Text + "';";
                var dt = this.dba.ExecuteQueryTable(quer);
                if (dt.Rows.Count == 1)
                {
                    var sql = @"update CustomerList set
	                        CustomerName='" + this.txtCustomerName.Text + @"',
	                        Address='" + this.txtCustomerAddress.Text + @"',
	                        PhoneNumber='" + this.txtPhoneNumber.Text + @"',
	                        TotalExpense='" + this.txtTotalExpense.Text + @"',',
                            where CustomerId ='" + this.txtCustomerId.Text + "';";
                    var count = this.dba.ExecuteDMLQuery(sql);
                    if (count == 1)
                    {
                        MessageBox.Show("Updated Successfully");
                    }
                    else
                    {
                        MessageBox.Show("Updated Unsuccessfull");
                    }
                    this.Show();
                }
                else
                {
                    //insert
                    var sql = "insert into CustomerList values('" + this.txtCustomerId.Text + "','" + this.txtCustomerName.Text + "','" + this.txtCustomerAddress.Text + "','" + this.txtPhoneNumber.Text + "','" + Convert.ToDouble(this.txtTotalExpense.Text) + "');";
                    var count = this.dba.ExecuteDMLQuery(sql);
                    if (count == 1)
                    {
                        MessageBox.Show("Inserted Properly");
                    }
                    else
                    {
                        MessageBox.Show("Inserted Failed");
                    }
                }
                this.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void dgvAdminCustomer_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                this.txtCustomerId.Text = this.dgvAdminCustomer.CurrentRow.Cells["CustomerId"].Value.ToString();
                this.txtCustomerName.Text = this.dgvAdminCustomer.CurrentRow.Cells["CustomerName"].Value.ToString();
                this.txtCustomerAddress.Text = this.dgvAdminCustomer.CurrentRow.Cells["Address"].Value.ToString();
                this.txtPhoneNumber.Text = this.dgvAdminCustomer.CurrentRow.Cells["PhoneNumber"].Value.ToString();
                this.txtTotalExpense.Text = this.dgvAdminCustomer.CurrentRow.Cells["TotalExpense"].Value.ToString();
            }
            catch (Exception ex) { MessageBox.Show("error: " + ex.Message); }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            this.txtCustomerId.Clear();
            this.txtCustomerName.Clear();
            this.txtCustomerAddress.Clear();
            this.txtPhoneNumber.Clear();
            this.txtTotalExpense.Clear();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                string id = this.dgvAdminCustomer.CurrentRow.Cells["CustomerId"].Value.ToString();

                if (id.Length != 0)
                {
                    this.dba.ExecuteQuery("DELETE FROM CustomerList WHERE CustomerId='" + id + "';");
                    MessageBox.Show("Deleted");
                }
                else
                {
                    MessageBox.Show("First Select a row");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            Show();
        }

        private void txtSearchCustomer_TextChanged(object sender, EventArgs e)
        {
            var sql = @"select * from CustomerList where CustomerPhoneNumber like '%" + this.txtSearchCustomer.Text + "%';";
            DataSet ds = this.dba.ExecuteQuery(sql);
            this.dgvAdminCustomer.DataSource = ds.Tables[0];
        }
    }
}
