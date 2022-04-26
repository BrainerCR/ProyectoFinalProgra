using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace FE.CustomValidation
{
    public class ContrasenaValidate : Attribute, IModelValidator

    {
        public string ErrorMessage { get; set; }

        public IEnumerable<ModelValidationResult> Validate(ModelValidationContext context)
        {
            return new List<ModelValidationResult>

                {

                    new ModelValidationResult("", ErrorMessage)

                };
        }

    }

}