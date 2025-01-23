using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

public class LoginRequest
{
    private string _email;

    [EmailValidation(ErrorMessage = "Invalid email format.")]
    public string Email
    {
        get { return _email; }
        set { _email = value?.ToLower().Trim(); } // Convert to lowercase before setting
    }

    [Required(ErrorMessage = "Please enter a password.")]
    public string? Password { get; set; }

    [Required]
    public string? PlatformName { get; set; }
}

// Custom Email Validation Attribute
public class EmailValidationAttribute : ValidationAttribute
{
    protected override ValidationResult IsValid(object value, ValidationContext validationContext)
    {
        if (value == null || string.IsNullOrWhiteSpace(value.ToString()))
        {
            return new ValidationResult("Please enter email address.");
        }

        string email = value.ToString();
        string pattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";

        if (!Regex.IsMatch(email, pattern))
        {
            return new ValidationResult(ErrorMessage ?? "Please enter a valid email address.");
        }

        return ValidationResult.Success;
    }
}

