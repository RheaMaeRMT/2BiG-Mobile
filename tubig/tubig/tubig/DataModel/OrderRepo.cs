using Firebase.Database;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace tubig.DataModel
{
   public  class OrderRepo
    {
        FirebaseClient firebaseClient = new FirebaseClient("https://big-system-64b55-default-rtdb.firebaseio.com/");

        ORDER waterOrder = new ORDER();
        ADMINNOTIFICATION customernotification = new ADMINNOTIFICATION();
        public async Task<bool> Save(ORDER WaterOrder)
        {
            var data = await firebaseClient.Child(nameof(ORDER)).PostAsync(JsonConvert.SerializeObject(WaterOrder));


            if (!string.IsNullOrEmpty(data.Key))
            {
                return true;
            }
            return false;
        }

        public async Task<bool> SaveCustomerNotification(ADMINNOTIFICATION OrderCustomerNotification)
        {
            var data = await firebaseClient.Child(nameof(ADMINNOTIFICATION)).PostAsync(JsonConvert.SerializeObject(OrderCustomerNotification));


            if (!string.IsNullOrEmpty(data.Key))
            {
                return true;
            }
            return false;
        }


    }
}
