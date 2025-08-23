using Kiosk.Class;
using Kiosk.Popup;
using System;
using System.Drawing;
using System.Windows.Forms;
using Telerik.WinControls.Primitives;
using Telerik.WinControls.UI;

namespace Kiosk
{
    public partial class ReceiptInfo : Form
    {
        TextBox[] textBox = new TextBox[] { };
        Label[] label = new Label[] { };
        internal System.Windows.Forms.Timer timer;

        public ReceiptInfo()
        {
            InitializeComponent();
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer | ControlStyles.UserPaint | ControlStyles.AllPaintingInWmPaint, true);
            this.UpdateStyles();
            //txtname.AutoSize = false;
            //txtname.Height += 10;

            //txtpersonalno.AutoSize = false;
            //txtpersonalno.Height += 10;

            //txtsurgery.AutoSize = false;
            //txtsurgery.Height += 10;

            //txtmobile.AutoSize = false;
            //txtmobile.Height += 10;

            //txtaddress.AutoSize = false;
            //txtaddress.Height += 10;

            //txtkind.AutoSize = false;
            //txtkind.Height += 10;

        }

        private void ReceiptInfo_Load(object sender, EventArgs e)
        {
            this.FormBorderStyle = FormBorderStyle.None;
            this.StartPosition = FormStartPosition.CenterScreen;

            this.Size = new Size(1080, 1920);
            //this.lbFirst.Visible = false;

            //this.lbThird.Font = new Font("NotoSansKR-Medium", 23, FontStyle.Regular);
            //this.lbThird.Text = "입력한 정보 확인 후" + Environment.NewLine
            //                   + "개인정보 활용 및 수집 동의 체크";
            //this.lbThird.AutoSize = false;
            //this.lbThird.TextAlign = ContentAlignment.MiddleCenter;
            //this.lbThird.Dock = DockStyle.Fill;
            //this.lbThird.ForeColor = Color.FromArgb(153, 153, 153);
            //this.lbThird.BackColor = Color.FromArgb(249, 249, 249);

            //this.lbSecond.Font = new Font("NotoSansKR-Bold", 42, FontStyle.Bold);
            //this.lbSecond.Text = "접수 정보";

            //this.lbFirst.AutoSize = false;
            //this.lbFirst.TextAlign = ContentAlignment.MiddleCenter;
            //this.lbFirst.Dock = DockStyle.Fill;

            this.lbSecond.AutoSize = false;
            this.lbSecond.TextAlign = ContentAlignment.MiddleCenter;
            this.lbSecond.Dock = DockStyle.Fill;

            this.btnPreview.Visible = true;
            this.btnNext.Visible = false;

            this.btnPreview.BackgroundImage = Properties.Resources.이전2;

            //라벨 폰트 설정
            //this.label1.Font = new Font("NotoSansKR-Medium", 18, FontStyle.Regular);
            //this.label1.ForeColor = Color.FromArgb(34, 34, 34);
            //this.label1.Text = "이름";

            //this.label2.Font = new Font("NotoSansKR-Medium", 18, FontStyle.Regular);
            //this.label2.Text = "주민등록번호";

            //this.label3.Font = new Font("NotoSansKR-Medium", 18, FontStyle.Regular);
            //this.label3.Text = "진료분야";

            //this.label4.Font = new Font("NotoSansKR-Medium", 18, FontStyle.Regular);
            //this.label4.Text = "휴대폰번호";

            //this.label5.Font = new Font("NotoSansKR-Medium", 18, FontStyle.Regular);
            //this.label5.Text = "주소";

            //this.label6.Font = new Font("NotoSansKR-Medium", 18, FontStyle.Regular);
            //this.label6.Text = "내원경로";

            //this.label7.Font = new Font("NotoSansKR-Medium", 18, FontStyle.Regular);
            //this.label7.Text = "문자수신";

            //this.label8.Font = new Font("NotoSansKR-Medium", 18, FontStyle.Regular);
            //this.label8.Text = "이용약관동의";

            this.btnReceipt.Font = new Font("NotoSansCJKKR-Medium", 25, FontStyle.Regular);

            this.radioButton1.Font = new Font("NotoSansCJKKR-Medium", 19, FontStyle.Regular);
            this.radioButton2.Font = new Font("NotoSansCJKKR-Medium", 19, FontStyle.Regular);

            //this.checkBox1.Font = new Font("NotoSansKR-Regular", 16, FontStyle.Regular);
            //this.checkBox1.ForeColor = Color.FromArgb(136, 136, 136);

            for (int idx = 0; idx < textBox.Length; idx++)
            {
                if (textBox[idx] != null)
                {
                    textBox[idx].Size = new System.Drawing.Size(477, 47);
                    textBox[idx].ForeColor = Color.White;
                    //Noto Sans KR Light, 17.9999981pt
                    textBox[idx].Font = new Font("Noto Sans KR", 17, FontStyle.Regular);
                    textBox[idx].TextAlign = HorizontalAlignment.Center;
                    textBox[idx].MaxLength = 1;
                }
            }

            for (int i = 0; i < label.Length; i++)
            {
                if (label[i] != null)
                {
                    label[i].BackColor = Color.FromArgb(249, 249, 249);
                    label[i].ForeColor = Color.FromArgb(34, 34, 34);
                }
            }

            this.radioButton1.IsChecked = true;

            init();
            SetData();
        }

        internal void init()
        {
            txtname.Text = string.Empty;
            txtpersonalno.Text = string.Empty;
            txtsurgery.Text = string.Empty;
            txtmobile.Text = string.Empty;
            txtaddress.Text = string.Empty;
            txtkind.Text = string.Empty;
            radioButton1.IsChecked = true;
            radioButton2.IsChecked = false;
            checkBox1.Checked = false;
            checkBox2.Checked = false;
            checkBox3.Checked = false;
        }

        internal void SetData()
        {
            if (Common.Name != null && Common.Name != "")
            {
                if (string.IsNullOrEmpty(Common.Name))
                {

                }
                else
                {
                    txtname.Text = Common.Name;       //이름 필수  
                }

                txtmobile.Text = Common.MobileNO; //핸드폰번호 필수

                if (string.IsNullOrEmpty(Common.PersonalNO))
                {
                    txtpersonalno.Text = string.Empty;
                }
                else
                {
                    if (Common.PersonalNO.Length >= 7)
                        txtpersonalno.Text = Common.PersonalNO.Substring(0, 6) + "-" + Common.PersonalNO.Substring(7, 1) + "******"; //주민등록번호
                    else
                        txtpersonalno.Text = string.Empty;
                }

                if (string.IsNullOrEmpty(Common.SurgeryKind))
                {
                    txtsurgery.Text = string.Empty;
                }
                else
                {
                    txtsurgery.Text = Common.SurgeryKind; //진료여부
                }

                if (string.IsNullOrEmpty(Common.Address))
                {
                    txtaddress.Text = string.Empty;
                }
                else
                {
                    txtaddress.Text = Common.Address; //주소
                }

                if (string.IsNullOrEmpty(Common.input))
                {
                    txtkind.Text = string.Empty;
                }
                else
                {
                    txtkind.Text = Common.input; //내원경로
                }

                radioButton1.IsChecked = true;  //문자수신여부
                radioButton2.IsChecked = false; //문자수신여부 
                checkBox1.Checked = false; //약관동의
                checkBox2.Checked = false; //약관동의
                checkBox3.Checked = false; //약관동의
            }
        }

        private void btnPreview_Click(object sender, EventArgs e)
        {
            //Common.PageMove("SurgeryKind", this.Name, "1");
            //Common.Init();
            //Common.PageMove("Main", this.Name, "1");
            Common.PageMove("InputMobileNo", this.Name, "1");
            //InputMobileNo

        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (this.radioButton1.IsChecked)
            {
                this.radioButton1.ForeColor = Color.FromArgb(241, 148, 154); //Checked
            }
            else
            {
                this.radioButton1.ForeColor = Color.FromArgb(187, 187, 187); //Checked
            }
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (this.radioButton2.IsChecked)
            {
                this.radioButton2.ForeColor = Color.FromArgb(241, 148, 154); //Checked
            }
            else
            {
                this.radioButton2.ForeColor = Color.FromArgb(187, 187, 187); //Checked
            }
        }

        private void btnPreview_Click_1(object sender, EventArgs e)
        {
            Common.PageMove("InputAddress", this.Name, "1");
        }

        private void btnReceipt_Click(object sender, EventArgs e)
        {
            try
            {
                //문자수신 여부
                if (radioButton1.IsChecked)
                {
                    Common.SMS_YN = "1";
                }
                else if (radioButton2.IsChecked == false)
                {
                    Common.SMS_YN = "0";
                }

                //이용약관 동의
                if (checkBox1.Checked) //전체동의
                {
                    Common.Rules = "1";
                    Common.Ptntinfo = "1";
                    Common.Eventarl = "1";
                }
                else if (checkBox1.Checked == false)
                {
                    Common.Rules = "1";

                    //개인정보 활용 동의
                    if (checkBox2.Checked)
                    {
                        Common.Ptntinfo = "1";
                    }
                    else if (checkBox2.Checked == false)
                    {
                        Common.Ptntinfo = "0";
                    }

                    //이벤트 및 광고 SMS 수신 동의
                    if (checkBox3.Checked)
                    {
                        Common.Eventarl = "1";
                    }
                    else if (checkBox3.Checked == false)
                    {
                        Common.Eventarl = "0";
                    }
                }

                //신한 접수하기
                Receipt.ReceiptContract(txtname.Text       //이름
                                      , txtpersonalno.Text //주민등록번호
                                      , txtsurgery.Text    //진료분야
                                      , txtmobile.Text     //휴대폰번호
                                      , txtaddress.Text    //주소
                                      , txtkind.Text       //내원경로
                                      , Common.SMS_YN      //문자수신여부
                                      , Common.Ptntinfo    //개인정보 활용 동의서 동의 여부
                                      , Common.Eventarl    //이벤트 수신 동의 여부
                                      ); //신환
                //접수후 초기화

            }
            catch (Exception ex)
            {
                Common.SetLog(ex.Message, 3);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            PersonInfoRule rule = new PersonInfoRule();
            rule.ShowDialog();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (this.checkBox1.Checked)
            {
                checkBox2.Checked = true;
                checkBox3.Checked = true;

                if (this.checkBox1 is RadCheckBox)
                {
                    ((FillPrimitive)this.checkBox1.ButtonElement.CheckMarkPrimitive.Children[0]).BackColor = Color.FromArgb(241, 148, 154);
                    ((FillPrimitive)this.checkBox1.ButtonElement.CheckMarkPrimitive.Children[0]).BackColor2 = Color.FromArgb(241, 148, 154);
                    //this.checkBox1.SuspendUpdate();
                }
            }
            else
            {
                checkBox2.Checked = false;
                checkBox3.Checked = false;

                if (this.checkBox1 is RadCheckBox)
                {
                    ((FillPrimitive)this.checkBox1.ButtonElement.CheckMarkPrimitive.Children[0]).BackColor = Color.White;
                    ((FillPrimitive)this.checkBox1.ButtonElement.CheckMarkPrimitive.Children[0]).BackColor2 = Color.White;
                }
            }
        }

        private void checkBox2_CheckStateChanged(object sender, EventArgs e)
        {
            if (this.checkBox2.Checked == true)
            {
                ((FillPrimitive)this.checkBox2.ButtonElement.CheckMarkPrimitive.Children[0]).BackColor = Color.FromArgb(241, 148, 154);
                ((FillPrimitive)this.checkBox2.ButtonElement.CheckMarkPrimitive.Children[0]).BackColor2 = Color.FromArgb(241, 148, 154);

                if (this.checkBox3.Checked == true)
                {
                    this.checkBox1.Checked = true;
                }
            }
            else
            {
                this.checkBox2.Checked = false;
                
                if (this.checkBox1.Checked == true)
                {
                    this.checkBox1.CheckStateChanged -= checkBox1_CheckedChanged;

                    ((FillPrimitive)this.checkBox1.ButtonElement.CheckMarkPrimitive.Children[0]).BackColor = Color.White;
                    ((FillPrimitive)this.checkBox1.ButtonElement.CheckMarkPrimitive.Children[0]).BackColor2 = Color.White;
                    this.checkBox1.Checked = false;

                    this.checkBox1.CheckStateChanged += checkBox1_CheckedChanged;
                }
                
                ((FillPrimitive)this.checkBox2.ButtonElement.CheckMarkPrimitive.Children[0]).BackColor = Color.White;
                ((FillPrimitive)this.checkBox2.ButtonElement.CheckMarkPrimitive.Children[0]).BackColor2 = Color.White;
            }

        }

        private void checkBox3_CheckStateChanged(object sender, EventArgs e)
        {
            if (this.checkBox3.Checked == true)
            {
                ((FillPrimitive)this.checkBox3.ButtonElement.CheckMarkPrimitive.Children[0]).BackColor = Color.FromArgb(241, 148, 154);
                ((FillPrimitive)this.checkBox3.ButtonElement.CheckMarkPrimitive.Children[0]).BackColor2 = Color.FromArgb(241, 148, 154);

                if (this.checkBox2.Checked == true)
                {
                    this.checkBox1.Checked = true;
                }
            }
            else
            {
                this.checkBox3.Checked = false;
                
                if (this.checkBox1.Checked == true)
                {
                    this.checkBox1.CheckStateChanged -= checkBox1_CheckedChanged;

                    ((FillPrimitive)this.checkBox1.ButtonElement.CheckMarkPrimitive.Children[0]).BackColor = Color.White;
                    ((FillPrimitive)this.checkBox1.ButtonElement.CheckMarkPrimitive.Children[0]).BackColor2 = Color.White;
                    this.checkBox1.Checked = false;

                    this.checkBox1.CheckStateChanged += checkBox1_CheckedChanged;
                }
                
                ((FillPrimitive)this.checkBox3.ButtonElement.CheckMarkPrimitive.Children[0]).BackColor = Color.White;
                ((FillPrimitive)this.checkBox3.ButtonElement.CheckMarkPrimitive.Children[0]).BackColor2 = Color.White;
            }
        }

        private void btnPreview_MouseMove(object sender, MouseEventArgs e)
        {
            this.btnPreview.BackgroundImage = Properties.Resources.이전2;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Common.Init();
            Common.PageMove("Main", this.Name, "1");
        }

        internal void initText()
        {
            init();
        }

        private void btnPreview_MouseLeave(object sender, EventArgs e)
        {
            this.btnPreview.BackgroundImage = Properties.Resources.이전1;
        }
    }
}