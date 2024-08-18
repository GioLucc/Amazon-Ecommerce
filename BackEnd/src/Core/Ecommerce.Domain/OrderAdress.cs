using System.ComponentModel.DataAnnotations.Schema;
using Ecommerce.Domain;
using Ecommerce.Domain.Common;

namespace Ecommerce.Domain;

public class OrderAdress : BaseDomainModel // Class for the adress of each order
{
    public string? Adress {get; set; }
    public string? City {get; set; }
    public string? Apartment {get; set; }
    public string? PostalCode {get; set; }
    public string? Username {get; set; }
    public string? Country {get; set; }

}