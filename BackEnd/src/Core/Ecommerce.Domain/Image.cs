using System.ComponentModel.DataAnnotations.Schema;
using Ecommer.Domain;

namespace Ecommerce.Domain.Common;

public class Image : BaseDomainModel
{
    [Column(TypeName = "NVARCHAR(4000)")]
    public string? Url { get; set; }
    public int ProductId { get; set; }
    public string? PublicCode { get; set; }
    public Product? Product {get; set; }
}