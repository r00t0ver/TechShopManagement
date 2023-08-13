using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace TechShopManagement
{
    public partial class Seller : Form
    {
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
            start();
            watch();

        }




        private void button3_Click_1(object sender, EventArgs e)
        {
            SqlConnection sqlcon = new SqlConnection("Data Source=DESKTOP-2O79K10;Initial Catalog=TechShopManagement;User ID=sa;Password=p@$$w0rd");
            sqlcon.Open();
            SqlCommand sqlcom = new SqlCommand("select * from ProductList", sqlcon);
            SqlDataAdapter sda = new SqlDataAdapter(sqlcom);
            DataSet ds = new DataSet();
            sda.Fill(ds);
            this.dgvAvailableProduct.DataSource = ds.Tables[0];
            sqlcon.Close();

        }

        private void ckDiscount_CheckStateChanged(object sender, EventArgs e)
        {
            if (ckDiscount.Checked) { this.txtDiscount.Enabled = true; }
            else { this.txtDiscount.Enabled = false; }

        }

        private void txtSearchProduct_TextChanged(object sender, EventArgs e)
        {
            if (this.cmbCategory.SelectedIndex == 3)
            {
                SqlConnection sqlcon = new SqlConnection("Data Source=DESKTOP-2O79K10;Initial Catalog=TechShopManagement;User ID=sa;Password=p@$$w0rd");
                sqlcon.Open();
                SqlCommand sqlcom = new SqlCommand(@"select * from ProductList where ProductName like  '%" + this.txtSearchProduct.Text + "%';", sqlcon);
                SqlDataAdapter sda = new SqlDataAdapter(sqlcom);
                DataSet ds = new DataSet();
                sda.Fill(ds);
                this.dgvAvailableProduct.DataSource = ds.Tables[0];
                sqlcon.Close();

            }
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
    }
}
