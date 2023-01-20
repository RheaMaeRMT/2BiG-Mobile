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
using System;
using System.Diagnostics;
using Firebase.Auth;
using Firebase.Database.Query;


namespace tubig.DataModel
{

    public class CustomerRepo
    {
         FirebaseClient firebaseClient = new FirebaseClient("https://big-system-64b55-default-rtdb.firebaseio.com/");
      // FirebaseClient firebaseClient = new FirebaseClient("https://tubigcapstone-default-rtdb.firebaseio.com/");
         string WebAPIkey = "AIzaSyC3EK1x68TgLdB7wIgpQ9bssBU4jnN7EVs";
       // string WebAPIkey = "AIzaSyDe9vtJNf0_uCehVdDGJ-MuIIJIHpm-cgs"; 
        FirebaseAuthProvider authProvider;
        CUSTOMER cus = new CUSTOMER();
        public CustomerRepo()
        {
            authProvider = new FirebaseAuthProvider(new FirebaseConfig(WebAPIkey));
        }

        public ICommand SaveToFireBaseCommand { get; }

        FirebaseStorage firebaseStorage = new FirebaseStorage("big-system-64b55.appspot.com", new FirebaseStorageOptions
        {
            //rhona link- "big-system-64b55.appspot.com" "gs://tubigcapstone.appspot.com"
            ThrowOnCancel = true 
        });
        private readonly firebaseThing firebase = new firebaseThing();
        IList<int> list = new List<int>();

        //save data to database
        public async Task<bool> Save(CUSTOMER customer)
        {
            
            var token = await authProvider.CreateUserWithEmailAndPasswordAsync(customer.CusEmail, customer.CusPassword);
            var data = await firebaseClient.Child(nameof(CUSTOMER)).PostAsync(JsonConvert.SerializeObject(customer));


            
             await firebaseClient.Child(nameof(CUSTOMER)).Child("4815").PutAsync(JsonConvert.SerializeObject(customer));
          


           if( !string.IsNullOrEmpty(token.FirebaseToken))
            {
                return true;
            }
            return false;
           // return true;
        }

       

      //retrieve data to database
      public async Task<List<CUSTOMER>>GetAll()
      {


            return (await firebaseClient.Child(nameof(CUSTOMER)).OnceAsync<CUSTOMER>()).Select(item => new CUSTOMER
            {
               
                CusFirstName = item.Object.CusFirstName,
                CusLastName = item.Object.CusLastName,
                CusValiIdImage = item.Object.CusValiIdImage,
             
            }).ToList();
      }

         public async Task<string> Upload(Stream img, string filename)
        {
            var image = await firebaseStorage
                .Child("CustomerValidID")
                .Child(filename)
                .PutAsync(img);
            return image;

           
        }

           
       


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
              
                CusPassword= item.Object.CusPassword,
                CusSecurityQuestion= item.Object.CusSecurityQuestion,
                CusSecurityQuestionAnswer= item.Object.CusSecurityQuestionAnswer,
                CusID=item.Key
            }).ToList();
        }
    
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
               
                CusPassword = item.Object.CusPassword,
                CusSecurityQuestion = item.Object.CusSecurityQuestion,
                CusSecurityQuestionAnswer = item.Object.CusSecurityQuestionAnswer,
                CusID = item.Key
            }).Where(c => c.CusFirstName.ToLower().Contains(name.ToLower())).ToList();
        }
        public async Task<CUSTOMER> GetCustomerByEmail(string email,string password)

        {


            var allcustomer = await GetAllCustomerData();
            await firebaseClient
            .Child("CUSTOMER")
            .OnceAsync<CUSTOMER>();
            return allcustomer.Where(a => a.CusEmail == email && a.CusPassword == password).FirstOrDefault();



       

        }




          
        public async Task<string> Signin(string email, string password)
        {
            //var authProvider
            //var token = await authProvider.SignInWithEmailAndPasswordAsync(email, password);        
            var token = await authProvider.SignInWithEmailAndPasswordAsync(email, password);
            if (!string.IsNullOrEmpty(token.FirebaseToken))
            {
                return token.FirebaseToken;
            }
            return "";
        }

        
        public async Task<bool> Update(CUSTOMER customer)
        {

            await firebaseClient.Child(nameof(CUSTOMER) + "/" + customer.CusID).PutAsync(JsonConvert.SerializeObject(customer));
            return true;
        }

        

    }
}
