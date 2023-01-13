using System;
using System.Collections.Generic;
using System.Text;

namespace YW2BIGNEW.DATAMODEL
{
    public class PRODUCT
    {

        public static IEnumerable<PRODUCT> Get()
        {
            return new List<PRODUCT>
            {
                new PRODUCT()
                {
                    PhotoUrl = "alkaline_raw.png"
                },
                 new PRODUCT()
                {
                    PhotoUrl = "mineral_raw.png"
                },


            };

        }
        public string productId { get; set; }
        public int productPrice { get; set; }
        public string productSize { get; set; }
        public string productType { get; set; }

        public string PhotoUrl { get; set; }
    }
}
