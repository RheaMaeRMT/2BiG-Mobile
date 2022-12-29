using System;
using Xamarin.Forms;

namespace tubig
{
    public class Icommand
    {
        public static implicit operator Icommand(Command v)
        {
            throw new NotImplementedException();
        }
    }
}