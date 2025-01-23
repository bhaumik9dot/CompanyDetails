using CompanyDetails.Data;
using CompanyDetails.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CompanyDetails.Models
{

    public class UserMaster : BaseEntity
    {
        [Key]
        public int UserId { get; set; }

        [Required]
        public string? FirstName { get; set; }

        [Required]
        public string? LastName { get; set; }

        [Required]
        public string? Email { get; set; }

        [Required(ErrorMessage = "Please enter your phone number")]
        [StringLength(15, MinimumLength = 7, ErrorMessage = "Please enter a valid phone number")]
        public string? PhoneNo { get; set; }

        [Required]
        public string? Password { get; set; }

        [Required]
        public RoleType RoleId { get; set; }
        public int Otp { get; set; }
        public DateTime? OtpExpiryTime { get; set; }
        public bool OtpDisable { get; set; }
        public bool IsActive { get; set; }
        public bool IsDelete { get; set; }

    }
}
