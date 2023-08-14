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

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.dgvAdminProduct.ClearSelection();
        }
    }
}
