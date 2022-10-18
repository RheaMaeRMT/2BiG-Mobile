using System;
using System.Collections.Generic;
using System.Text;

namespace tubig
{
   public  class WRSinfo
    {
        public static IEnumerable<WRSinfo> Get()
        {
            return new List<WRSinfo>
            {

                new WRSinfo()
                {
                    storename="Aqua Refilling Station", status="Open", ImageURL="water_ref.png"
                },

                 new WRSinfo()
                {
                    storename="Tubigan", status="Close", ImageURL="water.png"
                },

                  new WRSinfo()
                {
                    storename="Ja Station", status="Close", ImageURL="water_ref.png"
                },

            };
        }

        public  string storename { get; set; }
        public string location { get; set; }
        public string status { get; set; }

        public string ImageURL { get; set; }
    }
}
