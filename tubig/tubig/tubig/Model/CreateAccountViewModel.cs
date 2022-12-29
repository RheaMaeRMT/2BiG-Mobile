using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using tubig.DataModel;
using Xamarin.Forms;
using tubig.Validator;
namespace tubig.Model
{
    public class CreateAccountViewModel
    {
        public CUSTOMER CUSTOMER { get; set; } = new CUSTOMER();
        public Icommand CreateCommand { get; }
        private Page _page;

        public CreateAccountViewModel(Page page)
            {
            _page = page;
            CreateCommand = new Command(async () => await LoginAsync());
            }

        private async Task LoginAsync()
        {
          
                if (!ValidationHelper.IsFormValid(CUSTOMER, _page)) { return; }
               await _page.DisplayAlert("Success", "Validation Success!", "OK");
            
        }
    }
}
