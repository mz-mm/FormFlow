using System.ComponentModel.DataAnnotations;

namespace FormService.Infrastructure.Context.Entities;

public class BaseEntity
{
    [Key]
    public int Id { get; set; } 
}
