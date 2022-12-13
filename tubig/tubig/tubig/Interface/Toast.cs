using System;
using System.Collections.Generic;
using System.Text;

namespace tubig.Interface
{
    //[assembly: Xamarin.Forms.Dependency(typeof(Toast_Android))]  
    public interface Toast
    {
        void Show(string message);
    }
}
