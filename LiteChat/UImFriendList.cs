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
    public partial class UImFriendList : Form
    {
        private string myID, friendID,friendName;
        public UImFriendList()
        {
            InitializeComponent();
        }

        private void lbName_Click(object sender, EventArgs e)
        {
            UIchat chat = new UIchat(myID, friendID, friendName);
            chat.Show();
        }
        
        public Panel getPanel(string name,string id,string myId)
        {
            lbName.Text = name;
            this.myID = myId;
            this.friendID = id;
            this.friendName = name;
            return this.panel1;
        }
    }
}
