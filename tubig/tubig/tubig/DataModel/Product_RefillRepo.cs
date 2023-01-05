using Firebase.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tubig.DataModel
{
   public  class Product_RefillRepo
    {
        FirebaseClient firebaseClient = new FirebaseClient("https://big-system-64b55-default-rtdb.firebaseio.com/");

        PRODUCT_REFILL productRefill = new PRODUCT_REFILL();

        public async Task<List<PRODUCT_REFILL>> GetAllProductRefill()
        {
            return 
                (await firebaseClient.Child
                (nameof(PRODUCT_REFILL))
                .OnceAsync<PRODUCT_REFILL>()).Select(item => new PRODUCT_REFILL
            {
                
              DeliveryPrice=item.Object.DeliveryPrice,
              PickUp_Price=item.Object.PickUp_Price,
              gallonType=item.Object.gallonType,
              refillName=item.Object.refillName,
              waterType=item.Object.waterType,
              refill_id=item.Object.refill_id

            }).ToList();
        }

        public async Task<PRODUCT_REFILL> GetProduct(int refill_id)
        {
            var allproductWater = await GetAllProductRefill();
            await firebaseClient
              .Child("PRODUCT_REFILL")
              .OnceAsync<PRODUCT_REFILL>();
            return allproductWater.Where(a => a.refill_id == refill_id).FirstOrDefault();
        }

        public static IEnumerable<Product_RefillRepo> Get()
        {
            return new List<Product_RefillRepo>
            {
                new Product_RefillRepo()
                {
                   refill_id=1,
                   refillName="alkaline refill slim gallon"
                },
                new Product_RefillRepo()
                {
                    refill_id=2,
                   refillName="distilled water refill"
                },
                 new Product_RefillRepo()
                {
                   refill_id=3,
                   refillName="distilled round small refill"
                },
                //new StationWaterProduct()
                //{   UserId="1",

                //    ProdDescription="Alkaline",
                //    WaterPrice="₱25.00",
                //    PhotoUrl="alkaline_raw.png"
                //},
                //new StationWaterProduct()
                //{
                //    UserId="2",
                //    ProdDescription="Mineral",
                //    WaterPrice="₱20.00",
                //    PhotoUrl="mineral_raw.png"
                //},
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

        public int DeliveryPrice { get; set; }
        public int PickUp_Price { get; set; }
        public string gallonType { get; set; }
        public string refillName { get; set; }

        public int refill_id { get; set; }
        public string waterType { get; set; }
    }
}
