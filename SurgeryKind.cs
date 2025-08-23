using Kiosk.Class;
using System;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;
using Telerik.WinControls.UI;

namespace Kiosk
{
    public partial class SurgeryKind : Form
    {
        //StringBuilder sb = new StringBuilder();
        string _surgerykind = string.Empty;
        string _input = string.Empty;
        private bool isColor1;
        //internal System.Windows.Forms.Timer timer;

        public SurgeryKind()
        {
            InitializeComponent();
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer | ControlStyles.UserPaint | ControlStyles.AllPaintingInWmPaint, true);
            this.UpdateStyles();

        }

        private void SurgeryKind_Load(object sender, EventArgs e)
        {
            this.FormBorderStyle = FormBorderStyle.None;
            this.StartPosition = FormStartPosition.CenterScreen;

            /*this.btnPreview.Visible = false;
            this.btnNext.Visible = false;

            this.btnPreview2.Visible = true;
            this.btnNext2.Visible = true;

            this.btnPreview2.Enabled = true;
            this.btnNext2.Enabled = false;

            this.radGridView1.EnableTheming = false;
            this.radGridView1.ThemeName = "ControlDefault";

            this.radGridView2.EnableTheming = false;
            this.radGridView2.ThemeName = "ControlDefault";

            this.radGridView1.Font = new Font("Noto Sans KR Regular", 18, FontStyle.Regular);
            this.radGridView2.Font = new Font("Noto Sans KR Regular", 18, FontStyle.Regular);

            

            #region 사용안함
            *//*
            sb.AppendLine($" with Surgery as (");
            sb.AppendLine($" SELECT DETL.BSE_CD AS CODE, DETL.BSE_CD_NM AS NAME, DETL.SEQ");
            sb.AppendLine($" FROM CODE_MASTER MSTR");
            sb.AppendLine($" , CODE_DETAIL DETL");
            sb.AppendLine($" WHERE MSTR.YKIHO = '22222222'");
            sb.AppendLine($" AND MSTR.USE_YN = TRUE");
            sb.AppendLine($" AND DETL.YKIHO = MSTR.YKIHO");
            sb.AppendLine($" AND DETL.COM_CD = MSTR.COM_CD");
            sb.AppendLine($" AND DETL.USE_YN = TRUE");
            sb.AppendLine($" AND MSTR.COM_CD_NM = '시술구분'");
            sb.AppendLine($" ORDER BY DETL.SEQ");
            sb.AppendLine($" )");
            sb.AppendLine($" select code");
            sb.AppendLine($" , '시술구분' as name");
            sb.AppendLine($" , max(case when seq=1 then name else null end) code_2");
            sb.AppendLine($" , max(case when seq=2 then name else null end) code_3");
            sb.AppendLine($" , max(case when seq=3 then name else null end) code_4");
            sb.AppendLine($" , max(case when seq=4 then name else null end) code_5");
            sb.AppendLine($" , max(case when seq=5 then name else null end) code_6");
            sb.AppendLine($" , max(case when seq=6 then name else null end) code_7");
            sb.AppendLine($" , max(case when seq=7 then name else null end) code_8");
            sb.AppendLine($" from Surgery");
            sb.AppendLine($" union all");
            sb.AppendLine($" select code");
            sb.AppendLine($" , '시술구분' as name");
            sb.AppendLine($" , max(case when seq=8 then name else null end) code_9");
            sb.AppendLine($" , max(case when seq=9 then name else null end) code_10");
            sb.AppendLine($" , max(case when seq=10 then name else null end) code_11");
            sb.AppendLine($" , max(case when seq=11 then name else null end) code_12");
            sb.AppendLine($" , max(case when seq=12 then name else null end) code_13");
            sb.AppendLine($" , max(case when seq=13 then name else null end) code_14");
            sb.AppendLine($" , max(case when seq=14 then name else null end) code_15");
            sb.AppendLine($" from Surgery");
            sb.AppendLine($" union all");
            sb.AppendLine($" select code");
            sb.AppendLine($" , '시술구분' as name");
            sb.AppendLine($" , '미지정' as code_16");
            sb.AppendLine($" , '' as code_17");
            sb.AppendLine($" , '' as code_18");
            sb.AppendLine($" , '' as code_19");
            sb.AppendLine($" , '' as code_20");
            sb.AppendLine($" , '' as code_21");
            sb.AppendLine($" , '' as code_22");
            sb.AppendLine($" from Surgery");
            sb.AppendLine($" where code = 'C01'");
            var dt10 = DBCommon.SelectData(sb.ToString());
            if (dt10 != null)
            {
                radGridView1.DataSource = dt10;
            }
            */
            /*
            sb.Clear();
            sb.AppendLine($"  with Surgery as (");
            sb.AppendLine($"  SELECT DETL.BSE_CD AS CODE, DETL.BSE_CD_NM AS NAME, DETL.SEQ");
            sb.AppendLine($"  FROM CODE_MASTER MSTR");
            sb.AppendLine($"  , CODE_DETAIL DETL");
            sb.AppendLine($"  WHERE MSTR.YKIHO = '22222222'");
            sb.AppendLine($"  AND MSTR.USE_YN = TRUE");
            sb.AppendLine($"  AND DETL.YKIHO = MSTR.YKIHO");
            sb.AppendLine($"  AND DETL.COM_CD = MSTR.COM_CD");
            sb.AppendLine($"  AND DETL.USE_YN = TRUE");
            sb.AppendLine($"  AND MSTR.COM_CD_NM = '내원경로'");
            sb.AppendLine($"  ORDER BY CODE, SEQ");
            sb.AppendLine($"  )");
            sb.AppendLine($"  select code");
            sb.AppendLine($"  , '진료분야' as name");
            sb.AppendLine($"  , max(case when code='C00' then name else null end) code_2");
            sb.AppendLine($"  , max(case when code='C01' then name else null end) code_3");
            sb.AppendLine($"  , max(case when code='C02' then name else null end) code_4");
            sb.AppendLine($"  , max(case when code='C03' then name else null end) code_5");
            sb.AppendLine($"  , max(case when code='C04' then name else null end) code_6");
            sb.AppendLine($"  , max(case when code='C05' then name else null end) code_7");
            sb.AppendLine($"  , max(case when code='C06' then name else null end) code_8");
            sb.AppendLine($"  from Surgery");
            sb.AppendLine($"  union all");
            sb.AppendLine($"  select code");
            sb.AppendLine($"  , '진료분야' as name");
            sb.AppendLine($"  , max(case when code='C07' then name else null end) code_9");
            sb.AppendLine($"  , max(case when code='C08' then name else null end) code_10");
            sb.AppendLine($"  , max(case when code='C09' then name else null end) code_11");
            sb.AppendLine($"  , max(case when code='C10' then name else null end) code_12");
            sb.AppendLine($"  , max(case when code='C11' then name else null end) code_13");
            sb.AppendLine($"  , max(case when code='C12' then name else null end) code_14");
            sb.AppendLine($"  , max(case when code='C13' then name else null end) code_15");
            sb.AppendLine($"  from Surgery");
            sb.AppendLine($"  union all");
            sb.AppendLine($"  select code");
            sb.AppendLine($"  , '진료분야' as name");
            sb.AppendLine($"  , '미지정' as code_16");
            sb.AppendLine($"  , '' as code_17");
            sb.AppendLine($"  , '' as code_18");
            sb.AppendLine($"  , '' as code_19");
            sb.AppendLine($"  , '' as code_20");
            sb.AppendLine($"  , '' as code_21");
            sb.AppendLine($"  , '' as code_22");
            sb.AppendLine($"  from Surgery");
            sb.AppendLine($"  where code = 'C01'");
            var dt20 = DBCommon.SelectData(sb.ToString());
            if (dt20 != null)
            {
                radGridView2.DataSource = dt20;
            }

            radGridView1.Rows[0].Height = 60;
            radGridView1.Rows[1].Height = 60;
            radGridView1.Rows[2].Height = 60;

            radGridView2.Rows[0].Height = 60;
            radGridView2.Rows[1].Height = 60;
            radGridView2.Rows[2].Height = 60;

            radGridView1.Rows[0].Cells["name"].Value = "";
            radGridView1.Rows[2].Cells["name"].Value = "";

            radGridView2.Rows[0].Cells["name"].Value = "";
            radGridView2.Rows[2].Cells["name"].Value = "";
            *//*
            #endregion

            */
            textBox1.Focus();
        }

        internal void initGrid()
        {
            if (radGridView1.RowCount > 0 || radGridView2.RowCount > 0)
            {
                radGridView1.Rows[0].IsCurrent = true;
                radGridView2.Rows[0].IsCurrent = true;
            }
        }

        private void btnPreview_Click(object sender, EventArgs e)
        {
            Common.PageMove("InputAddress", this.Name, "1");
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(_surgerykind))
            {
                Common.SurgeryKind = string.Empty;
            }
            else
            {
                Common.SurgeryKind = _surgerykind;
            }

            if (string.IsNullOrEmpty(_input))
            {
                Common.input = string.Empty;
            }
            else
            {
                Common.input = _input;
            }

            Common.PageMove("ReceiptInfo", this.Name, "1");

            radGridView1.Rows[0].IsCurrent = true;
            radGridView2.Rows[0].IsCurrent = true;
        }

        private void radGridView1_CellClick(object sender, Telerik.WinControls.UI.GridViewCellEventArgs e)
        {
            if (radGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].IsSelected)
            {
                if (e.ColumnIndex > -1)
                {
                    _surgerykind = radGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();
                    //radGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Style.BackColor = Color.Pink;
                    //Color.FromArgb(245, 180, 184);
                    radGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Style.BorderColor = Color.FromArgb(245, 180, 184);
                    radGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Style.ForeColor = Color.White;
                }
            }
            else
            {
                radGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Style.BackColor = Color.White;
                radGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Style.BorderColor = Color.FromArgb(245, 180, 184);
                radGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Style.ForeColor = Color.Black;
            }

            textBox1.Text = _surgerykind;
        }

        private void radGridView2_CellClick(object sender, GridViewCellEventArgs e)
        {
            if (radGridView2.Rows[e.RowIndex].Cells[e.ColumnIndex].IsSelected)
            {
                if (e.ColumnIndex > -1)
                {
                    _input = radGridView2.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();
                    radGridView2.Rows[e.RowIndex].Cells[e.ColumnIndex].Style.BackColor = Color.FromArgb(245, 180, 184);
                    radGridView2.Rows[e.RowIndex].Cells[e.ColumnIndex].Style.BorderColor = Color.FromArgb(245, 180, 184);
                    radGridView2.Rows[e.RowIndex].Cells[e.ColumnIndex].Style.ForeColor = Color.Black;
                }
            }
            else
            {
                radGridView2.Rows[e.RowIndex].Cells[e.ColumnIndex].Style.BackColor = Color.White;
                radGridView2.Rows[e.RowIndex].Cells[e.ColumnIndex].Style.BorderColor = Color.FromArgb(245, 180, 184);
                radGridView2.Rows[e.RowIndex].Cells[e.ColumnIndex].Style.ForeColor = Color.Black;
            }

            textBox2.Text = _input;

            if (_input != "" && _surgerykind != "")
            {
                //this.btnNext.Enabled = true;
                btnNext.BackgroundImage = Properties.Resources.다음2;
            }
            else
            {
                //this.btnNext.Enabled = false;
                
            }
        }

        private void btnPreview_MouseMove(object sender, MouseEventArgs e)
        {
            this.btnPreview.BackgroundImage = Properties.Resources.이전2;
        }

        private void radGridView1_CellFormatting_2(object sender, CellFormattingEventArgs e)
        {
            /**
            e.CellElement.ResetValue(LightVisualElement.GradientStyleProperty, ValueResetFlags.Local);
            e.CellElement.ResetValue(LightVisualElement.GradientPercentageProperty, ValueResetFlags.Local);

            //e.CellElement.DrawFill = false;

            //e.CellElement.BackColor = Color.White;
            //e.CellElement.BorderColor = Color.FromArgb(245, 180, 184);
            //e.CellElement.ForeColor = Color.Black;

            if (e.CellElement.IsSelected)
            {
                //MessageBox.Show("선택했슈");
                e.CellElement.BackColor = Color.FromArgb(245, 180, 184);
                e.CellElement.BackColor2 = Color.FromArgb(245, 180, 184);
                //e.CellElement.BackColor3 = Color.FromArgb(245, 180, 184);
                e.CellElement.BorderColor = Color.FromArgb(245, 180, 184);
                e.CellElement.ForeColor = Color.White;
            }
            else
            {
                e.CellElement.BackColor = Color.White;
                e.CellElement.BorderColor = Color.FromArgb(245, 180, 184);
                e.CellElement.ForeColor = Color.FromArgb(102, 102, 102);
                //e.CellElement.ResetValue(LightVisualElement.ForeColorProperty, ValueResetFlags.Local);
            }

            //e.CellElement.ResetValue(LightVisualElement.ForeColorProperty, ValueResetFlags.Local);
            //radGridView1.Refresh();
            //radGridView2.Refresh();
            */
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Common.Init();
            Common.PageMove("Main", this.Name, "1");
        }

        private void btnNext_MouseMove(object sender, MouseEventArgs e)
        {
            //this.btnNext.BackgroundImage = Properties.Resources.다음2;
            btnNext.BackgroundImage = Properties.Resources.다음2;
            ///btnNext.BackgroundImage = Properties.Resources.다음1;
        }

        private void btnPreview2_MouseMove(object sender, MouseEventArgs e)
        {
            this.btnPreview2.BackgroundImage = Properties.Resources.이전2;
        }

        private void btnPreview2_MouseLeave(object sender, EventArgs e)
        {
            this.btnPreview2.BackgroundImage = Properties.Resources.이전1;
        }
    }
}