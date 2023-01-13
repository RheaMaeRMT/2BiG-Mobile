using System;
using System.Collections.Generic;
using System.Text;

using Firebase.Database;

using System.Linq;
using YW2BIGNEW.DATAMODEL;
using System.Threading.Tasks;
namespace YW2BIGNEW.REPOSITORY
{
    public class DeliveryRepo
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

                    deliveryId = item.Object.deliveryId,
                    deliveryFee = item.Object.deliveryFee,
                    estimatedTime = item.Object.estimatedTime,
                    deliveryType = item.Object.deliveryType

                }).ToList();
        }

    }
}
