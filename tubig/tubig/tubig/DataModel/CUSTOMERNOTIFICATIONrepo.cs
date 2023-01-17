using Firebase.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tubig.DataModel
{
    public class CUSTOMERNOTIFICATIONrepo
    {
        FirebaseClient firebaseClient = new FirebaseClient("https://big-system-64b55-default-rtdb.firebaseio.com/");
        CUSTOMERNOTIFICATION customerNotif = new CUSTOMERNOTIFICATION();
        ORDER allOrder = new ORDER();

        public async Task<List<CUSTOMERNOTIFICATION>> GetCustomerNotificationUpdated()
        {



            return
                (await firebaseClient.Child
                (nameof(CUSTOMERNOTIFICATION))
                .OnceAsync<CUSTOMERNOTIFICATION>()).Select(item => new CUSTOMERNOTIFICATION
                {

                     OrderStatus = item.Object.OrderStatus,
                     orderFrom_store = item.Object.orderFrom_store,
                   // orderDeliveryType = item.Object.orderDeliveryType,
                   // orderType = item.Object.orderType,
                   // orderQuantity = item.Object.orderQuantity,
                   // orderPrice = item.Object.orderPrice,

                   // OrderProductType = item.Object.OrderProductType,
                   // OrderReservationDate = item.Object.OrderReservationDate,
                    ///orderTotalAmount = item.Object.orderTotalAmount,
                    order_CUSTOMERID = item.Object.order_CUSTOMERID,
                    //orderDateTime = item.Object.orderDateTime,
                   
                    orderID = item.Object.orderID,
                    notifID = item.Key

                   // notifID=item.Object.notifID,
                  //  orderID=item.Key
                }).ToList();
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

        //public async Task<List<ORDER>> GetOrderByID(string order_ID)
        //{
        //    var allCustomer = await GetAllOrderData();
        //        await firebaseClient
        //         .Child("ORDER")
        //          .OnceAsync<ORDER>();
        //        return allCustomer.Where(a => a.orderID==order_ID).FirstOrDefault();
        //}
    }
}
