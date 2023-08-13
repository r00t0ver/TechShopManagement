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
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void imgPass_MouseDown(object sender, MouseEventArgs e)
        {
            this.txtPass.UseSystemPasswordChar = false;
            this.imgPass.Image = Properties.Resources.notShow;
        }

        private void imgPass_MouseUp(object sender, MouseEventArgs e)
        {
            this.txtPass.UseSystemPasswordChar = true;
            this.imgPass.Image = Properties.Resources.show;
        }
    }
}
