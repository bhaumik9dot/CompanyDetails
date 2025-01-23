using System.ComponentModel.DataAnnotations;

namespace CompanyDetails.ViewModel
{
    public class VerifyOTPVM
    {
        private string _email;
        //[Required(ErrorMessage = "Please enter a valid email address.")]
        [EmailValidation(ErrorMessage = "Please enter a valid email address.")]
        public string Email
        {
            get { return _email; }
            set { _email = value?.ToLower().Trim(); } // Convert to lowercase before setting
        }

        [RegularExpression("^[0-9]{6}$", ErrorMessage = "OTP must be a 6-digit number.")]
        [Required(ErrorMessage = "Please enter the OTP.")]
        public int OTP { get; set; }
    }

    public class ForgotVerifyOTPVM
    {
        private string _email;

        [Required(ErrorMessage = "Please enter a valid email address.")]
        [DataType(DataType.EmailAddress, ErrorMessage = "Please enter a valid email address.")]
        public string Email
        {
            get { return _email; }
            set { _email = value?.ToLower().Trim(); } // Convert to lowercase before setting
        }

        [Required(ErrorMessage = "Please enter the OTP.")]
        [RegularExpression("^[0-9]{6}$", ErrorMessage = "OTP must be a 6-digit number.")]
        public int OTP { get; set; }
    }
}
