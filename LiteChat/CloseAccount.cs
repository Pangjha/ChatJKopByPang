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
    public partial class CloseAccount : Form
    {
        private String id;
        public CloseAccount(String id)
        {
            InitializeComponent();
            this.id = id;
        }

        private void deleteUser(object sender, EventArgs e)
        {         
            if (UserService.deleteUser(id))
            {
                MessageBox.Show("Success");
                Environment.Exit(0);

            }
            else
            {
                MessageBox.Show("ปิดบัญชีไม่สำเร้จ");
            }

        }


     

        private void CloseAccount_FormClosing(object sender, FormClosingEventArgs e)
        {
            Login l = new Login();
            l.Show();
        }

        private void confirmButton_Click(object sender, EventArgs e)
        {
            if (UserService.deleteUser(id))
            {
                MessageBox.Show("Success");
                Environment.Exit(0);

            }
            else
            {
                MessageBox.Show("ปิดบัญชีไม่สำเร้จ");
            }
        }

        private void back_Click_1(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
}
