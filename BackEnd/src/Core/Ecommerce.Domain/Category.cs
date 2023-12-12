using System.ComponentModel.DataAnnotations.Schema;
using Ecommerce.Domain.Common;

namespace Ecommerce.Domain;

public class CategoryId : BaseDomainModel
{
    [Column(TypeName = "NVARCHAR(100)")]
    public string? Nombre {get; set; }
}
