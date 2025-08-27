using System.ComponentModel.DataAnnotations;

namespace WebApi.Data.Entities;

public class OrderEntity
{
    [Key]
    public int Id { get; set; }
    public DateTime OrderDate { get; set; }
    public DateTime DueDate { get; set; }
    public string CustomerId { get; set; } = null!;
    public string CustomerName { get; set; } = null!;
}
