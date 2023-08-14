using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace TechShopManagement
{
    public partial class Seller : Form
    {
        private DataBaseAccess dba { set; get; }
        private void show()
        {
            try
            {
                var sql = "select * from ProductList";
                DataSet ds = this.dba.ExecuteQuery(sql);
                this.dgvAvailableProduct.DataSource = ds.Tables[0];
                this.dgvAvailableProduct.ClearSelection();

            }
            catch (Exception ex)
            {
                MessageBox.Show("error " + ex.Message);
            }
        }
        private void ShowCart()
        {
            try
            {
                var sql = "select * from ProductCartList";
                DataSet ds = this.dba.ExecuteQuery(sql);
                this.dvgProductCartList.DataSource = ds.Tables[0];
 

            }
            catch (Exception ex)
            {
                MessageBox.Show("error " + ex.Message);
            }
        }



        private void start()
        {
            cmbCategory.SelectedIndex = 3; 
        }
        private void watch()
        {
            timer1.Start();
            this.labelTime.Text = "Time: " + DateTime.Now.ToLongTimeString();
            this.labelDate.Text = "Date: " + DateTime.Now.ToLongDateString();
        }


        public Seller()
        {
            InitializeComponent();
            this.dba = new DataBaseAccess();
            show();
            ShowCart();
            start();
            watch();

        }




/*        private void button3_Click_1(object sender, EventArgs e)
        {


        }*/

        private void ckDiscount_CheckStateChanged(object sender, EventArgs e)
        {
            if (ckDiscount.Checked) { this.txtDiscount.Enabled = true; }
            else { this.txtDiscount.Enabled = false; }

        }

        private void txtSearchProduct_TextChanged(object sender, EventArgs e)
        {
            var sql = @"select * from ProductList where ProductName like '%"+this.txtSearchProduct.Text+"%';";
            DataSet ds = this.dba.ExecuteQuery(sql);
            this.dgvAvailableProduct.DataSource = ds.Tables[0];
        }

        private void btnClearSelection_Click(object sender, EventArgs e)
        {
            this.dgvAvailableProduct.ClearSelection();
        }



        private void timer1_Tick_1(object sender, EventArgs e)
        {
            this.labelTime.Text = "Time: " + DateTime.Now.ToLongTimeString();
            this.labelDate.Text = "Date:  " + DateTime.Now.ToLongDateString();
            timer1.Start();
        }

/*        private void panel7_Paint(object sender, PaintEventArgs e)
        {

        }*/

        private void dgvAvailableProduct_Click(object sender, EventArgs e)
        {
            try
            {
                this.txtProductId.Text = this.dgvAvailableProduct.CurrentRow.Cells["ProductId"].Value.ToString();
                this.txtBrandName.Text = this.dgvAvailableProduct.CurrentRow.Cells["BrandName"].Value.ToString();
                this.txtProductCategory.Text = this.dgvAvailableProduct.CurrentRow.Cells["ProductCategory"].Value.ToString();
                this.txtProductName.Text = this.dgvAvailableProduct.CurrentRow.Cells["ProductName"].Value.ToString();
                this.txtWarranty.Text = this.dgvAvailableProduct.CurrentRow.Cells["Warranty"].Value.ToString();
                this.txtProductPrice.Text = this.dgvAvailableProduct.CurrentRow.Cells["Price"].Value.ToString();
                this.txtProductQuantity.Text ="1";
                this.txtDescription.Text = this.dgvAvailableProduct.CurrentRow.Cells["Description"].Value.ToString();
            }
            catch(Exception ex) { MessageBox.Show("error: " + ex.Message); }
            

        }

        private void btnProductClear_Click(object sender, EventArgs e)
        {
            this.txtProductId.Text = "";
            this.txtBrandName.Text = "";
            this.txtProductCategory.Text = "";
            this.txtProductName.Text = " ";
            this.txtWarranty.Text = "";
            this.txtProductPrice.Text = "";
            this.txtProductQuantity.Text = "";
            this.txtDescription.Text = "";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.txtCustomerId.Text = "";
            this.txtCustomerName.Text = "";
            this.txtCustomerPhoneNumber.Text = "";
            this.txtCustomerAddress.Text = "";

        }

        private void btnAddToCart_Click(object sender, EventArgs e)
        {
            var sql = "select * from ProductCartList";
            DataSet ds = this.dba.ExecuteQuery(sql);
            //MessageBox.Show(this.dgvAvailableProduct.CurrentRow.Cells["ProductId"].Value.ToString());
            string id = this.dgvAvailableProduct.CurrentRow.Cells["ProductId"].Value.ToString();

            var sqlCart = "select * from ProductCartList where ProductId='" + id+"'";
            DataSet dsCart = this.dba.ExecuteQuery(sqlCart);
            int row = dsCart.Tables[0].Rows.Count;
            //MessageBox.Show(row.ToString());
            try
            {

                if (row == 1)
                {
                    DataSet preQ = this.dba.ExecuteQuery("select Quantity from ProductCartList where ProductId='" + id + "'");
                    string str = preQ.Tables[0].Rows[0][0].ToString();
                    int q = Convert.ToInt32(str) + 1;
                    sql = "UPDATE ProductCartList SET Quantity =" + q + "WHERE ProductId='" + id + "';";
                    this.dba.ExecuteQuery(sql);
                }          
                else
                {

                    double d = (Convert.ToDouble(this.txtProductPrice.Text)) * (Convert.ToDouble(this.txtProductQuantity.Text));
                    sql = "insert into ProductCartList values('" + this.txtProductId.Text + "','" + this.txtProductName.Text + "'," + this.txtProductPrice.Text + "," + this.txtProductQuantity.Text + "," + d + ");";
                    this.dba.ExecuteDMLQuery(sql);


                }
            }
            catch(Exception ex) { MessageBox.Show(ex.Message); }
            this.ShowCart();


        }

        private void btnShowCartProduct_Click(object sender, EventArgs e)
        {
            this.ShowCart();
        }

        private void btnDeleteCart_Click(object sender, EventArgs e)
        {
            this.dba.ExecuteQuery("delete from ProductCartList;");
            this.ShowCart();
        }
    }
}
