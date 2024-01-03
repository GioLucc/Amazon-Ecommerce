using System.ComponentModel.DataAnnotations.Schema;
using Ecommerce.Domain.Common;

namespace Ecommerce.Domain;

public class Adress : BaseDomainModel
{
    public string? Direccion { get; set; }
    public string? Ciudad { get; set; }
    public string? Departamento { get; set; }
    public string? CodigoPostal { get; set; }
    public string? Username { get; set; }
    public string? Pais { get; set; }
}