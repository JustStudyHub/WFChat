namespace Client
{
    partial class Form1
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
            this.rtb_MsgBox = new System.Windows.Forms.RichTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tb_UserName = new System.Windows.Forms.TextBox();
            this.btn_JoinChat = new System.Windows.Forms.Button();
            this.btn_SendMsg = new System.Windows.Forms.Button();
            this.tb_sendMsg = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // rtb_MsgBox
            // 
            this.rtb_MsgBox.Location = new System.Drawing.Point(12, 56);
            this.rtb_MsgBox.Name = "rtb_MsgBox";
            this.rtb_MsgBox.Size = new System.Drawing.Size(781, 353);
            this.rtb_MsgBox.TabIndex = 0;
            this.rtb_MsgBox.Text = "";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "User Name";
            // 
            // tb_UserName
            // 
            this.tb_UserName.Location = new System.Drawing.Point(12, 30);
            this.tb_UserName.Name = "tb_UserName";
            this.tb_UserName.Size = new System.Drawing.Size(130, 20);
            this.tb_UserName.TabIndex = 2;
            // 
            // btn_JoinChat
            // 
            this.btn_JoinChat.Location = new System.Drawing.Point(148, 30);
            this.btn_JoinChat.Name = "btn_JoinChat";
            this.btn_JoinChat.Size = new System.Drawing.Size(75, 23);
            this.btn_JoinChat.TabIndex = 3;
            this.btn_JoinChat.Text = "Join to chat";
            this.btn_JoinChat.UseVisualStyleBackColor = true;
            this.btn_JoinChat.Click += new System.EventHandler(this.btn_JoinChat_Click);
            // 
            // btn_SendMsg
            // 
            this.btn_SendMsg.Location = new System.Drawing.Point(713, 415);
            this.btn_SendMsg.Name = "btn_SendMsg";
            this.btn_SendMsg.Size = new System.Drawing.Size(75, 23);
            this.btn_SendMsg.TabIndex = 4;
            this.btn_SendMsg.Text = "Send";
            this.btn_SendMsg.UseVisualStyleBackColor = true;
            this.btn_SendMsg.Click += new System.EventHandler(this.btn_SendMsg_Click);
            // 
            // tb_sendMsg
            // 
            this.tb_sendMsg.Location = new System.Drawing.Point(12, 417);
            this.tb_sendMsg.Name = "tb_sendMsg";
            this.tb_sendMsg.Size = new System.Drawing.Size(695, 20);
            this.tb_sendMsg.TabIndex = 5;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.tb_sendMsg);
            this.Controls.Add(this.btn_SendMsg);
            this.Controls.Add(this.btn_JoinChat);
            this.Controls.Add(this.tb_UserName);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.rtb_MsgBox);
            this.Name = "Form1";
            this.Text = "Form1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.formClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox rtb_MsgBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tb_UserName;
        private System.Windows.Forms.Button btn_JoinChat;
        private System.Windows.Forms.Button btn_SendMsg;
        private System.Windows.Forms.TextBox tb_sendMsg;
    }
}

