using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tubig.DataModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace tubig
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AccountSetting : ContentPage
    {
        CUSTOMER customer = new CUSTOMER();
        CustomerRepo customerRepo = new CustomerRepo();
        public AccountSetting()
        {
            InitializeComponent();
            entryfieldFullname.Text = customer.CusFirstName + customer.CusMiddleName + customer.CusLastName;
          
        }

       

        private void SaveButton_Clicked(object sender, EventArgs e)
        {

        }
    }
}