
namespace Kiosk
{
    partial class Inherit
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
            this.btnFatalClose = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnFatalClose
            // 
            this.btnFatalClose.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(249)))), ((int)(((byte)(249)))));
            this.btnFatalClose.FlatAppearance.BorderSize = 0;
            this.btnFatalClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFatalClose.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(249)))), ((int)(((byte)(249)))));
            this.btnFatalClose.Location = new System.Drawing.Point(0, 0);
            this.btnFatalClose.Name = "btnFatalClose";
            this.btnFatalClose.Size = new System.Drawing.Size(179, 40);
            this.btnFatalClose.TabIndex = 2;
            this.btnFatalClose.UseVisualStyleBackColor = false;
            this.btnFatalClose.Click += new System.EventHandler(this.btnFatalClose_Click);
            this.btnFatalClose.MouseHover += new System.EventHandler(this.btnFatalClose_MouseHover);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(208, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 12);
            this.label1.TabIndex = 3;
            this.label1.Text = "label1";
            // 
            // Inherit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(320, 421);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnFatalClose);
            this.Name = "Inherit";
            this.Text = "Inherit";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Inherit_FormClosed);
            this.Load += new System.EventHandler(this.Inherit_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Inherit_KeyDown);
            this.MouseClick += new System.Windows.Forms.MouseEventHandler(this.Inherit_MouseClick);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Inherit_MouseDown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnFatalClose;
        public System.Windows.Forms.Label label1;
    }
}