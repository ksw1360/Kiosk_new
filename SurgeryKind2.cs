using Kiosk.Class;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Kiosk
{
    public partial class SurgeryKind2 : Form
    {
        private string _surgerykind;
        private string _input;

        public SurgeryKind2()
        {
            InitializeComponent();
        }

        private void SurgeryKind2_Load(object sender, EventArgs e)
        {
            this.FormBorderStyle = FormBorderStyle.None;
            this.StartPosition = FormStartPosition.CenterScreen;
            this.TopMost = true;

            this.btnPreview.Visible = false;
            this.btnNext.Visible = false;

            this.btnPreview2.Visible = true;
            this.btnNext2.Visible = true;

            this.btnPreview2.Enabled = true;
            this.btnNext2.Enabled = false;

            this.btnPreview2.BackgroundImage = Properties.Resources.이전2;

            init();
            initGrid();
        }

        internal void init()
        {
            if (radGridView1.RowCount > 0)
            {
                radGridView1.Rows[0].IsCurrent = true;
            }
            if (radGridView2.RowCount > 0)
            {
                radGridView2.Rows[0].IsCurrent = true;
            }
        }

        private void initGrid()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($" SELECT DETL.BSE_CD AS CODE, DETL.BSE_CD_NM AS NAME, DETL.SEQ ");
            sb.AppendLine($"   FROM CODE_MASTER MSTR ");
            sb.AppendLine($"      , CODE_DETAIL DETL ");
            sb.AppendLine($" WHERE MSTR.YKIHO = '{Common.YKIHO}' ");
            sb.AppendLine($"   AND MSTR.USE_YN = TRUE ");
            sb.AppendLine($"   AND DETL.YKIHO = MSTR.YKIHO ");
            sb.AppendLine($"   AND DETL.COM_CD = MSTR.COM_CD ");
            sb.AppendLine($"   AND DETL.USE_YN = TRUE ");
            sb.AppendLine($"   AND MSTR.COM_CD_NM = '시술구분' ");
            sb.AppendLine($" ORDER BY DETL.SEQ ");
            var dt10 = DBCommon.SelectData(sb.ToString());
            //radGridView1.DataSource = dt10;

            DataTable dataTable = new DataTable();
            dataTable.Columns.Add("code_2");
            dataTable.Columns.Add("code_3");
            dataTable.Columns.Add("code_4");
            dataTable.Columns.Add("code_5");
            dataTable.Columns.Add("code_6");
            radGridView1.DataSource = dataTable;

            try
            {
                for (int i = 0; i < dt10.Rows.Count; i++)
                {
                    DataRow row = dataTable.NewRow();

                    int rows = 0;
                    rows = i * 4;
                    /*
                    if (i == 1)
                    {
                        rows = i + 4;
                    }
                    else if(i==2)
                    {
                        rows = i + 8;
                    }else if(i==3)
                    {
                        rows = i + 12;
                    }
                    */

                    row["code_2"] = dt10.Rows[rows]["Name"].ToString();
                    row["code_3"] = dt10.Rows[rows + 1]["Name"].ToString();
                    row["code_4"] = dt10.Rows[rows + 2]["Name"].ToString();
                    row["code_5"] = dt10.Rows[rows + 3]["Name"].ToString();
                    row["code_6"] = dt10.Rows[rows + 4]["Name"].ToString();

                    dataTable.Rows.Add(row);
                }
            }
            catch (Exception ex)
            {

            }

            sb = new StringBuilder();
            sb.AppendLine($" SELECT DETL.BSE_CD AS CODE, DETL.BSE_CD_NM AS NAME, DETL.SEQ");
            sb.AppendLine($" FROM CODE_MASTER MSTR");
            sb.AppendLine($" , CODE_DETAIL DETL");
            sb.AppendLine($" WHERE MSTR.YKIHO = '{Common.YKIHO}'");
            sb.AppendLine($" AND MSTR.USE_YN = TRUE");
            sb.AppendLine($" AND DETL.YKIHO = MSTR.YKIHO");
            sb.AppendLine($" AND DETL.COM_CD = MSTR.COM_CD");
            sb.AppendLine($" AND DETL.USE_YN = TRUE");
            sb.AppendLine($" AND MSTR.COM_CD_NM = '내원경로'");
            sb.AppendLine($" ORDER BY DETL.SEQ");
            var dt20 = DBCommon.SelectData(sb.ToString());
            //radGridView2.DataSource = dt20;

            DataTable dataTable2 = new DataTable();
            dataTable2.Columns.Add("code_2");
            dataTable2.Columns.Add("code_3");
            dataTable2.Columns.Add("code_4");
            dataTable2.Columns.Add("code_5");
            dataTable2.Columns.Add("code_6");
            radGridView2.DataSource = dataTable2;

            try
            {
                for (int i = 0; i < dt20.Rows.Count; i++)
                {
                    DataRow row = dataTable2.NewRow();

                    int rows = 0;
                    rows = i * 4;
                    /*
                    if (i == 1)
                    {
                        rows = i + 4;
                    }
                    else if(i==2)
                    {
                        rows = i + 8;
                    }else if(i==3)
                    {
                        rows = i + 12;
                    }
                    */

                    row["code_2"] = dt20.Rows[rows]["Name"].ToString();
                    row["code_3"] = dt20.Rows[rows + 1]["Name"].ToString();
                    row["code_4"] = dt20.Rows[rows + 2]["Name"].ToString();
                    row["code_5"] = dt20.Rows[rows + 3]["Name"].ToString();
                    row["code_6"] = dt20.Rows[rows + 4]["Name"].ToString();

                    dataTable2.Rows.Add(row);
                }
            }
            catch (Exception ex)
            {

            }

            for (int i = 0; i < radGridView1.ColumnCount; i++)
            {
                radGridView1.Columns[i].ReadOnly = true;
                radGridView1.Columns[i].Width = 187;
            }

            for (int i = 0; i < radGridView2.ColumnCount; i++)
            {
                radGridView2.Columns[i].ReadOnly = true;
                radGridView2.Columns[i].Width = 187;
            }

            for (int j = 0; j < radGridView1.RowCount; j++)
            {
                radGridView1.Rows[j].Height = 97;
            }

            for (int k = 0; k < radGridView2.RowCount; k++)
            {
                radGridView2.Rows[k].Height = 97;
            }

            for (int i = 0; i < radGridView1.Columns.Count; i++)
            {
                radGridView1.Columns[i].WrapText = true;
                radGridView1.Columns[i].TextAlignment = ContentAlignment.MiddleCenter;
            }

            for (int i = 0; i < radGridView2.Columns.Count; i++)
            {
                radGridView2.Columns[i].WrapText = true;
                radGridView2.Columns[i].TextAlignment = ContentAlignment.MiddleCenter;
            }

            try
            {
                if (radGridView1.Rows.Count > 0 || radGridView2.Rows.Count > 0)
                {
                    radGridView1.Rows[0].IsCurrent = true;
                    radGridView2.Rows[0].IsCurrent = true;
                }
            }
            catch (Exception ex)
            {

            }
        }

        private void btnPreview2_Click(object sender, EventArgs e)
        {
            Common.PageMove("InputAddress", this.Name, "1");
        }

        private void btnNext2_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(_surgerykind))
            {
                Common.SurgeryKind = _surgerykind;
            }
            if (!string.IsNullOrEmpty(_input))
            {
                Common.input = _input;
            }
            Common.PageMove("ReceiptInfo", this.Name, "1");
        }

        private void radGridView1_CellClick(object sender, Telerik.WinControls.UI.GridViewCellEventArgs e)
        {
            if (radGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].IsSelected)
            {
                if (e.ColumnIndex > -1)
                {
                    _surgerykind = radGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();
                    radGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Style.BorderColor = Color.FromArgb(245, 180, 184);
                    radGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Style.ForeColor = Color.White;
                }
            }
        }

        private void radGridView2_CellClick(object sender, Telerik.WinControls.UI.GridViewCellEventArgs e)
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
        }

        private void btnPreview2_MouseMove(object sender, MouseEventArgs e)
        {
            this.btnPreview2.BackgroundImage = Properties.Resources.이전2;
        }

        private void button14_Click(object sender, EventArgs e)
        {
            Common.Init();
            Common.PageMove("Main", this.Name, "1");
        }

        private void btnPreview2_MouseLeave(object sender, EventArgs e)
        {
            this.btnPreview2.BackgroundImage = Properties.Resources.이전1;
        }
    }
}