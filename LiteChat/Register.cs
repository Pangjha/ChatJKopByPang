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
    public partial class Register : Form
    {
        public Register()
        {
            InitializeComponent();
        }

        private void register(object sender, EventArgs e)
        {
            if (checkUserID())
            {
                MessageBox.Show("UserID ซ้ำ!!.");               
            }
            else if (checkNull())
            {
                MessageBox.Show("กรุณากรอกข้อมูลให้ครบ");
            }
            else if (checkLengthPassword())
            {
                MessageBox.Show("กรุณาป้อน Password 8 ตัว");
            }
            else if (checkMatch())
            {
                MessageBox.Show("กรุณาป้อน Password ให้ตรงกัน");
            }
            else
            {
                User user = new User(txtUserID.Text, txtName.Text, txtPassword.Text);
                RegisterService.insertUser(user);
                MessageBox.Show("Success");
                txtName.Clear();
                txtPassword.Clear();
                txtRepassword.Clear();
                txtUserID.Clear();
            }
        }

        private void back(object sender, EventArgs e)
        {
            this.Visible = false;
            Login login = new Login();
            login.Visible = true;
        }
        private Boolean checkUserID()
        {
            if (RegisterService.getUser(txtUserID.Text))
            {
                return true;
            }
            return false;
        }
        private Boolean checkNull()
        {
            if (txtUserID.Text == "" || txtName.Text == "" 
                || txtPassword.Text == "" || txtRepassword.Text == "")
            {
                return true;
            }
            return false;
        }
        private Boolean checkMatch()
        {
            if ( txtPassword.Text == txtRepassword.Text)
            {
                return false;
            }
            return true;
        }
        private Boolean checkLengthPassword()
        {
            if (txtPassword.Text.Length<8)
            {
                return true;
            }
            return false;
        }

    }
}
