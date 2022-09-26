using System;
using System.Collections.Generic;
using System.Text;

namespace tubig.DataModel
{
   public class StationInfo
    {
        public static IEnumerable<StationInfo> Get()
        {
            return new List<StationInfo>
            {
                new StationInfo()
                {
                    StationName="Dici's Station Delivery", estimatedtime="30mins", distance="2km",ImageURL="shopnew.png"
                },
                 new StationInfo()
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
