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
                //Email = item.Object.Email,
                //Name = item.Object.Name,
                //Image = item.Object.Image,
                //Id = item.Key
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
    }
}
