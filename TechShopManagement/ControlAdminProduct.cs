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
    public partial class ControlAdminProduct : UserControl
    {
        private  DataBaseAccess dba { get; set; }
        private void Show()
        {
            try
            {
                var sql = "select * from ProductList";
                DataSet ds = this.dba.ExecuteQuery(sql);
                this.dgvAdminProduct.DataSource = ds.Tables[0];
                

            }
            catch (Exception ex)
            {
                MessageBox.Show("error " + ex.Message);
            }
            this.dgvAdminProduct.ClearSelection();
        }
        public ControlAdminProduct()
        {
            InitializeComponent();
            this.dba=new DataBaseAccess();
            this.Show();
            

        }

        private void ControlAdminProduct_Load(object sender, EventArgs e)
        {
            this.dgvAdminProduct.ClearSelection();
        }



        private void button1_Click(object sender, EventArgs e)
        {
            this.dgvAdminProduct.ClearSelection();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                var quer = "select * from ProductList where ProductId ='" + this.txtProductId.Text + "';";
                var dt = this.dba.ExecuteQueryTable(quer);
                if (dt.Rows.Count == 1)
                {
                    var sql = @"update ProductList set
	                        BrandName='" + this.txtBrandName + @"',
	                        ProductCategory='" + this.txtProductCategory.Text + @"',
	                        ProductName='" + this.txtProductName.Text + @"',
	                        Warranty='" + this.txtWarranty.Text + @"',
	                        Price='" + this.txtPrice.Text + @"',',
	                        Quantity='" + this.txtQuantity.Text + @"',',
	                        Description='" + this.txtDescription.Text + @"',',
                            where ProductId ='" + this.txtProductId.Text + "';";
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
                    var sql = "insert into ProductList values('" + this.txtProductId.Text + "','" + this.txtBrandName.Text + "','" + this.txtProductCategory.Text + "','" + this.txtProductName.Text + "'," + Convert.ToInt32(this.txtWarranty.Text) + "," + Convert.ToDouble(this.txtPrice.Text) + "," + Convert.ToInt32(this.txtQuantity.Text) + ",'" + this.txtDescription.Text + "');";
                    var count = this.dba.ExecuteDMLQuery(sql);

                    if (count == 1)
                        MessageBox.Show("Data saved properly.");
                    else
                        MessageBox.Show("Failure While saving the data");

                }
                this.Show();
            }
            catch (Exception exc)
            {
                MessageBox.Show("Error: " + exc.Message);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                string id = this.dgvAdminProduct.CurrentRow.Cells["ProductId"].Value.ToString();

                if (id.Length != 0)
                {
                    this.dba.ExecuteQuery("DELETE FROM ProductList WHERE ProductId='" + id + "';");
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

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            var sql = @"select * from ProductList where ProductName like '%" + this.txtSearchProduct.Text + "%';";
            DataSet ds = this.dba.ExecuteQuery(sql);
            this.dgvAdminProduct.DataSource = ds.Tables[0];
        }

        private void dgvAdminProduct_Click(object sender, EventArgs e)
        {
            try
            {
                this.txtProductId.Text = this.dgvAdminProduct.CurrentRow.Cells["ProductId"].Value.ToString();
                this.txtBrandName.Text = this.dgvAdminProduct.CurrentRow.Cells["BrandName"].Value.ToString();
                this.txtProductCategory.Text = this.dgvAdminProduct.CurrentRow.Cells["ProductCategory"].Value.ToString();
                this.txtProductName.Text = this.dgvAdminProduct.CurrentRow.Cells["ProductName"].Value.ToString();
                this.txtWarranty.Text = this.dgvAdminProduct.CurrentRow.Cells["Warranty"].Value.ToString();
                this.txtPrice.Text = this.dgvAdminProduct.CurrentRow.Cells["Price"].Value.ToString();
                this.txtQuantity.Text = this.dgvAdminProduct.CurrentRow.Cells["Quantity"].Value.ToString(); ;
                this.txtDescription.Text = this.dgvAdminProduct.CurrentRow.Cells["Description"].Value.ToString();

            }
            catch (Exception ex) { MessageBox.Show("error: " + ex.Message); }
        }

        private void btnClearField_Click(object sender, EventArgs e)
        {
            this.txtProductId.Clear();
            this.txtBrandName.Clear();
            this.txtProductCategory.Clear();
            this.txtProductName.Clear();
            this.txtWarranty.Clear();
            this.txtPrice.Clear();
            this.txtQuantity.Clear();
            this.txtDescription.Clear();
        }
    }
}
