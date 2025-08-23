using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace Kiosk.TriupUpdate
{
    partial class FrmUpdateHistory
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private IContainer components = null;

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
            this.panel1 = new System.Windows.Forms.Panel();
            this.txtContent = new System.Windows.Forms.RichTextBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.chkBeforeUpdate = new System.Windows.Forms.CheckBox();
            this.lblVersion = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.btnOk = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.txtContent);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.lblVersion);
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(702, 360);
            this.panel1.TabIndex = 0;
            // 
            // txtContent
            // 
            this.txtContent.BackColor = System.Drawing.Color.White;
            this.txtContent.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtContent.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.txtContent.Font = new System.Drawing.Font("Gadugi", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtContent.Location = new System.Drawing.Point(12, 51);
            this.txtContent.Name = "txtContent";
            this.txtContent.ReadOnly = true;
            this.txtContent.Size = new System.Drawing.Size(678, 227);
            this.txtContent.TabIndex = 6;
            this.txtContent.Text = "";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.chkBeforeUpdate);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 277);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(702, 31);
            this.panel2.TabIndex = 9;
            // 
            // chkBeforeUpdate
            // 
            this.chkBeforeUpdate.AutoSize = true;
            this.chkBeforeUpdate.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.chkBeforeUpdate.Location = new System.Drawing.Point(5, 7);
            this.chkBeforeUpdate.Name = "chkBeforeUpdate";
            this.chkBeforeUpdate.Size = new System.Drawing.Size(128, 19);
            this.chkBeforeUpdate.TabIndex = 8;
            this.chkBeforeUpdate.Text = "이전 업데이트 보기";
            this.chkBeforeUpdate.UseVisualStyleBackColor = true;
            this.chkBeforeUpdate.CheckedChanged += new System.EventHandler(this.chkBeforeUpdate_CheckStateChanged);
            // 
            // lblVersion
            // 
            this.lblVersion.Font = new System.Drawing.Font("Gadugi", 18F, System.Drawing.FontStyle.Bold);
            this.lblVersion.Location = new System.Drawing.Point(12, 10);
            this.lblVersion.Name = "lblVersion";
            this.lblVersion.Size = new System.Drawing.Size(270, 37);
            this.lblVersion.TabIndex = 2;
            this.lblVersion.Text = "1.0.0.1 변경사항";
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.White;
            this.panel3.Controls.Add(this.btnOk);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel3.Location = new System.Drawing.Point(0, 308);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(702, 52);
            this.panel3.TabIndex = 1;
            // 
            // btnOk
            // 
            this.btnOk.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(148)))), ((int)(((byte)(154)))));
            this.btnOk.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnOk.FlatAppearance.BorderSize = 0;
            this.btnOk.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOk.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold);
            this.btnOk.ForeColor = System.Drawing.Color.White;
            this.btnOk.Location = new System.Drawing.Point(0, 0);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(702, 52);
            this.btnOk.TabIndex = 0;
            this.btnOk.Text = "업데이트";
            this.btnOk.UseVisualStyleBackColor = false;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // FrmUpdateHistory
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(702, 360);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "FrmUpdateHistory";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "업데이트 내역";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FrmUpdateHistory_FormClosed);
            this.Load += new System.EventHandler(this.FrmUpdateHistory_Load);
            this.Shown += new System.EventHandler(this.FrmUpdateHistory_Shown);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Panel panel1;
        private RichTextBox txtContent;
        private Panel panel2;
        private Label lblVersion;
        private Panel panel3;
        private Button btnOk;
        private CheckBox chkBeforeUpdate;
    }
}