using Firebase.Database;
using Newtonsoft.Json;
using System.Threading.Tasks;
using System.Windows.Input;
using tubig.DataModel;
using System.IO;
using Firebase.Storage;
using System.Collections.Generic;
using System.Linq;

namespace tubig.DataModel
{

    public class CustomerRepo
    {
        FirebaseClient firebaseClient = new FirebaseClient("https://big-system-64b55-default-rtdb.firebaseio.com/");

        CUSTOMER cus = new CUSTOMER();

        //  public ICommand SaveToFireBaseCommand { get; }
        FirebaseStorage firebaseStorage = new FirebaseStorage("big-system-64b55.appspot.com", new FirebaseStorageOptions
        {
            ThrowOnCancel = true
        });
     
        

        public async Task<bool> Save(CUSTOMER customer)
        {
           var data= await firebaseClient.Child(nameof(CUSTOMER)).PostAsync(JsonConvert.SerializeObject(customer));


            if (!string.IsNullOrEmpty(data.Key))
            {
                return true;
            }
            return false;
        }

      

         public async Task<string> Upload(Stream img, string filename)
        {
            var image = await firebaseStorage
                .Child("CustomerValidID")
                .Child(filename)
                .PutAsync(img);
            return image;

            //var image = await firebaseClient
            //  .Child("CUSTOMER")

            //  .PutAsync(img);
            //return image;
        }

        public async Task<List<CUSTOMER>> GetAllCustomer()
        {

            return (await firebaseClient
              .Child("CUSTOMER")
              .OnceAsync<CUSTOMER>()).Select(item => new CUSTOMER
              {
                  CusFirstName = item.Object.CusFirstName,
                  CusID = item.Object.CusID
              }).ToList();
        }

        public async Task<CUSTOMER> GetCustomer(string customerName)
        {

            // var data = await firebaseClient.Child(nameof(Customer)).PostAsync(JsonConvert.SerializeObject(customer));


            //if (!string.IsNullOrEmpty(data.Key))
            //{
            //    return true;
            //}
            //return false;


            var allCustomer = await GetAllCustomer();
            await firebaseClient
              .Child("CUSTOMER")
              .OnceAsync<CUSTOMER>();
            return allCustomer.Where(a => a.CusFirstName == customerName).FirstOrDefault();

            //  var allCustomer = await firebaseClient.Child(nameof("Customer")).OnceAsync<Customer>
        }

    }
}
