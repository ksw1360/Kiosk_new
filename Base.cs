using Kiosk.Class;
using System;
using System.Linq;
using System.Windows.Forms;

namespace Kiosk
{
    public partial class Base : Form
    {
        public static Base form;
        public Base()
        {
            InitializeComponent();
            form = this;
        }

        public static Timer Timer { get; private set; }

        private void Base_Load(object sender, EventArgs e)
        {
            Timer = new Timer();
            Timer.Interval = 1000 * 60 * 10; //10분
            Timer.Tick += Timer_Tick;
            Timer.Start();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            try
            {
                //Common Init
                Common.Init();

                //MessageBox.Show("입력이 10분 동안 없습니다.");
                Timer.Stop();
                Form specificForm = Application.OpenForms.OfType<Main>().FirstOrDefault();

                if (specificForm != null)
                {
                    //specificForm.Show();
                    specificForm.Visible = true;
                }

                // 다른 모든 폼을 닫습니다.
                for (int i = 0; i < Application.OpenForms.Count; i++)
                {
                    if (Application.OpenForms[i] != specificForm)
                    {
                        Application.OpenForms[i].Hide();
                    }
                }

                Timer.Start();
            }
            catch (Exception ex)
            {
                Common.SetLog(ex.Message, 3);
            }
        }
    }
}
