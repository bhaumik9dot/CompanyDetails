
namespace CompanyDetails.Data
{
    public class BaseEntity
    {
        public int CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.UtcNow;
        public int? ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public int? DeletedBy { get; set; }
        public DateTime? DeletedDate { get; set; }
    }
    public class CreatedModifiedBaseEntity
    {
        public int CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.UtcNow;
        public int? ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
    }
    public class CreatedBaseEntity
    {
        public int CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.UtcNow;
    }

    public class ModifiedBaseEntity
    {
        public int? ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
    }

    public class DeletedBaseEntity
    {
        public int? DeletedBy { get; set; }
        public DateTime? DeletedDate { get; set; }
    }

}
