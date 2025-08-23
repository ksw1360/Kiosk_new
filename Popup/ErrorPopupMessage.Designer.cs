
namespace Kiosk.Popup
{
    partial class ErrorPopupMessage
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
            this.components = new System.ComponentModel.Container();
            this.panel3 = new System.Windows.Forms.Panel();
            this.radPanel1 = new Telerik.WinControls.UI.RadPanel();
            this.radButton1 = new Telerik.WinControls.UI.RadButton();
            this.panel6 = new System.Windows.Forms.Panel();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radPanel1)).BeginInit();
            this.radPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radButton1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.White;
            this.panel3.Controls.Add(this.label1);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 14);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(603, 185);
            this.panel3.TabIndex = 39;
            // 
            // radPanel1
            // 
            this.radPanel1.BackColor = System.Drawing.Color.White;
            this.radPanel1.Controls.Add(this.radButton1);
            this.radPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.radPanel1.Location = new System.Drawing.Point(0, 14);
            this.radPanel1.Name = "radPanel1";
            this.radPanel1.Size = new System.Drawing.Size(603, 400);
            this.radPanel1.TabIndex = 40;
            ((Telerik.WinControls.Primitives.BorderPrimitive)(this.radPanel1.GetChildAt(0).GetChildAt(1))).Visibility = Telerik.WinControls.ElementVisibility.Collapsed;
            // 
            // radButton1
            // 
            this.radButton1.BackColor = System.Drawing.Color.Transparent;
            this.radButton1.BackgroundImage = global::Kiosk.Properties.Resources.확인;
            this.radButton1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.radButton1.ForeColor = System.Drawing.Color.Black;
            this.radButton1.Location = new System.Drawing.Point(117, 229);
            this.radButton1.Name = "radButton1";
            this.radButton1.Size = new System.Drawing.Size(304, 103);
            this.radButton1.TabIndex = 32;
            this.radButton1.Click += new System.EventHandler(this.radButton1_Click);
            ((Telerik.WinControls.Primitives.ImagePrimitive)(this.radButton1.GetChildAt(0).GetChildAt(1).GetChildAt(0))).ForeColor = System.Drawing.Color.White;
            ((Telerik.WinControls.Primitives.TextPrimitive)(this.radButton1.GetChildAt(0).GetChildAt(1).GetChildAt(1))).LineLimit = false;
            ((Telerik.WinControls.Primitives.TextPrimitive)(this.radButton1.GetChildAt(0).GetChildAt(1).GetChildAt(1))).ForeColor = System.Drawing.Color.Black;
            ((Telerik.WinControls.Primitives.TextPrimitive)(this.radButton1.GetChildAt(0).GetChildAt(1).GetChildAt(1))).Alignment = System.Drawing.ContentAlignment.MiddleCenter;
            ((Telerik.WinControls.Primitives.BorderPrimitive)(this.radButton1.GetChildAt(0).GetChildAt(2))).ForeColor = System.Drawing.Color.Transparent;
            ((Telerik.WinControls.Primitives.BorderPrimitive)(this.radButton1.GetChildAt(0).GetChildAt(2))).BackColor = System.Drawing.Color.Transparent;
            // 
            // panel6
            // 
            this.panel6.BackColor = System.Drawing.Color.White;
            this.panel6.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.panel6.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel6.Font = new System.Drawing.Font("Microsoft Sans Serif", 33F, System.Drawing.FontStyle.Bold);
            this.panel6.Location = new System.Drawing.Point(0, 0);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(603, 14);
            this.panel6.TabIndex = 41;
            // 
            // timer1
            // 
            this.timer1.Interval = 5000;
            // 
            // label1
            // 
            this.label1.AutoEllipsis = true;
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(12, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(564, 12);
            this.label1.TabIndex = 4;
            this.label1.Text = "Error 인덱스가 범위를 벗어났습니다. 인덱스는 음수가 아니어야 하며 컬렉션의 크기보다 작아야 합니다.";
            this.label1.TextChanged += new System.EventHandler(this.label1_TextChanged);
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // ErrorPopupMessage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(603, 414);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.radPanel1);
            this.Controls.Add(this.panel6);
            this.DoubleBuffered = true;
            this.Name = "ErrorPopupMessage";
            this.Text = "ErrorPopupMessage";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.ErrorPopupMessage_Load);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radPanel1)).EndInit();
            this.radPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.radButton1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panel3;
        private Telerik.WinControls.UI.RadPanel radPanel1;
        private Telerik.WinControls.UI.RadButton radButton1;
        internal System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label label1;
    }
}