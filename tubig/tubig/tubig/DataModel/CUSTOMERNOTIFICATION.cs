using System;
using System.Collections.Generic;
using System.Text;

namespace tubig.DataModel
{
   public  class CUSTOMERNOTIFICATION
    {
        public string OrderStatus { get; set; }
        public string notifID { get; set; }

     //   public string orderFrom_store { get; set; }
        public string orderDeliveryType { get; set; }
        public string orderType { get; set; }
        public int orderQuantity { get; set; }
        public int orderPrice { get; set; }
        public string orderID { get; set; }
        public string OrderProductType { get; set; }
        public string OrderReservationDate { get; set; }
        public int orderTotalAmount { get; set; }
       
        public int order_CUSTOMERID { get; set; }
        public string orderDateTime { get; set; }
    }
}
