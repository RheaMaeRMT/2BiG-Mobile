﻿using System;
using System.Collections.Generic;
using System.Text;

namespace YW2BIGNEW.REPOSITORY
{
    public class StationWaterProduct
    {
        public static IEnumerable<StationWaterProduct> Get()
        {
            return new List<StationWaterProduct>
            {
                new StationWaterProduct()
                {   UserId="1",

                    ProdDescription="Alkaline",
                    WaterPrice="₱25.00",
                    PhotoUrl="alkaline_raw.png"
                },
                new StationWaterProduct()
                {
                    UserId="2",
                    ProdDescription="Mineral",
                    WaterPrice="₱20.00",
                    PhotoUrl="mineral_raw.png"
                },
                //new StationWaterProduct()
                //{
                //    UserId="3",
                //    ProdDescription="Alkaline",
                //    WaterPrice="₱25.00",
                //    PhotoUrl="alkaline_raw.png"
                //},

                //new StationWaterProduct()
                //{
                //    UserId="4",
                //   ProdDescription="Mineral",
                //    WaterPrice="₱20.00",
                //    PhotoUrl="mineral_raw.png"
                //},

                //new StationWaterProduct()
                //{
                //    UserId="5",
                //    ProdDescription="Alkaline",
                //    WaterPrice="₱25.00",
                //    PhotoUrl="alkaline_raw.png"
                //},

                //new StationWaterProduct()
                //{
                //    UserId="6",
                //     ProdDescription="Mineral",
                //    WaterPrice="₱20.00",
                //    PhotoUrl="mineral_raw.png"
                //},
                //new StationWaterProduct()
                //{   UserId="7",
                //    ProdDescription="Alkaline",
                //    WaterPrice="₱25.00",
                //    PhotoUrl="alkaline_raw.png"
                //},
                //new StationWaterProduct()
                //{
                //    UserId="8",
                //    ProdDescription = "Mineral", 
                //    WaterPrice = "₱20.00",
                //    PhotoUrl="mineral_raw.png"
                //},
            };
        }




        public string ProdDescription { get; set; }
        public string WaterPrice { get; set; }

        public string UserId { get; set; }
        public string PhotoUrl { get; set; }
    }
}
