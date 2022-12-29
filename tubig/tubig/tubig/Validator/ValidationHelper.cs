using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

using System.Reflection;

namespace tubig.Validator
{
    public static class ValidationHelper
    {
        public static bool IsFormValid(object model,Page page)
        {
           // HideValidationFields(model, page);
            var errors = new List<ValidationResult>();
            var context = new ValidationContext(model);
           // bool isValid = Validator.TryValidateObject(model, context, errors, true);
           //bool isValid= Validator.TryValidate

            return errors.Count() == 0;
        }
    }
}
