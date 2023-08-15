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
        private DataBaseAccess dba { get; set; }
        public Login()
        {
            InitializeComponent();
            this.dba=new DataBaseAccess();
        }

        private void imgPass_MouseDown(object sender, MouseEventArgs e)
        {
            this.txtPassword.UseSystemPasswordChar = false;
            this.imgPass.Image = Properties.Resources.notShow;
        }

        private void imgPass_MouseUp(object sender, MouseEventArgs e)
        {
            this.txtPassword.UseSystemPasswordChar = true;
            this.imgPass.Image = Properties.Resources.show;
        }



        private void btnLogin_Click(object sender, EventArgs e)
        {
            if(this.txtEmployeeId.Text==""||this.txtPassword.Text=="")
            {
                MessageBox.Show("Fill All the information first");
            }
            string id=this.txtEmployeeId.Text;
            string pass = this.txtPassword.Text;
            var sql = "select * from EmployeeList where EmployeeId='" + id + "';";
            DataSet dataSet=this.dba.ExecuteQuery(sql);
            int count = dataSet.Tables[0].Rows.Count;   
            if(count==0) { MessageBox.Show("Account not found"); }
            else
            {
                if (pass == dataSet.Tables[0].Rows[0][1].ToString())
                {
                    string role = dataSet.Tables[0].Rows[0][3].ToString();

                    if(role == "Admin") { new Admin(dataSet.Tables[0].Rows[0][0].ToString(), dataSet.Tables[0].Rows[0][2].ToString()).Show(); }
                    else if(role == "Seller") {  new Seller(dataSet.Tables[0].Rows[0][0].ToString(), dataSet.Tables[0].Rows[0][2].ToString()).Show(); }
                    else if( role =="Product Manager") { new ProductManager(dataSet.Tables[0].Rows[0][0].ToString(), dataSet.Tables[0].Rows[0][2].ToString()).Show();  }
                    else { MessageBox.Show("Error occur"); }
                }
                else
                {
                    MessageBox.Show("Wrong Password");
                    return;
                }
            }
        }
    }
}
