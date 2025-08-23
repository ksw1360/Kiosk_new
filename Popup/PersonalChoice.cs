using System.Windows.Forms;

namespace Kiosk.Popup
{
    public partial class PersonalChoice : Form
    {
        public PersonalChoice()
        {
            InitializeComponent();
            this.CenterToScreen();
        }

        private void PersonalChoice_Load(object sender, System.EventArgs e)
        {
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.None;
            this.TopMost = true;

            timer1.Interval = 1000 * 5; //5초
            timer1.Start();
        }

        private void timer1_Tick(object sender, System.EventArgs e)
        {
            this.Close();
        }
    }
}
