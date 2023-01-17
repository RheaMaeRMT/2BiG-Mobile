using Firebase.Database;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tubig.DataModel
{
    public class ADMINNOTIFICATIONrepo
    {
        FirebaseClient firebaseClient = new FirebaseClient("https://big-system-64b55-default-rtdb.firebaseio.com/");
        ORDER order = new ORDER();
        ADMINNOTIFICATION adminNotify = new ADMINNOTIFICATION();

         public async Task<bool> SaveToAdminNotification(ADMINNOTIFICATION admin_notify)
            {
                var data = await firebaseClient.Child(nameof(ADMINNOTIFICATION)).PostAsync(JsonConvert.SerializeObject(admin_notify));


                if (!string.IsNullOrEmpty(data.Key))
                {
                    return true;
                }
                return false;
            }
        public async Task<ORDER> GetById(string id)
        {
            return (await firebaseClient.Child(nameof(ORDER) + "/" + id).OnceSingleAsync<ORDER>());
        }

        public async Task<List<ORDER>> GetAllOrderData()
        {
            return
               (await firebaseClient.Child
               (nameof(ORDER))
               .OnceAsync<ORDER>()).Select(item => new ORDER
               {
                   OrderStatus = item.Object.OrderStatus,

                   orderFrom_store = item.Object.orderFrom_store,
                   orderDeliveryType = item.Object.orderDeliveryType,
                   orderType = item.Object.orderType,
                   orderQuantity = item.Object.orderQuantity,
                   // orderPrice = item.Object.orderPrice,

                   OrderProductType = item.Object.OrderProductType,
                   OrderReservationDate = item.Object.OrderReservationDate,
                   orderTotalAmount = item.Object.orderTotalAmount,
                   order_CUSTOMERID = item.Object.order_CUSTOMERID,
                   orderDateTime = item.Object.orderDateTime,

                   orderID = item.Key
               }).ToList();
        }
    }
}
