namespace Kiosk.TriupUpdate.M
{
    class Fetch_Version_List
    {
        private string version_;
        public Fetch_Version_List(string Version_)
        {
            this.version_ = Version_;

        }
        public string Version_
        {
            get
            {
                return version_;
            }
            set
            {

                version_ = value;
            }
        }
    }
    class EXE_Version_List
    {
        private string version_;
        public EXE_Version_List(string Version_)
        {
            this.version_ = Version_;

        }
        public string Version_
        {
            get
            {
                return version_;
            }
            set
            {

                version_ = value;
            }
        }
    }
}
