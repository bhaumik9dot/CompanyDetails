using System.ComponentModel.DataAnnotations;

namespace CompanyDetails.Models
{
    public class CompanyInformation
    {
        [Key]
        public int CompanyId { get; set; }
        
        public string? CompanyName { get; set; }
        
        public string? AcquisitionDate { get; set; }
        
        public string? PlatformFeatures { get; set; }
        
        public string? IpAddressV4 { get; set; }
        
        public string? MacAddress { get; set; }
        
        public string? Canceled { get; set; }
        
        public string? Suspended { get; set; }
        
        public string? Email { get; set; }
        
        public string? ApiBaseUrl { get; set; }
        
        public string? DemoAccountNodeId { get; set; }
        
        public string? AndroidBuild { get; set; }
        
        public string? ForceUpgrade { get; set; }
        
        public string? iOSBuild { get; set; }
        
        public string? AccountsCreatorURL { get; set; }
        
        public string? WhatsNew { get; set; }
        
        public string? Address { get; set; }
        public string? LogoUrl { get; set; }
        public string? WebsiteUrl { get; set; }
        public string? FacebookUrl { get; set; }
        public string? YouTubeUrl { get; set; }
        public string? LinkedInUrl { get; set; }
        public string? XUrl { get; set; }
        public string? ContactNumber { get; set; }
        public string? HelpPageUrl { get; set; }
        public string? PrivacyPolicyUrl { get; set; }
        public string? TermsOfServiceUrl { get; set; }
        public string? PhysicalAddress { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }

    }
}
