using System.Windows.Forms;

namespace Kiosk
{
    internal class MyMessageFilter : IMessageFilter
    {
        internal static Form form;

        public bool PreFilterMessage(ref Message m)
        {
            if (m.Msg >= 0x0200 && m.Msg <= 0x020A)
            {
                /*
                switch (form.Name)
                {
                    // 키보드 또는 마우스 입력이 감지되면 타이머 재시작                
                    case "Sub_NewPtnt":
                        ((Sub_NewPtnt)Application.OpenForms[0]).timer.Stop();
                        ((Sub_NewPtnt)Application.OpenForms[0]).timer.Start();
                        break;
                    case "InputMobileNo":
                        ((InputMobileNo)Application.OpenForms[0]).timer.Stop();
                        ((InputMobileNo)Application.OpenForms[0]).timer.Start();
                        break;
                    case "InputMobileNo_Add":
                        ((InputMobileNo_Add)Application.OpenForms[0]).timer.Stop();
                        ((InputMobileNo_Add)Application.OpenForms[0]).timer.Start();
                        break;
                    case "InputPersonalNO":
                        ((InputPersonalNO)Application.OpenForms[0]).timer.Stop();
                        ((InputPersonalNO)Application.OpenForms[0]).timer.Start();
                        break;
                    case "InputAddress":
                        ((InputAddress)Application.OpenForms[0]).timer.Stop();
                        ((InputAddress)Application.OpenForms[0]).timer.Start();
                        break;
                    case "SurgeryKind":
                        ((SurgeryKind)Application.OpenForms[0]).timer.Stop();
                        ((SurgeryKind)Application.OpenForms[0]).timer.Start();
                        break;
                    case "ReceiptInfo":
                        ((ReceiptInfo)Application.OpenForms[0]).timer.Stop();
                        ((ReceiptInfo)Application.OpenForms[0]).timer.Start();
                        break;
                }
                */
            }

            return false;
        }
    }
}