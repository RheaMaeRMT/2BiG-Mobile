using System;
using System.Collections.Generic;
using System.Text;

namespace tubig.DataModel
{
   public class DeliveryInfo
    {
        public static IEnumerable<DeliveryInfo> Get()
        {
            return new List<DeliveryInfo>
            {
                new DeliveryInfo()
                {
                    StationName="Dici's Station Delivery", 
                    estimatedtime="30mins",
                    distance="2km",
                    ImageURL="shopnew.png",
                    statusOfOrder="Your order is accepted"
                },
                 new DeliveryInfo()
                {
                    StationName="Ja's Station Delivery", 
                     estimatedtime="30mins", 
                     distance="2km",
                     ImageURL="shopnew.png",
                     statusOfOrder="Your order is declined"

                },

            };

        }

             public string StationName { get; set; }
             public string estimatedtime { get; set; }
             public string distance { get; set; }
             public string ImageURL { get; set; }
             public string Estimatedime_Distance => $"{estimatedtime} | {distance}";

             public string statusOfOrder { get; set; }

    }
       
    
}
