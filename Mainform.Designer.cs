
namespace Kiosk
{
    partial class Main
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

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            this.panel4 = new System.Windows.Forms.Panel();
            this.button2 = new System.Windows.Forms.Button();
            this.btnPreview = new System.Windows.Forms.Button();
            this.btnNext = new System.Windows.Forms.Button();
            this.panel7 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lbFirst = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lbSecond = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.btnNewPtnt = new Telerik.WinControls.UI.RadButton();
            this.btnPrePtnt = new Telerik.WinControls.UI.RadButton();
            this.panel4.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnNewPtnt)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnPrePtnt)).BeginInit();
            this.SuspendLayout();
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(249)))), ((int)(((byte)(249)))));
            this.panel4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel4.Controls.Add(this.button2);
            this.panel4.Controls.Add(this.btnPreview);
            this.panel4.Controls.Add(this.btnNext);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(249)))), ((int)(((byte)(249)))));
            this.panel4.Location = new System.Drawing.Point(0, 36);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(1080, 106);
            this.panel4.TabIndex = 21;
            // 
            // button2
            // 
            this.button2.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(249)))), ((int)(((byte)(249)))));
            this.button2.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(249)))), ((int)(((byte)(249)))));
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Font = new System.Drawing.Font("굴림", 20F);
            this.button2.ForeColor = System.Drawing.Color.Gray;
            this.button2.Location = new System.Drawing.Point(419, 16);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(208, 75);
            this.button2.TabIndex = 22;
            this.button2.Text = "종료";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // btnPreview
            // 
            this.btnPreview.AutoSize = true;
            this.btnPreview.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(249)))), ((int)(((byte)(249)))));
            this.btnPreview.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnPreview.BackgroundImage")));
            this.btnPreview.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnPreview.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnPreview.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(249)))), ((int)(((byte)(249)))));
            this.btnPreview.FlatAppearance.BorderSize = 0;
            this.btnPreview.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(249)))), ((int)(((byte)(249)))));
            this.btnPreview.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(249)))), ((int)(((byte)(249)))));
            this.btnPreview.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPreview.Font = new System.Drawing.Font("맑은 고딕", 26F);
            this.btnPreview.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.btnPreview.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnPreview.Location = new System.Drawing.Point(0, 0);
            this.btnPreview.Name = "btnPreview";
            this.btnPreview.Size = new System.Drawing.Size(228, 106);
            this.btnPreview.TabIndex = 20;
            this.btnPreview.UseVisualStyleBackColor = false;
            this.btnPreview.Visible = false;
            this.btnPreview.Click += new System.EventHandler(this.btnPreview_Click);
            this.btnPreview.MouseMove += new System.Windows.Forms.MouseEventHandler(this.btnPreview_MouseMove);
            // 
            // btnNext
            // 
            this.btnNext.AutoSize = true;
            this.btnNext.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(249)))), ((int)(((byte)(249)))));
            this.btnNext.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnNext.BackgroundImage")));
            this.btnNext.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnNext.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnNext.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(249)))), ((int)(((byte)(249)))));
            this.btnNext.FlatAppearance.BorderSize = 0;
            this.btnNext.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(249)))), ((int)(((byte)(249)))));
            this.btnNext.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(249)))), ((int)(((byte)(249)))));
            this.btnNext.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNext.Font = new System.Drawing.Font("맑은 고딕", 30F);
            this.btnNext.ForeColor = System.Drawing.Color.Gray;
            this.btnNext.Location = new System.Drawing.Point(852, 0);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(228, 106);
            this.btnNext.TabIndex = 21;
            this.btnNext.UseVisualStyleBackColor = false;
            this.btnNext.Visible = false;
            this.btnNext.Click += new System.EventHandler(this.btnNewPtnt_Click);
            // 
            // panel7
            // 
            this.panel7.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel7.Location = new System.Drawing.Point(0, 0);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(1080, 36);
            this.panel7.TabIndex = 20;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(249)))), ((int)(((byte)(249)))));
            this.panel2.Controls.Add(this.lbFirst);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 267);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1080, 172);
            this.panel2.TabIndex = 23;
            // 
            // lbFirst
            // 
            this.lbFirst.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(249)))), ((int)(((byte)(249)))));
            this.lbFirst.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbFirst.Font = new System.Drawing.Font("Noto Sans CJK KR Bold", 80.24999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbFirst.Location = new System.Drawing.Point(0, 0);
            this.lbFirst.Name = "lbFirst";
            this.lbFirst.Size = new System.Drawing.Size(1080, 172);
            this.lbFirst.TabIndex = 0;
            this.lbFirst.Text = "내원 여부 선택";
            this.lbFirst.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(249)))), ((int)(((byte)(249)))));
            this.panel1.Controls.Add(this.lbSecond);
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 142);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1080, 125);
            this.panel1.TabIndex = 22;
            // 
            // lbSecond
            // 
            this.lbSecond.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(249)))), ((int)(((byte)(249)))));
            this.lbSecond.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbSecond.Font = new System.Drawing.Font("Noto Sans CJK KR Regular", 32.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbSecond.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(102)))), ((int)(((byte)(102)))));
            this.lbSecond.Location = new System.Drawing.Point(0, 59);
            this.lbSecond.Name = "lbSecond";
            this.lbSecond.Size = new System.Drawing.Size(1080, 66);
            this.lbSecond.TabIndex = 0;
            this.lbSecond.Text = "안녕하세요, 00의원 입니다.";
            this.lbSecond.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(249)))), ((int)(((byte)(249)))));
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1080, 59);
            this.panel3.TabIndex = 32;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(909, 1215);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 21);
            this.textBox1.TabIndex = 24;
            // 
            // btnNewPtnt
            // 
            this.btnNewPtnt.BackColor = System.Drawing.Color.Transparent;
            this.btnNewPtnt.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnNewPtnt.BackgroundImage")));
            this.btnNewPtnt.ForeColor = System.Drawing.Color.Black;
            this.btnNewPtnt.Location = new System.Drawing.Point(86, 434);
            this.btnNewPtnt.Name = "btnNewPtnt";
            this.btnNewPtnt.Size = new System.Drawing.Size(923, 392);
            this.btnNewPtnt.TabIndex = 27;
            this.btnNewPtnt.Click += new System.EventHandler(this.btnNewPtnt_Click);
            ((Telerik.WinControls.Primitives.ImagePrimitive)(this.btnNewPtnt.GetChildAt(0).GetChildAt(1).GetChildAt(0))).ForeColor = System.Drawing.Color.White;
            ((Telerik.WinControls.Primitives.TextPrimitive)(this.btnNewPtnt.GetChildAt(0).GetChildAt(1).GetChildAt(1))).LineLimit = false;
            ((Telerik.WinControls.Primitives.TextPrimitive)(this.btnNewPtnt.GetChildAt(0).GetChildAt(1).GetChildAt(1))).ForeColor = System.Drawing.Color.Black;
            ((Telerik.WinControls.Primitives.TextPrimitive)(this.btnNewPtnt.GetChildAt(0).GetChildAt(1).GetChildAt(1))).Alignment = System.Drawing.ContentAlignment.MiddleCenter;
            ((Telerik.WinControls.Primitives.BorderPrimitive)(this.btnNewPtnt.GetChildAt(0).GetChildAt(2))).ForeColor = System.Drawing.Color.Transparent;
            ((Telerik.WinControls.Primitives.BorderPrimitive)(this.btnNewPtnt.GetChildAt(0).GetChildAt(2))).BackColor = System.Drawing.Color.Transparent;
            // 
            // btnPrePtnt
            // 
            this.btnPrePtnt.BackColor = System.Drawing.Color.Transparent;
            this.btnPrePtnt.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnPrePtnt.BackgroundImage")));
            this.btnPrePtnt.ForeColor = System.Drawing.Color.Black;
            this.btnPrePtnt.Location = new System.Drawing.Point(86, 862);
            this.btnPrePtnt.Name = "btnPrePtnt";
            this.btnPrePtnt.Size = new System.Drawing.Size(923, 392);
            this.btnPrePtnt.TabIndex = 26;
            this.btnPrePtnt.Click += new System.EventHandler(this.btnPrePtnt_Click);
            ((Telerik.WinControls.Primitives.ImagePrimitive)(this.btnPrePtnt.GetChildAt(0).GetChildAt(1).GetChildAt(0))).ForeColor = System.Drawing.Color.White;
            ((Telerik.WinControls.Primitives.TextPrimitive)(this.btnPrePtnt.GetChildAt(0).GetChildAt(1).GetChildAt(1))).LineLimit = false;
            ((Telerik.WinControls.Primitives.TextPrimitive)(this.btnPrePtnt.GetChildAt(0).GetChildAt(1).GetChildAt(1))).ForeColor = System.Drawing.Color.Black;
            ((Telerik.WinControls.Primitives.TextPrimitive)(this.btnPrePtnt.GetChildAt(0).GetChildAt(1).GetChildAt(1))).Alignment = System.Drawing.ContentAlignment.MiddleCenter;
            ((Telerik.WinControls.Primitives.BorderPrimitive)(this.btnPrePtnt.GetChildAt(0).GetChildAt(2))).ForeColor = System.Drawing.Color.Transparent;
            ((Telerik.WinControls.Primitives.BorderPrimitive)(this.btnPrePtnt.GetChildAt(0).GetChildAt(2))).BackColor = System.Drawing.Color.Transparent;
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(249)))), ((int)(((byte)(249)))));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1080, 1100);
            this.Controls.Add(this.btnNewPtnt);
            this.Controls.Add(this.btnPrePtnt);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel7);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.TopMost = true;
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Main_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Main_FormClosed);
            this.Load += new System.EventHandler(this.Main_Load);
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.btnNewPtnt)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnPrePtnt)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.Panel panel2;
        public System.Windows.Forms.Label lbFirst;
        private System.Windows.Forms.Panel panel1;
        public System.Windows.Forms.Label lbSecond;
        private System.Windows.Forms.TextBox textBox1;
        private Telerik.WinControls.UI.RadButton btnPrePtnt;
        private Telerik.WinControls.UI.RadButton btnNewPtnt;
        private System.Windows.Forms.Panel panel3;
        public System.Windows.Forms.Button btnPreview;
        public System.Windows.Forms.Button btnNext;
        private System.Windows.Forms.Button button2;
    }
}

