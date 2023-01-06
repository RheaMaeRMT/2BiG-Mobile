using System;
using System.Collections.Generic;
using System.Text;

namespace tubig.DataModel
{
    public class WATER_ORDER
    {
        public string OrderFrom_store { get; set; }
        public string OrderType { get; set; }
        public string  OrderQuantity { get; set; }
        public string OrderBorrowGallons { get; set; }
        public string OrderOwnGallons { get; set; }
        public string OrderProductType { get; set; }
        public string OrderReservationDate { get; set; }

        public string OrderStatus { get; set; }
    }
}
