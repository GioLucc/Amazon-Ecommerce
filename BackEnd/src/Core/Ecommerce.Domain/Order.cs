using System.ComponentModel.DataAnnotations.Schema;
using Ecommerce.Domain.Common;

namespace Ecommerce.Domain;

public class Order : BaseDomainModel // Copia del shopping cart con datos de la tarjeta
{

    public Order() {}

    public Order(
        string buyerName,
        string buyerEmail,
        OrderAdress orderAdress,
        decimal subTotal,
        decimal total,
        decimal tax,
        decimal shippingPrice

    ){
        BuyerName = buyerName;
        BuyerEmail = buyerEmail;
        OrderAdress = orderAdress;
        SubTotal = subTotal;
        Total = total;
        Tax = tax;
        ShippingPrice = shippingPrice;
    }
    

    public string? BuyerName { get; set; }
    public string? BuyerEmail { get; set; }
    public OrderAdress? OrderAdress { get; set; }
    public IReadOnlyList<OrderItem>? OrderItems { get; set; } // Quantity of items in order

    [Column(TypeName = "decimal(10,2)")]
    public decimal SubTotal { get; set; }

    public OrderStatus? Status {get; set; } = OrderStatus.Pending;

    [Column(TypeName = "decimal(10,2)")]
    public decimal Total { get; set; }

    [Column(TypeName = "decimal(10,2)")]
    public decimal Tax { get; set; }

    [Column(TypeName = "decimal(10,2)")]
    public decimal ShippingPrice { get; set; }

    public string? ClientSecretCode { get; set; }

    public string? StripeApiKey { get; set; }



}

