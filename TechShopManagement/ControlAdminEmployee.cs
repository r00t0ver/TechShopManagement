using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace TechShopManagement
{
    public partial class ControlAdminEmployee : UserControl
    {
        private DataBaseAccess dba { get; set; }
        private void show()
        {
            try
            {
                var sql = "select * from EmployeeList";
                DataSet ds = this.dba.ExecuteQuery(sql);
                this.dgvAdminEmployee.DataSource = ds.Tables[0];
                this.dgvAdminEmployee.ClearSelection();

            }
            catch(Exception ex)
            {
                MessageBox.Show("error " + ex.Message);
            }
        }
        public ControlAdminEmployee()
        {
            InitializeComponent();
            this.dba=new DataBaseAccess();
        }


        private void ControlAdminEmployee_Load(object sender, EventArgs e)
        {
            show();
        }

        private void button3_Click(object sender, EventArgs e)
        {

        }
    }
}
