using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace backend.Validators
{
    public class EmailValidator : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            var regex = new Regex("^[\\w-\\.]+@([\\w-]+\\.)+[\\w-]{2,4}$");
            if (value == null || string.IsNullOrEmpty(value.ToString()))
            {
                return ValidationResult.Success;
            }
            if (!regex.IsMatch(value.ToString()))
            {
                return new ValidationResult("Informe um email valido \nEx: \" admin@admin.com\"");
                    }
            return ValidationResult.Success;

        }
    }
}
