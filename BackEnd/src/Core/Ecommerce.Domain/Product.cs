using System.Text;
using Ecommerce.Domain;
using Ecommerce.Domain.Common;

namespace Ecommer.Domain;

public class Product : BaseDomainModel
{
    public string? Nombre { get; set; }
    public Decimal Precio { get; set; }
    public string? Descripcion { get; set; }
    public int Rating { get; set; }
    public string? Vendedor { get; set; }
    public int Stock { get; set; }
    public ProductStatus Status { get; set; }
    public int CategoryId { get; set; }
}