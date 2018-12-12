using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LiteChat
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

     

        private void register_Click(object sender, EventArgs e)
        {
         
        }

        private void LoginButton_Click(object sender, EventArgs e)
        {
            if (userID.Text == "" || password.Text == "")
            {
                MessageBox.Show("กรุณากรอกข้อมูลให้ครบถ้วน");
            }
            else if (LoginService.searchUser(userID.Text, password.Text) == null)
            {
                MessageBox.Show("Username หรือ Password ไม่ถูกต้อง");
            }
            else
            {

                UImain main = new UImain(userID.Text);
                main.Show();
                this.Visible = false;

            }
        }

        private void RegisterButton_Click(object sender, EventArgs e)
        {
            Register r = new Register();
            r.Visible = true;
            this.Visible = false;
        }

        private void Exit_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

       
    }
}
