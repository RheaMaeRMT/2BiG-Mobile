using Firebase.Database;
using Newtonsoft.Json;
using System.Threading.Tasks;
using System.Windows.Input;
using tubig.DataModel;
using System.IO;
using Firebase.Storage;
using System.Collections.Generic;
using System.Linq;
using tubig.FIREBASETHING;
namespace tubig.DataModel
{

    public class CustomerRepo
    {
        FirebaseClient firebaseClient = new FirebaseClient("https://big-system-64b55-default-rtdb.firebaseio.com/");

        CUSTOMER cus = new CUSTOMER();

        public ICommand SaveToFireBaseCommand { get; }

        FirebaseStorage firebaseStorage = new FirebaseStorage("big-system-64b55.appspot.com", new FirebaseStorageOptions
        {
            ThrowOnCancel = true
        });
        private readonly firebaseThing firebase = new firebaseThing();
        IList<int> list = new List<int>();

        //save data to database
        public async Task<bool> Save(CUSTOMER customer)
        {
           var data= await firebaseClient.Child(nameof(CUSTOMER)).PostAsync(JsonConvert.SerializeObject(customer));


            if (!string.IsNullOrEmpty(data.Key))
            {
                return true;
            }
            return false;
        }

      //retrieve data to database
      public async Task<List<CUSTOMER>>GetAll()
      {


            return (await firebaseClient.Child(nameof(CUSTOMER)).OnceAsync<CUSTOMER>()).Select(item => new CUSTOMER
            {
                //Email = item.Object.Email,
                //Name = item.Object.Name,
                //Image = item.Object.Image,
                //Id = item.Key
                CusFirstName = item.Object.CusFirstName,
                CusLastName = item.Object.CusLastName,
                CusValiIdImage = item.Object.CusValiIdImage,
                CusID =item.Key
            }).ToList();
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

        //public async Task<List<CUSTOMER>> GetAllCustomer()
        //{

        //    return (await firebaseClient
        //      .Child("CUSTOMER")
        //      .OnceAsync<CUSTOMER>()).Select(item => new CUSTOMER
        //      {
        //          CusFirstName = item.Object.CusFirstName,
        //          CusID = item.Object.CusID
        //      }).ToList();
        //}

        //public async Task<CUSTOMER> GetCustomer(string customerName)
        //{

        //    var allCustomer = await GetAllCustomer();
        //    await firebaseClient
        //      .Child("CUSTOMER")
        //      .OnceAsync<CUSTOMER>();
        //    return allCustomer.Where(a => a.CusFirstName == customerName).FirstOrDefault();

           
        //}


        public async Task<List<CUSTOMER>> GetAllCustomerData()
        {
            return (await firebaseClient.Child(nameof(CUSTOMER)).OnceAsync<CUSTOMER>()).Select(item => new CUSTOMER
            {
              
                CusFirstName=item.Object.CusFirstName,
                CusLastName= item.Object.CusLastName,
                CusContactNumber= item.Object.CusContactNumber,
                CusEmail = item.Object.CusEmail,
                CusBirthOfDate= item.Object.CusBirthOfDate,
                CusAddress= item.Object.CusAddress,
                CusUsername= item.Object.CusUsername,
                CusPassword= item.Object.CusPassword,
                CusSecurityQuestion= item.Object.CusSecurityQuestion,
                CusSecurityQuestionAnswer= item.Object.CusSecurityQuestionAnswer,
                CusID=item.Key
            }).ToList();
        }
        //public async Task<List<CUSTOMER>> GetCustomerByUsernameAndPassword(string username)
        //{
        //    var allcustomerData = await GetAllCustomerData();
        //    await firebaseClient.Child("CUSTOMER").OnceAsync<CUSTOMER>();
        //    return allcustomerData.Where(a => a.CusUsername == username).FirstOrDefault();
        //}

        public async Task<List<CUSTOMER>> GetCustomerByName(string name)
        {
            var allCustomerData = GetAllCustomerData();
            return (await firebaseClient.Child(nameof(CUSTOMER)).OnceAsync<CUSTOMER>()).Select(item => new CUSTOMER
            {
                CusFirstName = item.Object.CusFirstName,
                CusLastName = item.Object.CusLastName,
                CusContactNumber = item.Object.CusContactNumber,
                CusEmail = item.Object.CusEmail,
                CusBirthOfDate = item.Object.CusBirthOfDate,
                CusAddress = item.Object.CusAddress,
                CusUsername = item.Object.CusUsername,
                CusPassword = item.Object.CusPassword,
                CusSecurityQuestion = item.Object.CusSecurityQuestion,
                CusSecurityQuestionAnswer = item.Object.CusSecurityQuestionAnswer,
                CusID = item.Key
            }).Where(c => c.CusFirstName.ToLower().Contains(name.ToLower())).ToList();
        }
        

    }
}
