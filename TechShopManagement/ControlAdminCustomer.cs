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
            this.dba = new DataBaseAccess();
        }

        private void ControlAdminCustomer_Load(object sender, EventArgs e)
        {
            this.Show();
        }
    }
}
