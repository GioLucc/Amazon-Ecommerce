using System.ComponentModel.DataAnnotations.Schema;
using Ecommer.Domain;
using Ecommerce.Domain.Common;

namespace Ecommerce.Domain;

public class  OrderItem : BaseDomainModel 
{
    public Product? Product { get; set; }
    public int ProductId { get; set; }

    // [Column(TypeName = "decimal(10,2)")] Esta regla se configuró en configuration de Ecommmerce.Domain
    public decimal Price { get; set; }
    public int Quantity { get; set; }
    public Order? Order { get; set; }
    public int OrderId { get; set; }
    public int ProductItemId { get; set; }
    public string? ProductName { get; set; }
    public string? ImageUrl { get; set; }
}