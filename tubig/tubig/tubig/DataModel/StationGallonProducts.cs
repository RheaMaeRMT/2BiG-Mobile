using System;
using System.Collections.Generic;
using System.Text;

namespace tubig.DataModel
{
   public  class StationGallonProducts
   {
        public static IEnumerable<StationGallonProducts> Get()
        {
            return new List<StationGallonProducts>
            {
                new StationGallonProducts()
                {
                     UserId="1",
                     GallonDescription="20 Liter",
                     GallonPrice="₱25.00",
                     PhotoUrl="twentyLiter.jpg"

                },

                 new StationGallonProducts()
                {
                     UserId="2",
                     GallonDescription="16 Liter",
                     GallonPrice="₱20.00",
                     PhotoUrl="sextenLiter.jpg"

                },

                   new StationGallonProducts()
                {
                     UserId="3",
                     GallonDescription="10 Liter",
                     GallonPrice="₱15.00",
                     PhotoUrl="tenLiter.jpg"

                },
            };
        }

        public string GallonDescription { get; set; }
        public string GallonPrice { get; set; }

        public string UserId { get; set; }
        public string PhotoUrl { get; set; }
    }
}
