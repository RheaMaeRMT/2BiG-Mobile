using Firebase.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tubig.DataModel
{
   public  class CUSTOMERNOTIFICATIONrepo
    {
        FirebaseClient firebaseClient = new FirebaseClient("https://big-system-64b55-default-rtdb.firebaseio.com/");
        CUSTOMERNOTIFICATION customerNotif = new CUSTOMERNOTIFICATION();
        public async Task<List<CUSTOMERNOTIFICATION>> GetCustomerNotification()
        {



            return
                (await firebaseClient.Child
                (nameof(CUSTOMERNOTIFICATION))
                .OnceAsync<CUSTOMERNOTIFICATION>()).Select(item => new CUSTOMERNOTIFICATION
                {

                    OrderStatus = item.Object.OrderStatus,
                   // orderFrom_store = item.Object.orderFrom_store,
                    orderDeliveryType = item.Object.orderDeliveryType,
                    orderType = item.Object.orderType,
                    orderQuantity = item.Object.orderQuantity,
                    orderPrice=item.Object.orderPrice,
                    
                    OrderProductType = item.Object.OrderProductType,
                    OrderReservationDate = item.Object.OrderReservationDate,
                    orderTotalAmount = item.Object.orderTotalAmount,
                    order_CUSTOMERID = item.Object.order_CUSTOMERID,
                    orderDateTime = item.Object.orderDateTime,
                    notifID = item.Object.notifID,
                    orderID = item.Key

                }).ToList();
        }
    }
    
}
