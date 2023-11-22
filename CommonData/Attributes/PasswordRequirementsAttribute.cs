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
        var validationMessages = new List<string>();
        if (value != null && value is string password)
        {
            if (password.Length < MinLength)
            {
                validationMessages.Add($"Password must be at least 8 characters.");

            }

            if (password.Count(char.IsDigit) < MinNumbers)
            {
                validationMessages.Add($"The password must contain at least 2 numbers.");

            }
            if (validationMessages.Count > 0)
                return new ValidationResult(string.Join(" ", validationMessages));
        }

        return ValidationResult.Success;
    }
}
