
namespace CompanyDetails.Helpers
{
    public class ResponseMessage
    {
        // Comman
        public static string DataRetrieved = "Data has been successfully retrieved.";
        public static string DataNotFound = "No data found.";
        public static string SomethingWentWrong = "something went wrong.";
        public static string UserNotFound = "We're sorry, but the user you are looking for could not be found in our system.";
        public const string SelectFileOne = "Please select only one file.";
        public static string ValidEmailAddress = "The email address you entered is invalid. Please provide a valid email address.";
        public static string AccessRestricted = "Access restricted to authorized personnel. Please contact the administrator for further assistance.";
        public static string UserInActive = "The user account is inactive. Please contact the administrator for assistance.";
        public static string PasswordNotMatch = "The password you entered is incorrect. Please try again.";
        public static string EmailNotVerify = "Your email address has not been verified. Please check your inbox and verify your email to proceed.";
        public static string EmailVerify = "Your email address has been verified successfully.";
        public static string OTPNotSend = "OTP not send please try again.";
        public static string OTPSend = "OTP was sent successfully to your email address.";
        public const string ReferralCodeNotFound = "Invalid referral code.";
        public const string InsufficientPermissions = "You do not have sufficient permissions to perform this action. Only Admin and IB roles are allowed.";
        public static string EmailVerification = "Send email verification successfully.";
        public static string UpdateUser = "Your profile updated successfully.";
        public static string PasswordDetails = "The user name and password have been sent successfully.";
        public static string PasswordVerification = "Success Password verification.";
        public static string LogoutSuccess = "You have successfully logged out.";

        // Auth
        public static string VerifyOTP = "Your OTP has been successfully verified.";
        public static string ResendOtp = "OTP has been resent to the email address successfully.";
        public static string EmailResendOtp = "The OTP to reset the password has been successfully sent to the email address.";
        public static string PasswordChange = "Password has been changed successfully.";
        public static string OTPExpired = "The OTP has expired. Please request a new OTP.";
        public static string IncorrectOTP = "Incorrect OTP entered. Please try again.";
        public static string IncorrectPassword = "The password you entered is incorrect. Please try again.";
        public static string ForgotPassword = "Forget password successfully.";
        public static string WithOutOTPLogin = "The OTP-less login mechanism is enabled, bypassing the need for an OTP during login.";
        public static string LoginByAdmin = "Login successfully.";

        // Company Information
        public static string AddCompany = "Company information has been successfully added.";
        public static string UpdateCompany = "Company information has been successfully updated.";
        public static string CompanyNotFound =  "We're sorry, but the company you are looking for could not be found in our system.";
        public static string CompanyDeletedSuccessfully = "Company information has been successfully deleted.";
    }

    
}
