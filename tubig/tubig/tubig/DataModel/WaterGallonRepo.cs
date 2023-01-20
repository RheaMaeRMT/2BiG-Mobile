using Firebase.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tubig.DataModel
{
     public class WaterGallonRepo
    {
        FirebaseClient firebaseClient = new FirebaseClient("https://big-system-64b55-default-rtdb.firebaseio.com/");

        // WATERGALLONS waterGal = new WATERGALLONS();
        WATER_GALLONS watergallonsproduct = new WATER_GALLONS();
      

        public async Task<List<WATER_GALLONS>> GetAllWaterProduct()
        {
            return (await firebaseClient.Child(nameof(WATER_GALLONS)).OnceAsync<WATER_GALLONS>()).Select(item => new WATER_GALLONS
            {


                gallonType=item.Object.gallonType,
                gallon_id=item.Key
                
            }).ToList();
        }
    }
}
