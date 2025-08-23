using Kiosk.Class;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace Kiosk
{
    public partial class CommonForm : Form
    {
        public CommonForm()
        {
            InitializeComponent();

            this.Size = new Size(1080, 1920);

            Form login = new LogIn();
            login.Owner = this;
            login.TopMost = true;

            //초기화면
            Main main = new Main();
            main.Hide();
            main.Owner = this;
            main.TopMost = true;
            Common.Main = main;

            //이름입력
            Sub_NewPtnt sub_NewPtnt = new Sub_NewPtnt();
            sub_NewPtnt.Hide();
            sub_NewPtnt.Owner = this;
            sub_NewPtnt.TopMost = true;
            Common.Sub_NewPtnt = sub_NewPtnt;

            //신환 핸드폰번호 입력
            InputMobileNo inputMobileNo = new InputMobileNo();
            inputMobileNo.Hide();
            inputMobileNo.Owner = this;
            inputMobileNo.TopMost = true;
            Common.InputMobileNo = inputMobileNo;

            //구환 핸드폰번호
            InputMobileNo_Add inputMobileNo_Add = new InputMobileNo_Add();
            inputMobileNo_Add.Hide();
            inputMobileNo_Add.Owner = this;
            inputMobileNo_Add.TopMost = true;
            Common.InputMobileNo_Add = inputMobileNo_Add;

            //주민등록번호 입력
            InputPersonalNO inputPersonalNO = new InputPersonalNO();
            inputPersonalNO.Hide();
            inputPersonalNO.Owner = this;
            inputPersonalNO.TopMost = true;
            Common.InputPersonalNO = inputPersonalNO;

            //주소 입력
            InputAddress inputAddress = new InputAddress();
            inputAddress.Hide();
            inputAddress.Owner = this;
            inputAddress.TopMost = true;
            Common.InputAddress = inputAddress;

            //시술 구분 입력
            SurgeryKind2 surgeryKind = new SurgeryKind2();
            surgeryKind.Hide();
            surgeryKind.Owner = this;
            surgeryKind.TopMost = true;
            Common.SurgeryKindForm = surgeryKind;

            //접수내역
            ReceiptInfo receipt = new ReceiptInfo();
            receipt.Hide();
            receipt.Owner = this;
            receipt.TopMost = true;
            Common.ReceiptInfo = receipt;

            this.Visible = true;
            login.ShowDialog();
        }
    }
}
