using Kiosk.Class;
using System;
using System.Windows.Forms;

namespace Kiosk.Temp
{
    public partial class SerialPortSearch : Form
    {
        // 이벤트를 정의합니다.
        //public event EventHandler<InputEventArgs> InputEvent;
        //internal Action<object, InputEventHandlerClass.InputEventArgs> InputEvent { get; set; }

        public SerialPortSearch()
        {
            InitializeComponent();
        }

        private void SerialPortSearch_Load(object sender, EventArgs e)
        {
            //PortSearch();

            //InputEventHandlerClass inputEventHandlerClass = new InputEventHandlerClass();
        }

        private void PortSearch()
        {
            try
            {
                //GetSerialPorts();
            }
            catch (Exception ex)
            {
                Common.SetLog(ex.Message, 4);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.DoEvents();
            Application.Exit();
        }
    }
}