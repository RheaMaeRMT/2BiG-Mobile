using System;
using System.Collections.Generic;
using System.Text;

namespace tubig.DataModel
{
   public  class PRODUCT_REFILL
    {
        public int DeliveryPrice { get; set; }
        public int PickUp_Price { get; set; }
        public string gallonType { get; set; }
        public string refillName { get; set; }

        public int refill_id { get; set; }
        public string waterType { get; set; }
    }
}
