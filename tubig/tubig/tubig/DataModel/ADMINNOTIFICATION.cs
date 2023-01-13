using System;
using System.Collections.Generic;
using System.Text;

namespace tubig.DataModel
{
    public class ADMINNOTIFICATION
    {
      
        public int adminnotificationID { get; set; }//

        public int orderID { get; set; }


        public string OrderStatus { get; set; } //dire mag send og status sa admin notif
        //public int order_CUSTOMERID { get; set; }
    }
}
