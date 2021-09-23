using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net.Mail;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace CoreEV4.CustomValidation
{
    public class CustomEmailValidator : ValidationAttribute, IClientModelValidator
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            string email = value.ToString();
            try
            {
                MailAddress m = new MailAddress(email);

                return ValidationResult.Success;
            }
            catch (FormatException)
            {
                return new ValidationResult("Invalid email address.");
            }
        }
        public void AddValidation(ClientModelValidationContext context)
        {
            context.Attributes.Add("data-val", "true");
            context.Attributes.Add("data-val-pEmail", "Invalid email address.");
        }
    }
}
