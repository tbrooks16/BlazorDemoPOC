using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace BlazorDemoPOC.Client.Validators;

public class PhoneValidation : ValidationAttribute {
    protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
    {
        Regex rx = new Regex(@"^(\+0?1\s)?\(?\d{3}\)?[\s.-]\d{3}[\s.-]\d{4}$");
        if (rx.IsMatch(value?.ToString())) {
            return ValidationResult.Success;
        }
        return new ValidationResult("Please provide a valid phone number: " + value + " is not a valid phone number.");
    }
}