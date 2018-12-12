using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace LiteChat
{
    public partial class UIchat : Form
    {
        private string myID, friendID;
        public UIchat()
        {
            InitializeComponent();
        }
        public UIchat(string myID, string friendID, string friendName)
        {
            InitializeComponent();
            this.myID = myID;
            this.friendID = friendID;
            this.Text = friendName;
        }
        private void backgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            MessageService.serveMessageIncoming(new User(friendID), new User(myID));
            if (this.backgroundWorker.CancellationPending)
            {
                e.Cancel = true;
                return;
            }
            if (this.displayMessageWorker.CancellationPending)
            {
                e.Cancel = true;
                return;
            }
        }

        private void runBackgroundWorker(object sender, EventArgs e)
        {
            if (!backgroundWorker.IsBusy)
            {
                backgroundWorker.RunWorkerAsync();
            }

            if (!displayMessageWorker.IsBusy)
            {
                displayMessageWorker.RunWorkerAsync();
            }


            MessageService.fetchAllMessage(new User(friendID), new User(myID));

        }

        private void sendButtonClick(object sender, EventArgs e)
        {

            if (InternetConnection.checkConnectionInternet() == true)
            {
                Message msg = new Message(textMsg.Text, myID, friendID);
                MessageService.InsertMessage(msg);
                addMsgBox(msg, "my");
                textMsg.Clear();
            }
            else
            {
                showMessage();
            }

        }

        private void sendEmoClick(object sender, EventArgs e)
        {

        }

        private void displayMessageWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                while (true)
                {

                    if (MessageService.getMessage().Count > 0)
                    {
                        Message msg = MessageService.getMessage().Dequeue();
                        //Console.WriteLine(msg.MessageText);
                        if (!msg.Sender.Equals(myID))
                        {
                            addMsgBox(msg, "");
                        }
                        else
                        {
                            addMsgBox(msg, "my");
                        }
                    }
                    if (this.displayMessageWorker.CancellationPending)
                    {
                        e.Cancel = true;
                        return;
                    }


                }
            }catch(Exception ee)
            {

            }
        }
        private void showMessage()
        {
            MessageBox.Show("No network connection");
        }

        private void UIchat_Load(object sender, EventArgs e)
        {
            MessageService.fetchAllMessage(new User(friendID), new User(myID));
            if (!backgroundWorker.IsBusy)
            {
                backgroundWorker.RunWorkerAsync();
            }

            if (!displayMessageWorker.IsBusy)
            {
                displayMessageWorker.RunWorkerAsync();
            }

            
        }

        private void stopWorker(object sender, FormClosingEventArgs e)
        {

            backgroundWorker.Dispose();
            displayMessageWorker.Dispose();
        }

        private void Exit_Click(object sender, EventArgs e)
        {
           this.Visible = false;
        }

        private void addMsgBox(Message msg, String side)
        {
            try
            {
              
                    flow.BeginInvoke(new Action(() =>
                {
                    TextShow textShow = new TextShow();
                    Panel msgbox = textShow.getPanel(msg.MessageText, side);
                    flow.Controls.Add(msgbox);
                    textShow.Dispose();
                }));
                }
            
            catch (Exception e)
            {

            }

        }
    }
}
