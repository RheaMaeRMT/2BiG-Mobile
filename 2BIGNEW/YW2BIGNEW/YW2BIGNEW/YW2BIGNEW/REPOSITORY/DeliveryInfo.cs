using System;
using System.Collections.Generic;
using System.Text;

namespace YW2BIGNEW.REPOSITORY
{
    public class DeliveryInfo
    {
        public static IEnumerable<DeliveryInfo> Get()
        {
            return new List<DeliveryInfo>
            {
                new DeliveryInfo()
                {
                    StationName="Dici's Station Delivery", estimatedtime="30mins", distance="2km",ImageURL="shopnew.png"
                },
                 new DeliveryInfo()
                {
                    StationName="Ja's Station Delivery", estimatedtime="30mins", distance="2km",ImageURL="shopnew.png"
                },

            };

        }

        public string StationName { get; set; }
        public string estimatedtime { get; set; }
        public string distance { get; set; }
        public string ImageURL { get; set; }
        public string Estimatedime_Distance => $"{estimatedtime} | {distance}";



    }
}
