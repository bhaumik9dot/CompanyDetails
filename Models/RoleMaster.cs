using System.ComponentModel.DataAnnotations;

namespace CompanyDetails.Models
{
    public class RoleMaster
    {
        [Key]
        public int RoleId { get; set; }
        
        [Required]
        public string? RoleName { get; set; }
        
        [Required]
        public string? Description { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.UtcNow;

    }
}
