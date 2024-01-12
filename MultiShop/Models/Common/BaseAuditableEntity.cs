namespace MultiShop.Models.Common;

public abstract class BaseAuditableEntity:BaseEntity
{
    public bool IsDeleted { get; set; }
}
