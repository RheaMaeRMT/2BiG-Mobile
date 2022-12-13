using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using Firebase.Database;
using Firebase.Storage;

namespace tubig.firebasehelper
{
    public class FirebaseStorageHelper
    {
        FirebaseStorage firebaseStorage = new FirebaseStorage("gs://big-system-64b55.appspot.com", new FirebaseStorageOptions
        {
            ThrowOnCancel = true
        });
        FirebaseClient firebaseClient = new FirebaseClient("https://capstone-tubig-default-rtdb.asia-southeast1.firebasedatabase.app/");
        public async Task<string> UploadFile(Stream fileStream, string fileName)
        {
            var imageUrl = await firebaseStorage
                .Child("CUSTOMERimage")
                .Child(fileName)
                .PutAsync(fileStream);
            return imageUrl;
        }

        public async Task<string> GetFile(string fileName)
        {
            return await firebaseStorage
                .Child("CUSTOMERimage")
                .Child(fileName)
                .GetDownloadUrlAsync();
        }
        public async Task DeleteFile(string fileName)
        {
            await firebaseStorage
                 .Child("CUSTOMERimage")
                 .Child(fileName)
                 .DeleteAsync();

        }

    }
}
