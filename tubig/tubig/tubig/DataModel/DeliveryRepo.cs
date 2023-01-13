using Firebase.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tubig.DataModel
{
   public  class DeliveryRepo
    {
        FirebaseClient firebaseClient = new FirebaseClient("https://big-system-64b55-default-rtdb.firebaseio.com/");
        DELIVERY deliveryModel = new DELIVERY();
        public async Task<List<DELIVERY>> GetAllDeliveryData()
        {
            return
                (await firebaseClient.Child
                (nameof(DELIVERY))
                .OnceAsync<DELIVERY>()).Select(item => new DELIVERY
                {

                   deliveryId=item.Object.deliveryId,
                   deliveryFee=item.Object.deliveryFee,
                   estimatedTime=item.Object.estimatedTime,
                   deliveryType=item.Object.deliveryType

                }).ToList();
        }

        //public async Task<List<CUSTOMERNOTIFICATION>> getAllCustomerNotif()
        //{
        //    return
        //       (await firebaseClient.Child
        //       (nameof(CUSTOMERNOTIFICATION))
        //       .OnceAsync<CUSTOMERNOTIFICATION>()).Select(item => new CUSTOMERNOTIFICATION
        //       {

        //       //  OrderStatus=item.Object.OrderStatus




        //       }).ToList();
        //}
    }
}
