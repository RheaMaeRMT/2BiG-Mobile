using Firebase.Database;
using Firebase.Storage;
using System;
using System.Collections.Generic;
using System.Text;

namespace tubig.FIREBASETHING
{
    public class firebaseThing
    {
        FirebaseClient firebaseClient = new FirebaseClient("https://big-system-64b55-default-rtdb.firebaseio.com/");




        FirebaseStorage firebaseStorage = new FirebaseStorage("big-system-64b55.appspot.com", new FirebaseStorageOptions
        {
            ThrowOnCancel = true
        });

    }
}



