using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;

[AttributeUsage(AttributeTargets.Property | AttributeTargets.Field | AttributeTargets.Parameter)]
public class PasswordRequirementsAttribute : ValidationAttribute
{
    public int MinLength { get; set; } = 8;
    public int MinNumbers { get; set; } = 2;

    protected override ValidationResult IsValid(object value, ValidationContext validationContext)
    {
        string validationMessages = string.Empty;
        if (value != null && value is string password)
        {
            if (password.Length < MinLength)
            {
                validationMessages.Concat($"Password must be at least {MinLength} characters.");
                
            }

            if (password.Count(char.IsDigit) < MinNumbers)
            {
                validationMessages.Concat($"The password must contain at least {MinNumbers} numbers.");
                
            }

            return new ValidationResult(validationMessages);
        }

        return ValidationResult.Success;
    }
}
