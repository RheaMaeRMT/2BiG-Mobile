using System;
using System.Collections.Generic;
using System.Text;

namespace tubig.DataModel
{
   public  class WATER_GALLONS
   {
        //public static IEnumerable<StationGallonProducts> Get()
        //{
        //    return new List<StationGallonProducts>
        //    {
        //        new StationGallonProducts()
        //        {
        //             gallon_id="1",
        //             gallonType="20 Liter",
        //             GallonPrice="₱25.00",
        //             PhotoUrl="twentyLiter.jpg"

        //        },

        //         new StationGallonProducts()
        //        {
        //             gallon_id="2",
        //             gallonType="16 Liter",
        //             GallonPrice="₱20.00",
        //             PhotoUrl="sextenLiter.jpg"

        //        },

        //           new StationGallonProducts()
        //        {
        //             gallon_id="3",
        //             gallonType="10 Liter",
        //             GallonPrice="₱15.00",
        //             PhotoUrl="tenLiter.jpg"

        //        },
        //    };
        //}

        public string gallonType { get; set; }
        public string GallonPrice { get; set; }

        public string gallon_id { get; set; }
        public string PhotoUrl { get; set; }
    }
}
