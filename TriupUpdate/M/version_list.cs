namespace Kiosk.TriupUpdate.M
{
    public class version_List
    {
        private string version_;
        public version_List(string Version_)
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
