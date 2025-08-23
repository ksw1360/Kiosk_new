using System.Collections.Generic;
using System.Data;

namespace Kiosk.Class
{
    internal class CreatorSmsFactory
    {
        internal SendSms CreateInstance(object planCode, List<Common.SendPatientModel> sendBizModelList)
        {
            DataTable dtSmsPlan = DBCommon.GetFIXSMSInfo(planCode);

            string autoYn = dtSmsPlan.Rows[0]["AUTO_YN"].ToString();

            switch (autoYn)
            {
                //설정안함
                case "0":
                    return null;
                //자동발송
                /*
                case "1":
                    if (planCode == "ReservationDayM")
                        return new SendReserveM(dtSmsPlan, sendBizModelList);

                    else if (planCode == "ReservationDay")
                        return new SendReserveNow(dtSmsPlan, sendBizModelList);

                    break;

                //수동발송
                case "2":
                    //history 에 저장하고 리턴하면될듯
                    return new SendManual(dtSmsPlan, sendBizModelList);

                //즉시발송
                case "3":
                    //if (planCode == "ReservationChange")
                    //    return new SendReservChange(dtSmsPlan, sendBizModelList);

                    return new SendNow(dtSmsPlan, sendBizModelList);
                */
                default:
                    return null;

            }

            return null;
        }
    }
}