using System;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;
using Telerik.WinControls.UI;

namespace Kiosk.TriupUpdate
{
    public partial class FrmWaitingBar : Telerik.WinControls.UI.RadForm
    {
        #region Field

        Thread thread;
        ParameterizedThreadStart threadParameterized = null;
        string waitingText = string.Empty;

        #endregion

        #region Constructor

        public FrmWaitingBar()
        {
            InitializeComponent();

            //this.lblWaiting.Font = new Font(FontLibrary.GetFont(FontLibrary.FontStyle.Noto_Sans_CJK_KR_Regular), 9);
            this.lblWaiting.Font = new Font("맑은 고딕", 9F);

            this.StartPosition = FormStartPosition.CenterParent;
        }

        #endregion

        #region Property
        #endregion

        #region Method

        /// <summary>
        /// waiting show
        /// </summary>
        /// <param name="waitingText"></param>
        public void WaitingShow(string waitingText)
        {
            if (string.IsNullOrEmpty(waitingText))
                waitingText = "로딩중...";

            this.waitingText = waitingText;

            if (this.thread != null)
                this.thread.Abort();

            this.threadParameterized = this.ThreadProcedure;

            this.thread = new Thread(new ParameterizedThreadStart(this.threadParameterized));
            this.thread.Start();

            Thread.Sleep(100);
        }

        /// <summary>
        /// waiting Close
        /// </summary>
        /// <param name="form"></param>
        public void WaitingClose(object form = null)
        {
            this.waitingBar.StopWaiting();

            if (form is RadForm)
                ((RadForm)form).Focus();
            else if (form is Form)
                ((Form)form).Focus();
        }

        /// <summary>
        /// thread Procedure
        /// </summary>
        /// <param name="obj"></param>
        private void ThreadProcedure(object obj)
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new MethodInvoker(delegate
                {
                    this.StartWaitingProcess();
                }));
            }
            else
            {
                this.StartWaitingProcess();
            }

            if (this != null)
                this.ShowDialog();

        }

        /// <summary>
        /// 웨이팅 프로세스시작
        /// </summary>
        private void StartWaitingProcess()
        {
            this.lblWaiting.Text = this.waitingText;
            this.Visible = false;
            this.TopMost = true;
            this.waitingBar.StartWaiting();
        }

        /// <summary>
        /// 웨이팅 프로세스 종료
        /// </summary>
        private void StopWaitingProcess()
        {
            this.Visible = false;
            this.Close();
            this.Dispose();
        }

        #endregion

        #region Event

        private void waitingBar_WaitingStopped(object sender, EventArgs e)
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new MethodInvoker(delegate
                {
                    this.StopWaitingProcess();
                }));
            }
            else
            {
                this.StopWaitingProcess();
            }
        }

        private void FrmWaitingBar_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (this.thread != null && this.thread.IsAlive)
            {
                this.thread = null;
                this.threadParameterized = null;
            }
        }

        #endregion
    }
}
