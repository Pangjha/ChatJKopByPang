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
    public partial class TextShow : Form
    {
        public TextShow()
        {
            InitializeComponent();
        }
        public Panel getPanel(String msg,String who)
        {
            if(who == "my")
            {
                messageTextBox.Dock = DockStyle.Right;
                messageTextBox.TextAlign = ContentAlignment.MiddleRight;
            }
            else
            {
                messageTextBox.Dock = DockStyle.Left;
                messageTextBox.TextAlign = ContentAlignment.MiddleLeft;
            }
            messageTextBox.Text = msg;
            return panel1;
        }
    }
}
