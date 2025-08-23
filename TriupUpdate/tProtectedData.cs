namespace Kiosk.TriupUpdate
{
    public class tProtectedData
    {
        #region Field
        #endregion

        #region Method
        public static string Protect(string str)
        {
            // todo : 암호화 -> window 정품이 아닐 시, 빌드한 곳이 아닌 다른 pc에서 암호화 및 복구화 시 key관련 오류 뜸..

            //string protect = "";

            //if (string.IsNullOrEmpty(str) != true)
            //    protect = Convert.ToBase64String(ProtectedData.Protect(Encoding.UTF8.GetBytes(str), null, DataProtectionScope.CurrentUser));

            //return protect;
            return str;
        }

        public static string UnProtect(string str)
        {
            // todo : 복구화 -> window 정품이 아닐 시, 빌드한 곳이 아닌 다른 pc에서 암호화 및 복구화 시 key관련 오류 뜸..

            //string unProtect = "";

            //if (string.IsNullOrEmpty(str) != true)
            //    unProtect = Encoding.UTF8.GetString(ProtectedData.Unprotect(Convert.FromBase64String(str), null, DataProtectionScope.CurrentUser));

            //return unProtect;
            return str;
        }

        #endregion
    }
}
