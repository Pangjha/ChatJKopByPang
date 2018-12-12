namespace LiteChat
{
    partial class TextShow
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.flow = new System.Windows.Forms.FlowLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.messageTextBox = new System.Windows.Forms.Label();
            this.flow.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // flow
            // 
            this.flow.AutoScroll = true;
            this.flow.BackColor = System.Drawing.Color.Gainsboro;
            this.flow.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.flow.Controls.Add(this.panel1);
            this.flow.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flow.Location = new System.Drawing.Point(26, 28);
            this.flow.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.flow.Name = "flow";
            this.flow.Size = new System.Drawing.Size(570, 345);
            this.flow.TabIndex = 3;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.MistyRose;
            this.panel1.Controls.Add(this.messageTextBox);
            this.panel1.Location = new System.Drawing.Point(2, 2);
            this.panel1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(542, 31);
            this.panel1.TabIndex = 0;
            // 
            // messageTextBox
            // 
            this.messageTextBox.BackColor = System.Drawing.Color.MistyRose;
            this.messageTextBox.Dock = System.Windows.Forms.DockStyle.Right;
            this.messageTextBox.Font = new System.Drawing.Font("TH SarabunPSK", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.messageTextBox.Location = new System.Drawing.Point(72, 0);
            this.messageTextBox.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.messageTextBox.Name = "messageTextBox";
            this.messageTextBox.Size = new System.Drawing.Size(470, 31);
            this.messageTextBox.TabIndex = 0;
            this.messageTextBox.Text = "\"test\"";
            this.messageTextBox.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // TextShow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(621, 402);
            this.Controls.Add(this.flow);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "TextShow";
            this.Text = "TextShow";
            this.flow.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flow;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label messageTextBox;
    }
}