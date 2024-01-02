using System.Runtime.Serialization;

namespace Ecommerce.Domain;

public enum OrderStatus{
    [EnumMember(Value = "Pending")] 
    Pending,
    [EnumMember(Value = "The payment was successful")]
    Completed,

    [EnumMember(Value = "The product was shipped")]
    Sent, 

    [EnumMember(Value = "The payment had errors")]
    Error 
}