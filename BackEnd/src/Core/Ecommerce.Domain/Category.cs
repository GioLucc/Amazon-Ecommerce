using System.ComponentModel.DataAnnotations.Schema;
using Ecommerce.Domain;
using Ecommerce.Domain.Common;

namespace Ecommerce.Domain;

public class Category : BaseDomainModel
{
    [Column(TypeName = "NVARCHAR(100)")]
    public string? Nombre {get; set; }

    public virtual ICollection<Product>? Products {get; set; }
}
