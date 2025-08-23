namespace Kiosk.TriupUpdate
{
    public class cMasterItem
    {
        public int ITEM { get; set; }
        public string IP { get; set; }
        public string ID { get; set; }
        public string PASSWORD { get; set; }
        public int PORT { get; set; }
        public string NAME { get; set; }
        public int USE_E { get; set; }
        public int USE_W { get; set; }

        // 나중에 암호화된 정보 풀어야할때 사용 예정
        public string ID_DESC
        {
            get
            {
                if (ID.Length > 0)
                    return ID;
                else
                    return ID;
            }
        }
    }
}
