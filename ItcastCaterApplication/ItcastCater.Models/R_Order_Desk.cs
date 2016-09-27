namespace ItcastCater.Models
{
    public class R_Order_Desk
    {
        private int _ROrderID;
        private int _OrderID;
        private int _DeskID;
        //private int? _DelFlag;
        //private DateTime? _SubTime;
        //private int? _SubBy;

        public int ROrderID
        {
            get
            {
                return _ROrderID;
            }

            set
            {
                _ROrderID = value;
            }
        }

        public int OrderID
        {
            get
            {
                return _OrderID;
            }

            set
            {
                _OrderID = value;
            }
        }

        public int DeskID
        {
            get
            {
                return _DeskID;
            }

            set
            {
                _DeskID = value;
            }
        }
    }
}
