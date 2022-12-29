using System;
using System.Collections.Generic;
using System.Text;

namespace tubig.DataModel
{
    public class WATER_ORDER
    {
        public string OrderFrom_store { get; set; }
        public string OrderType { get; set; }
        public int  OrderQuantity { get; set; }
        public int  OrderBorrowGallons { get; set; }
        public int  OrderOwnGallons { get; set; }
        public string OrderProductType { get; set; }
        public string OrderReservationDate { get; set; }

        public string OrderStatus { get; set; }
    }
}
