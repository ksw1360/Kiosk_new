
namespace Kiosk.Popup
{
    partial class PopChangePW
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
            this.radLabel1 = new Telerik.WinControls.UI.RadLabel();
            this.radLabel3 = new Telerik.WinControls.UI.RadLabel();
            this.txtNewPwChk = new Telerik.WinControls.UI.RadTextBox();
            this.btnChangePW = new Telerik.WinControls.UI.RadButton();
            this.radLabel4 = new Telerik.WinControls.UI.RadLabel();
            this.radLabel5 = new Telerik.WinControls.UI.RadLabel();
            this.txtNewPw = new Telerik.WinControls.UI.RadTextBox();
            this.txtUserID = new Telerik.WinControls.UI.RadTextBox();
            this.radLabel2 = new Telerik.WinControls.UI.RadLabel();
            this.txtUserPW = new Telerik.WinControls.UI.RadTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNewPwChk)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnChangePW)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNewPw)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtUserID)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtUserPW)).BeginInit();
            this.SuspendLayout();
            // 
            // radLabel1
            // 
            this.radLabel1.Location = new System.Drawing.Point(12, 12);
            this.radLabel1.Name = "radLabel1";
            this.radLabel1.Size = new System.Drawing.Size(40, 18);
            this.radLabel1.TabIndex = 20;
            this.radLabel1.Text = "아이디";
            // 
            // radLabel3
            // 
            this.radLabel3.Location = new System.Drawing.Point(12, 44);
            this.radLabel3.Name = "radLabel3";
            this.radLabel3.Size = new System.Drawing.Size(77, 18);
            this.radLabel3.TabIndex = 22;
            this.radLabel3.Text = "기존 비밀번호";
            // 
            // txtNewPwChk
            // 
            this.txtNewPwChk.Location = new System.Drawing.Point(106, 106);
            this.txtNewPwChk.Name = "txtNewPwChk";
            this.txtNewPwChk.PasswordChar = '●';
            this.txtNewPwChk.Size = new System.Drawing.Size(185, 20);
            this.txtNewPwChk.TabIndex = 28;
            // 
            // btnChangePW
            // 
            this.btnChangePW.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(114)))), ((int)(((byte)(171)))));
            this.btnChangePW.ForeColor = System.Drawing.Color.White;
            this.btnChangePW.Location = new System.Drawing.Point(88, 210);
            this.btnChangePW.Name = "btnChangePW";
            this.btnChangePW.Size = new System.Drawing.Size(110, 24);
            this.btnChangePW.TabIndex = 29;
            this.btnChangePW.Text = "비밀번호 변경";
            this.btnChangePW.Click += new System.EventHandler(this.btnChangePW_Click);
            // 
            // radLabel4
            // 
            this.radLabel4.Location = new System.Drawing.Point(12, 76);
            this.radLabel4.Name = "radLabel4";
            this.radLabel4.Size = new System.Drawing.Size(66, 18);
            this.radLabel4.TabIndex = 23;
            this.radLabel4.Text = "새 비밀번호";
            // 
            // radLabel5
            // 
            this.radLabel5.Location = new System.Drawing.Point(12, 151);
            this.radLabel5.Name = "radLabel5";
            this.radLabel5.Size = new System.Drawing.Size(218, 33);
            this.radLabel5.TabIndex = 24;
            this.radLabel5.Text = "* 반드시 영문, 숫자, 특수문자를 혼용하여\r\n8자리 이상 입력하셔야 합니다.";
            // 
            // txtNewPw
            // 
            this.txtNewPw.Location = new System.Drawing.Point(106, 74);
            this.txtNewPw.Name = "txtNewPw";
            this.txtNewPw.PasswordChar = '●';
            this.txtNewPw.Size = new System.Drawing.Size(185, 20);
            this.txtNewPw.TabIndex = 27;
            // 
            // txtUserID
            // 
            this.txtUserID.Location = new System.Drawing.Point(106, 10);
            this.txtUserID.Name = "txtUserID";
            this.txtUserID.ReadOnly = true;
            this.txtUserID.Size = new System.Drawing.Size(185, 20);
            this.txtUserID.TabIndex = 25;
            this.txtUserID.TabStop = false;
            // 
            // radLabel2
            // 
            this.radLabel2.Location = new System.Drawing.Point(12, 108);
            this.radLabel2.Name = "radLabel2";
            this.radLabel2.Size = new System.Drawing.Size(77, 18);
            this.radLabel2.TabIndex = 21;
            this.radLabel2.Text = "비밀번호 확인";
            // 
            // txtUserPW
            // 
            this.txtUserPW.Location = new System.Drawing.Point(106, 42);
            this.txtUserPW.Name = "txtUserPW";
            this.txtUserPW.PasswordChar = '●';
            this.txtUserPW.Size = new System.Drawing.Size(185, 20);
            this.txtUserPW.TabIndex = 26;
            // 
            // PopChangePW
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(325, 255);
            this.Controls.Add(this.radLabel1);
            this.Controls.Add(this.radLabel3);
            this.Controls.Add(this.txtNewPwChk);
            this.Controls.Add(this.btnChangePW);
            this.Controls.Add(this.radLabel4);
            this.Controls.Add(this.radLabel5);
            this.Controls.Add(this.txtNewPw);
            this.Controls.Add(this.txtUserID);
            this.Controls.Add(this.radLabel2);
            this.Controls.Add(this.txtUserPW);
            this.Name = "PopChangePW";
            this.Text = "PopChangePW";
            this.Load += new System.EventHandler(this.PopChangePW_Load);
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNewPwChk)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnChangePW)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNewPw)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtUserID)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtUserPW)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Telerik.WinControls.UI.RadLabel radLabel1;
        private Telerik.WinControls.UI.RadLabel radLabel3;
        private Telerik.WinControls.UI.RadTextBox txtNewPwChk;
        private Telerik.WinControls.UI.RadButton btnChangePW;
        private Telerik.WinControls.UI.RadLabel radLabel4;
        private Telerik.WinControls.UI.RadLabel radLabel5;
        private Telerik.WinControls.UI.RadTextBox txtNewPw;
        private Telerik.WinControls.UI.RadTextBox txtUserID;
        private Telerik.WinControls.UI.RadLabel radLabel2;
        private Telerik.WinControls.UI.RadTextBox txtUserPW;
    }
}