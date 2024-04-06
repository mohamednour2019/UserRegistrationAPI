using RegistrationWebApplication.Core.Domain.Entitites;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegistrationWebApplication.Core.Helpers
{
    public static class ValidationHelper
    {
        internal static void ModelValidation(object modelObject)
        {
            if(modelObject == null) { throw new NullReferenceException(); }
            ValidationContext validationContext = new ValidationContext(modelObject);
            List<ValidationResult> validationResults = new List<ValidationResult>();
            if(!Validator.TryValidateObject(modelObject, validationContext, validationResults))
            {
                throw new ArgumentException(validationResults.FirstOrDefault().ToString());
            }

        }
    }
}
