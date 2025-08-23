using System;
using System.Windows.Forms;

namespace Kiosk.Class
{
    internal class InputEventHandlerClass
    {
        public class InputEventArgs : EventArgs
        {
            public Keys KeyCode { get; }

            public InputEventArgs(Keys keyCode)
            {
                KeyCode = keyCode;
            }
        }

        // 다른 클래스에서 이벤트를 구독
        public class InputListener
        {
            public InputListener(BaseForm baseform)
            {

                // 메인 폼의 이벤트에 핸들러를 등록합니다.
                baseform.InputEvent += MainForm_InputEventHandler;
            }

            private void MainForm_InputEventHandler(object sender, InputEventArgs e)
            {
                // 입력 이벤트를 처리하는 로직을 여기에 작성합니다.
                //Console.WriteLine("키 입력 이벤트: " + e.KeyCode);
                //MessageBox.Show("키 입력 이벤트: " + e.KeyCode);
            }
        }
    }
}
