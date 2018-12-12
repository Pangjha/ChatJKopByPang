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
    public partial class UImain : Form
    {

        private User user;
        private string userID="123456";
        public UImain(String userID)
        {
            InitializeComponent();
            this.user = UserService.getUser(userID);
            this.userID = userID;
            name.Text = user.Username;
        }
      

        private void UImain_Load(object sender, EventArgs e)
        {
            loadFriendList();

        }
        private List<FriendData> showListFriend(string userID)
        {

            return MainService.getAllFriend(userID);
        }
        public void loadFriendList()
        {
            tvFriendFlow.Controls.Clear();

            var friList = showListFriend(userID);
            while (friList.Count > 0)
            {
                UImFriendList uif = new UImFriendList();
                Panel x = uif.getPanel(friList[0].FriName, friList[0].FriID,userID);

                tvFriendFlow.Controls.Add(x);

 
                friList.RemoveAt(0);
            }
        }

      

        private void editUser(object sender, EventArgs e)
        {
            EditUser edit = new EditUser(user);
            edit.Show();
        }

        private void closeAccount(object sender, EventArgs e)
        {
            CloseAccount c = new CloseAccount(userID);
            c.Show();
        }

        private void addFriend(object sender, EventArgs e)
        {
            var friList = showListFriend(userID);

            if (FriendID.Text.Equals(userID))
            {
                MessageBox.Show("คุณไม่สามารถเพิ่มเพื่อนตัวเองได้!", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!MainService.SearchFromList(FriendID.Text, friList))
            {
                MessageBox.Show("เป็นเพื่อนกันอยู่แล้ว", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (!MainService.checkIfFriendExist(FriendID.Text))
            {
                MessageBox.Show("ไม่พบไอดีนี้!", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            MainService.insertFriend(userID, FriendID.Text);
            loadFriendList();
        }

        private void ExitButton_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }
    }
    
}
