using Firebase.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tubig.DataModel
{
   public  class PRODUCTREPO
    {
        FirebaseClient firebaseClient = new FirebaseClient("https://big-system-64b55-default-rtdb.firebaseio.com/");

        PRODUCT stationproduct = new PRODUCT();
        

        public async Task<List<PRODUCT>> GetAllPRODUCTData()
        {
            return 
                (await firebaseClient.Child
                (nameof(PRODUCT))
                .OnceAsync<PRODUCT>()).Select(item => new PRODUCT
            {

            
              productPrice=item.Object.productPrice,
              productSize=item.Object.productSize,
              productType=item.Object.productType,
              PhotoUrl=item.Object.PhotoUrl,
              productId =item.Key

                }).ToList();
        }

        public async Task<PRODUCT> GetProduct(string refill_id)
        {
            var allproductWater = await GetAllPRODUCTData();
            await firebaseClient
              .Child("PRODUCT_REFILL")
              .OnceAsync<PRODUCT>();
            return allproductWater.Where(a => a.productId == refill_id).FirstOrDefault();
        }

        public static IEnumerable<PRODUCTREPO> Get()
        {
            return new List<PRODUCTREPO>
            {
                new PRODUCTREPO()
                {
                   refill_id=1,
                   PhotoUrl="alkaline_raw.png"
                },
                new PRODUCTREPO()
                {
                    refill_id=2,
                   PhotoUrl="mineral_raw.png"
                },
                 
                
            };
        }

        public int DeliveryPrice { get; set; }
        public int PickUp_Price { get; set; }
        public string gallonType { get; set; }
        public string refillName { get; set; }

        public int refill_id { get; set; }
        public string waterType { get; set; }

        public string PhotoUrl { get; set; }
    }
}
