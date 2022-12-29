using Firebase.Database;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace tubig.DataModel
{
   public  class WaterOrderRepo
    {
        FirebaseClient firebaseClient = new FirebaseClient("https://big-system-64b55-default-rtdb.firebaseio.com/");

        WATER_ORDER waterOrder = new WATER_ORDER();
        public async Task<bool> Save(WATER_ORDER WaterOrder)
        {
            var data = await firebaseClient.Child(nameof(WATER_ORDER)).PostAsync(JsonConvert.SerializeObject(WaterOrder));


            if (!string.IsNullOrEmpty(data.Key))
            {
                return true;
            }
            return false;
        }
    }
}
