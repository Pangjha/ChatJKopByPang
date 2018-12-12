using System;
using System.Windows.Forms;

namespace LiteChat
{
    public partial class EditUser : Form
    {
        User user;
        public EditUser(User user)
        {
            InitializeComponent();
            name.Text = user.Username;
            Password.Text = user.Password;
            CfPassword.Text = user.Password;
            this.user = user;

        }

        private void back(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void inputName_Click(object sender, EventArgs e)
        {
            String Name = name.Text.ToString();
            if (checkNullName(Name))
            {
                MessageBox.Show("กรุณากรอก Name");
            }
            else
            {

                user.Username = name.Text.ToString();
                EditUserService edt = new EditUserService();
                edt.editUser(user);
                MessageBox.Show("Success");

            }
        }

        private void inputPassword_Click(object sender, EventArgs e)
        {
            String password = Password.Text.ToString();
            String password1 = CfPassword.Text.ToString();
            if(CheckNullPassword(password, password1))
            {
                MessageBox.Show("Success");
            }
            else
            {
                if(checkMatch(password, password1))
                {
                    if (checkLength(password))
                    {
                        user.Password = Password.Text.ToString();
                        EditUserService edt = new EditUserService();
                        edt.editUser(user);
                        MessageBox.Show("Success");
                    }
                    else
                    {
                        MessageBox.Show("กรุณากรอก Password ให้อยู่ในระหว่าง 8-16 ตัว");
                    }
                }
                else
                {
                    MessageBox.Show("กรุณากรอก Password ให้ตรงกัน");
                }
            }
        }

        public Boolean CheckNullPassword(String password, String repassword)
        {
            if (password.Equals("")||repassword.Equals(""))
            {
                return true;
            }
            else
            {
                return false;
            }
             
        }
        public Boolean checkMatch(String password, String repassword)
        {
            if (password.Equals(repassword))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public Boolean checkLength(String password)
        {
            if (password.Length>=8 && password.Length <= 16)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public Boolean checkNullName(String name)
        {
            if (name.Equals(""))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private void ExitButton_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
}
