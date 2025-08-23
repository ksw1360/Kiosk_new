
namespace Kiosk
{
    partial class PtntInfoShow
    {
        /// <summary> 
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 구성 요소 디자이너에서 생성한 코드

        /// <summary> 
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            this.radLabel4 = new Telerik.WinControls.UI.RadLabel();
            this.radLabel3 = new Telerik.WinControls.UI.RadLabel();
            this.radLabel2 = new Telerik.WinControls.UI.RadLabel();
            this.radLabel1 = new Telerik.WinControls.UI.RadLabel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.selectButton = new Telerik.WinControls.UI.RadButton();
            this.panel2 = new System.Windows.Forms.Panel();
            this.radLabel5 = new Telerik.WinControls.UI.RadLabel();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).BeginInit();
            this.panel1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.selectButton)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel5)).BeginInit();
            this.SuspendLayout();
            // 
            // radLabel4
            // 
            this.radLabel4.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F);
            this.radLabel4.Location = new System.Drawing.Point(581, 12);
            this.radLabel4.Name = "radLabel4";
            this.radLabel4.Size = new System.Drawing.Size(162, 38);
            this.radLabel4.TabIndex = 9;
            this.radLabel4.Text = "111111111";
            this.radLabel4.Visible = false;
            // 
            // radLabel3
            // 
            this.radLabel3.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F);
            this.radLabel3.Location = new System.Drawing.Point(15, 12);
            this.radLabel3.Name = "radLabel3";
            this.radLabel3.Size = new System.Drawing.Size(215, 38);
            this.radLabel3.TabIndex = 8;
            this.radLabel3.Text = "010-1234-2887";
            this.radLabel3.TextAlignment = System.Drawing.ContentAlignment.TopLeft;
            this.radLabel3.Visible = false;
            this.radLabel3.TextChanged += new System.EventHandler(this.radLabel3_TextChanged);
            this.radLabel3.Click += new System.EventHandler(this.textBox1_Click);
            // 
            // radLabel2
            // 
            this.radLabel2.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F);
            this.radLabel2.Location = new System.Drawing.Point(84, 12);
            this.radLabel2.Name = "radLabel2";
            this.radLabel2.Size = new System.Drawing.Size(79, 38);
            this.radLabel2.TabIndex = 7;
            this.radLabel2.Text = "0820";
            this.radLabel2.TextAlignment = System.Drawing.ContentAlignment.TopLeft;
            this.radLabel2.Click += new System.EventHandler(this.textBox1_Click);
            // 
            // radLabel1
            // 
            this.radLabel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F);
            this.radLabel1.Location = new System.Drawing.Point(57, 12);
            this.radLabel1.Name = "radLabel1";
            this.radLabel1.Size = new System.Drawing.Size(111, 38);
            this.radLabel1.TabIndex = 6;
            this.radLabel1.Text = "김상우";
            this.radLabel1.TextAlignment = System.Drawing.ContentAlignment.TopLeft;
            this.radLabel1.Click += new System.EventHandler(this.textBox1_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.tableLayoutPanel1);
            this.panel1.Controls.Add(this.radLabel4);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.ForeColor = System.Drawing.Color.Black;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(765, 74);
            this.panel1.TabIndex = 0;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.Controls.Add(this.panel4, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.panel3, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.panel2, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(765, 74);
            this.tableLayoutPanel1.TabIndex = 10;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.radLabel5);
            this.panel4.Controls.Add(this.radLabel3);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel4.Location = new System.Drawing.Point(513, 3);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(249, 68);
            this.panel4.TabIndex = 11;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.selectButton);
            this.panel3.Controls.Add(this.radLabel2);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(258, 3);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(249, 68);
            this.panel3.TabIndex = 11;
            // 
            // selectButton
            // 
            this.selectButton.Location = new System.Drawing.Point(200, 21);
            this.selectButton.Name = "selectButton";
            this.selectButton.Size = new System.Drawing.Size(23, 25);
            this.selectButton.TabIndex = 8;
            this.selectButton.Text = "radButton1";
            this.selectButton.Visible = false;
            this.selectButton.Click += new System.EventHandler(this.textBox1_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.radLabel1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(3, 3);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(249, 68);
            this.panel2.TabIndex = 9;
            // 
            // radLabel5
            // 
            this.radLabel5.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F);
            this.radLabel5.Location = new System.Drawing.Point(17, 12);
            this.radLabel5.Name = "radLabel5";
            this.radLabel5.Size = new System.Drawing.Size(215, 38);
            this.radLabel5.TabIndex = 9;
            this.radLabel5.Text = "010-1234-2887";
            this.radLabel5.TextAlignment = System.Drawing.ContentAlignment.TopLeft;
            this.radLabel5.Click += new System.EventHandler(this.textBox1_Click);
            // 
            // PtntInfoShow
            // 
            this.Controls.Add(this.panel1);
            this.Name = "PtntInfoShow";
            this.Size = new System.Drawing.Size(765, 74);
            ((System.ComponentModel.ISupportInitialize)(this.radLabel4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.selectButton)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel5)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        public Telerik.WinControls.UI.RadLabel radLabel4;
        public Telerik.WinControls.UI.RadLabel radLabel3;
        public Telerik.WinControls.UI.RadLabel radLabel2;
        public Telerik.WinControls.UI.RadLabel radLabel1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel2;
        public Telerik.WinControls.UI.RadButton selectButton;
        public Telerik.WinControls.UI.RadLabel radLabel5;
    }
}
