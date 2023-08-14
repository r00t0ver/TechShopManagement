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
    
    public partial class Admin : Form
    {
        private DataBaseAccess DBA { get; set; }
        public Admin()
        {

            InitializeComponent();
            
        }

        private void employeeManagementToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ControlAdminEmployee emp=new ControlAdminEmployee();
            panelAdmin.Controls.Add(emp);
            emp.Dock = DockStyle.Fill;
            emp.BringToFront();
            emp.Show();
            
           

        }

        private void productManagementToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ControlAdminProduct productManager = new ControlAdminProduct();
            panelAdmin.Controls.Add(productManager);
            productManager.Dock = DockStyle.Fill;
            productManager.BringToFront();
            productManager.Show();
        }

        private void customerManagementToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ControlAdminCustomer customer = new ControlAdminCustomer();
            panelAdmin.Controls.Add(customer);
            customer.Dock = DockStyle.Fill;
            customer.BringToFront();
            customer.Show();
        }


    }
}
