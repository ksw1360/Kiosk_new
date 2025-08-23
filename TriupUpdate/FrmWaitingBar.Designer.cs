
namespace Kiosk.TriupUpdate
{
    partial class FrmWaitingBar
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
            this.waitingBar = new Telerik.WinControls.UI.RadWaitingBar();
            this.dotsRingWaitingBarIndicatorElement1 = new Telerik.WinControls.UI.DotsRingWaitingBarIndicatorElement();
            this.radPanel1 = new Telerik.WinControls.UI.RadPanel();
            this.lblWaiting = new Telerik.WinControls.UI.RadLabel();
            ((System.ComponentModel.ISupportInitialize)(this.waitingBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radPanel1)).BeginInit();
            this.radPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lblWaiting)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // waitingBar
            // 
            this.waitingBar.Location = new System.Drawing.Point(3, 3);
            this.waitingBar.Name = "waitingBar";
            this.waitingBar.Padding = new System.Windows.Forms.Padding(5);
            this.waitingBar.Size = new System.Drawing.Size(80, 80);
            this.waitingBar.TabIndex = 0;
            this.waitingBar.Text = "radWaitingBar1";
            this.waitingBar.WaitingIndicators.Add(this.dotsRingWaitingBarIndicatorElement1);
            this.waitingBar.WaitingIndicatorSize = new System.Drawing.Size(100, 14);
            this.waitingBar.WaitingSpeed = 40;
            this.waitingBar.WaitingStyle = Telerik.WinControls.Enumerations.WaitingBarStyles.DotsRing;
            this.waitingBar.WaitingStopped += new System.EventHandler(this.waitingBar_WaitingStopped);
            ((Telerik.WinControls.UI.RadWaitingBarElement)(this.waitingBar.GetChildAt(0))).WaitingIndicatorSize = new System.Drawing.Size(100, 14);
            ((Telerik.WinControls.UI.RadWaitingBarElement)(this.waitingBar.GetChildAt(0))).WaitingSpeed = 40;
            ((Telerik.WinControls.UI.RadWaitingBarElement)(this.waitingBar.GetChildAt(0))).Padding = new System.Windows.Forms.Padding(5);
            ((Telerik.WinControls.UI.WaitingBarContentElement)(this.waitingBar.GetChildAt(0).GetChildAt(0))).WaitingStyle = Telerik.WinControls.Enumerations.WaitingBarStyles.DotsRing;
            // 
            // dotsRingWaitingBarIndicatorElement1
            // 
            this.dotsRingWaitingBarIndicatorElement1.BorderBottomWidth = 1F;
            this.dotsRingWaitingBarIndicatorElement1.BorderBoxStyle = Telerik.WinControls.BorderBoxStyle.FourBorders;
            this.dotsRingWaitingBarIndicatorElement1.ElementColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(148)))), ((int)(((byte)(154)))));
            this.dotsRingWaitingBarIndicatorElement1.ElementCount = 13;
            this.dotsRingWaitingBarIndicatorElement1.ImageTransparentColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(148)))), ((int)(((byte)(154)))));
            this.dotsRingWaitingBarIndicatorElement1.Name = "dotsRingWaitingBarIndicatorElement1";
            this.dotsRingWaitingBarIndicatorElement1.Radius = 23;
            // 
            // radPanel1
            // 
            this.radPanel1.BackColor = System.Drawing.Color.White;
            this.radPanel1.Controls.Add(this.lblWaiting);
            this.radPanel1.Controls.Add(this.waitingBar);
            this.radPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.radPanel1.Location = new System.Drawing.Point(0, 0);
            this.radPanel1.MaximumSize = new System.Drawing.Size(300, 100);
            this.radPanel1.Name = "radPanel1";
            // 
            // 
            // 
            this.radPanel1.RootElement.MaxSize = new System.Drawing.Size(300, 100);
            this.radPanel1.Size = new System.Drawing.Size(296, 92);
            this.radPanel1.TabIndex = 1;
            // 
            // lblWaiting
            // 
            this.lblWaiting.AutoSize = false;
            this.lblWaiting.Location = new System.Drawing.Point(89, 6);
            this.lblWaiting.Name = "lblWaiting";
            this.lblWaiting.Size = new System.Drawing.Size(187, 76);
            this.lblWaiting.TabIndex = 1;
            this.lblWaiting.Text = "loading";
            // 
            // FrmWaitingBar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(296, 92);
            this.Controls.Add(this.radPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximumSize = new System.Drawing.Size(296, 92);
            this.Name = "FrmWaitingBar";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.RootElement.MaxSize = new System.Drawing.Size(296, 92);
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmWatingBar";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmWaitingBar_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.waitingBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radPanel1)).EndInit();
            this.radPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.lblWaiting)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Telerik.WinControls.UI.RadWaitingBar waitingBar;
        private Telerik.WinControls.UI.RadPanel radPanel1;
        private Telerik.WinControls.UI.RadLabel lblWaiting;
        private Telerik.WinControls.UI.DotsRingWaitingBarIndicatorElement dotsRingWaitingBarIndicatorElement1;
    }
}