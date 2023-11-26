namespace Ecommerce.Domain.Common;

public abstract class BaseDomainModel
{
    public int Id { get; set; }
    public DateTime? CreatedDate { get; set; }
    public string? CreatedBy { get; set; }
    public DateTime? LastModifiedDate { get; set; }
    public DateTime? LastModifiedBy { get; set; }
}