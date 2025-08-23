using Kiosk.Class;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using Telerik.WinControls.Primitives;

namespace Kiosk.Popup
{
    public partial class Ptnt_List_Popup : Form
    {
        private PtntInfoShow[] userControls;
        internal DataTable dt;
        internal List<string> List = new List<string>();
        private bool isColor1 = true;

        public static Ptnt_List_Popup ptnt_list_popup;

        private List<System.Windows.Forms.Control> MyControls = new List<System.Windows.Forms.Control>();

        int userControlCount = 0;

        public bool Check { get; internal set; }

        VScrollBar vScrollBar1 = new VScrollBar();

        public Ptnt_List_Popup()
        {
            InitializeComponent();
            this.CenterToScreen();
            ptnt_list_popup = this;
            //Ptnt_List_Popup.ptnt_list_popup.ptntInfo_Click(this, e);
        }

        private void CreateDynamicTextBox()
        {
            try
            {
                PtntInfoShow last = null;

                if (dt != null)
                {
                    for (int idx = 0; idx < dt.Rows.Count; idx++)
                    {
                        PtntInfoShow ptntInfo = new PtntInfoShow();
                        //ptntInfo.dt = dt;
                        ptntInfo.Name = "ptntInfoShow" + idx;
                        ptntInfo.Dock = DockStyle.Top;
                        //ptntInfo.Location = new Point(10, 10 + idx * 70);
                        //ptntInfo.Size = new Size(713, 74);
                        //ptntInfo.Dock = DockStyle.Top;
                        //ptntInfo.Cursor = Cursors.Arrow; // 또는 Cursors.None;
                        //ptntInfo.BorderStyle = BorderStyle.FixedSingle;
                        //ptntInfo.Enabled = false;
                        /*
                        ptntInfo.radTextBox1.Text = dt.Rows[idx]["PAT_NM"].ToString();
                        ptntInfo.radTextBox2.Text = dt.Rows[idx]["PAT_BTH"].ToString();
                        ptntInfo.radTextBox3.Text = dt.Rows[idx]["MOBILE_NO"].ToString();
                        ptntInfo.radTextBox4.Text = dt.Rows[idx]["PAT_NO"].ToString();
                        */
                        ptntInfo.radLabel1.Text = dt.Rows[idx]["PAT_NM"].ToString();
                        ptntInfo.radLabel2.Text = dt.Rows[idx]["PAT_BTH"].ToString();
                        ptntInfo.radLabel3.Text = dt.Rows[idx]["MOBILE_NO"].ToString();
                        ptntInfo.radLabel4.Text = dt.Rows[idx]["PAT_NO"].ToString();

                        ptntInfo.radLabel1.TextAlignment = ContentAlignment.MiddleCenter;
                        ptntInfo.radLabel2.TextAlignment = ContentAlignment.MiddleCenter;
                        ptntInfo.radLabel3.TextAlignment = ContentAlignment.MiddleCenter;
                        ptntInfo.radLabel4.TextAlignment = ContentAlignment.MiddleCenter;

                        userControlCount++;
                        panel1.Controls.Add(ptntInfo);
                        this.MyControls.Add(ptntInfo);

                        //첫행이 무조건 처음에 선택되도록
                        if (ptntInfo != null)
                        {
                            // 마지막 인덱스 선택
                            if (idx == dt.Rows.Count - 1)
                            {
                                PtntInfoShow currentControl = MyControls[0] as PtntInfoShow;

                                if (currentControl != null)
                                {
                                    if (currentControl.Name == ptntInfo.Name)
                                    {
                                        currentControl.SetSelectColor();

                                        Common.List.Clear();
                                        Common.List.Add(currentControl.radLabel1.Text);
                                        Common.List.Add(currentControl.radLabel2.Text);
                                        Common.List.Add(currentControl.radLabel3.Text);
                                        Common.List.Add(currentControl.radLabel4.Text);
                                    }
                                }

                                last = ptntInfo;
                            }
                        }
                    }


                    if (last != null)
                    {
                        last.selectButton.PerformClick();
                    }

                    //radGridView1.DataSource = dt;
                }
            }
            catch (Exception ex)
            {
                Common.SetLog(ex.Message, 4);
            }
        }

        private void Ptnt_List_Popup_Load(object sender, EventArgs e)
        {
            //this.Text = string.Empty;
            //this.FormBorderStyle = FormBorderStyle.None;
            this.MyControls.Clear();

            // 테두리 스타일을 설정합니다.
            //panel1.PanelElement.PanelBorder.Visibility = Telerik.WinControls.ElementVisibility.Visible;
            //panel1.PanelElement.PanelBorder.ForeColor = Color.Black; // 테두리 색상을 변경하려면 원하는 색상으로 대체하세요.
            //panel1.PanelElement.PanelBorder.BorderThickness = new Padding(10); // 테두리 두께를 조절하려면 원하는 값으로 대체하세요.

            CreateDynamicTextBox();

            //button2.Focus();
            //this.label1.Focus();
            this.panel1.HorizontalScrollbar.Visible = false;
            this.panel1.VerticalScrollbar.Width = 50;
            //this.panel1.VerticalScrollbar.ScrollBarElement.ForeColor = Color.Black;
            //this.panel1.VerticalScrollbar.ScrollBarElement.HighlightColor = Color.Black;
            //this.panel1.VerticalScrollbar.ScrollBarElement.FocusBorderColor = Color.Black;
            //this.panel1.VerticalScrollbar.ScrollBarElement.BackColor = Color.Black;
            //this.panel1.VerticalScrollbar.ScrollBarElement.RippleAnimationColor = Color.Black;
            //this.panel1.VerticalScrollbar.ScrollBarElement.ShadowColor = Color.Black;

            if (panel1.VerticalScrollbar.ScrollBarElement.Children != null && panel1.VerticalScrollbar.ScrollBarElement.Children.Count > 2)
            {
                if (panel1.VerticalScrollbar.ScrollBarElement.Children[1] is FillPrimitive)
                    ((FillPrimitive)panel1.VerticalScrollbar.ScrollBarElement.Children[1]).BackColor = Color.LightGray;
            }

            panel1.VerticalScrollbar.ScrollBarElement.ThumbElement.ThumbFill.BackColor = Color.FromArgb(170, 170, 170);
            panel1.VerticalScrollbar.ScrollBarElement.ThumbElement.ThumbFill.GradientStyle = Telerik.WinControls.GradientStyles.Solid;

            panel1.VerticalScrollbar.ScrollBarElement.FirstButton.ButtonFill.BackColor = Color.FromArgb(170, 170, 170);
            panel1.VerticalScrollbar.ScrollBarElement.FirstButton.ButtonFill.GradientStyle = Telerik.WinControls.GradientStyles.Solid;

            panel1.VerticalScrollbar.ScrollBarElement.SecondButton.ButtonFill.BackColor = Color.FromArgb(170, 170, 170);
            panel1.VerticalScrollbar.ScrollBarElement.SecondButton.ButtonFill.GradientStyle = Telerik.WinControls.GradientStyles.Solid;

            panel1.VerticalScrollbar.ScrollBarElement.BorderElement.Visibility = Telerik.WinControls.ElementVisibility.Collapsed;

            this.panel1.Update();
            this.panel1.SuspendUpdate();
            this.TopMost = true;
        }

        private void VScrollBar1_Scroll(object sender, ScrollEventArgs e)
        {
            /*
            if (panel3.Controls.Count > 0)
            {
                panel3.VerticalScroll.Value = e.NewValue;
            }
            */
        }

        private void SetPanelScrollbarWidth(Panel panel, int width)
        {
            if (panel != null)
            {
                foreach (Control control in panel.Controls)
                {
                    if (control is VScrollBar)
                    {
                        // 수직 스크롤바 너비 조절
                        ((VScrollBar)control).Width = width;
                    }
                    else if (control is HScrollBar)
                    {
                        // 수평 스크롤바 너비 조절
                        //((HScrollBar)control).Height = width;
                    }
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.No;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (Common.List != null)
            {
                this.List = Common.List;
                string text = List[2].Trim();
                if (text.Length >= 13)
                    text = string.Format($"{text.Substring(0, 4)}****{text.Substring(8, 5)}");
                PopupMessageQuestion popup = new PopupMessageQuestion();
                popup.panel4.Visible = true;
                popup.Names = "";
                //"선택하신 정보는 다음과 같습니다.";
                popup.messages = List[0].Trim() + " " + text;
                popup.result = "으로 접수하시겠습니까?";
                DialogResult dr = popup.ShowDialog();
                if (dr == DialogResult.OK)
                {
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
            }
        }

        internal void ptntInfo_Click(object sender, EventArgs e)
        {
            PtntInfoShow ptntInfoShow = sender as PtntInfoShow;
            for (int i = 0; i < MyControls.Count; i++)
            {
                PtntInfoShow currentControl = MyControls[i] as PtntInfoShow;

                if (currentControl != null)
                {
                    if (currentControl.Name == ptntInfoShow.Name)
                    {
                        currentControl.SetSelectColor();
                    }
                    else
                    {
                        currentControl.UnSetSelectColor();
                    }
                }
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {
            /*if (panel1.BorderStyle == BorderStyle.FixedSingle)
            {
                int thickness = 3;//it's up to you
                int halfThickness = thickness / 2;
                using (Pen p = new Pen(Color.Black, thickness))
                {
                    e.Graphics.DrawRectangle(p, new Rectangle(0,
                                                              0,
                                                              this.Width,
                                                              this.Height));
                }
            }*/
        }
    }
}