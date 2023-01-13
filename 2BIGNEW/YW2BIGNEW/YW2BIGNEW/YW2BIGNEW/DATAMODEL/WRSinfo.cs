using System;
using System.Collections.Generic;
using System.Text;

namespace YW2BIGNEW.DATAMODEL
{
    public class WRSinfo
    {
        public static IEnumerable<WRSinfo> Get()
        {
            return new List<WRSinfo>
            {

                new WRSinfo()
                {
                    storename="Aqua Refilling Station", status="Open", ImageURL="water_ref.png", distance="2km"

                },

                 new WRSinfo()
                {
                    storename="Tubigan", status="Close", ImageURL="water.png", distance="1km"
                },

                  new WRSinfo()
                {
                    storename="Ja Station", status="Close", ImageURL="water_ref.png", distance="10m"
                },

            };
        }

        public string storename { get; set; }
        public string distance { get; set; }
        public string status { get; set; }
        public string ImageURL { get; set; }

        public string Status_Distance => $"{status} | {distance}";
    }
}
