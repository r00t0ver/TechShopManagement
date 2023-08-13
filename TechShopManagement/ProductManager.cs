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

namespace TechShopManagement
{
    public partial class ProductManager : Form
    {
        private void SqlServerStart()
        {
            SqlConnection sqlcon = new SqlConnection("Data Source=DESKTOP-2O79K10;Initial Catalog=TechShopManagement;User ID=sa;Password=p@$$w0rd");
            sqlcon.Open();
            SqlCommand sqlcom = new SqlCommand("select * from ProductList", sqlcon);
            SqlDataAdapter sda = new SqlDataAdapter(sqlcom);
            DataSet ds = new DataSet();
            sda.Fill(ds);
            this.dgvAddingProduct.DataSource = ds.Tables[0];
            sqlcon.Close();
        }
        public ProductManager()
        {
            InitializeComponent();
            SqlServerStart();
        }


    }
}
