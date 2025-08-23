using System.Net;
using System.IO;

namespace Kiosk.Class
{
    public static class DaumAdress
    {
        static string apiKey = "b88bc3fdfc918d3aec9a6a7f097ab26a";
        internal static string query = "삼전동 1181-1";

        static string apiUrl = $"https://dapi.kakao.com/v2/local/search/address.json?query={WebUtility.UrlEncode(query)}";

        public static void setaddress()
        {
            WebRequest request = WebRequest.Create(apiUrl);
            request.Headers.Add("Authorization", $"KakaoAK {apiKey}");

            try
            {
                WebResponse response = request.GetResponse();
                Stream dataStream = response.GetResponseStream();
                StreamReader reader = new StreamReader(dataStream);
                string responseFromServer = reader.ReadToEnd();

                // 응답 데이터를 처리하고 원하는 정보를 추출합니다.

                reader.Close();
                dataStream.Close();
                response.Close();
            }
            catch (WebException ex)
            {
                //Console.WriteLine("API 호출 중 오류 발생: " + ex.Message);
                Common.SetLog(ex.Message, 3);
            }
        }
    }
}