using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace ModelValidation.Infrastructure
{
    public class MustBeTrueAttribute : Attribute, IModelValidator
    {
        public bool IsRequired => true;
        public string ErrorMessage {get; set;} = "Kullanım koşullarını kabul etmelisiniz";
        public IEnumerable<ModelValidationResult> Validate(ModelValidationContext context)
        {
            var value = context.Model as bool?;

            if (value.HasValue && value.Value == false)
            {
                return new List<ModelValidationResult> { new ModelValidationResult("",ErrorMessage)};
            }
            else
            {
                return Enumerable.Empty<ModelValidationResult>();
            }
        }
    }

    public class PasswordIsValidAttribute : Attribute, IModelValidator
    {
        public bool IsRequired => true;
        public string ErrorMessage {get; set;} = "Ardışık sayılar arka arkaya gelemez";
        public IEnumerable<ModelValidationResult> Validate(ModelValidationContext context)
        {
            var value = context.Model as string;

            if (IsSequential(value))
            {
                return new List<ModelValidationResult> { new ModelValidationResult("",ErrorMessage)};
            }
            else
            {
                return Enumerable.Empty<ModelValidationResult>();
            }
        }

        public bool IsSequential(string pass)
        {
            bool isSeq = false;
            if (!string.IsNullOrEmpty(pass))
            {
                for (int i = 0; i < pass.Length-1; i++)
                {
                    if (pass[i] + 1 == pass[i+1])
                    {
                        isSeq = true;
                        break;
                    }
                }
            }
            

            return isSeq;
        }
    }
}