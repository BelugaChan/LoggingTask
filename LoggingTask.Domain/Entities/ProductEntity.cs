using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LoggingTask.Domain.Entities;

[Table("product", Schema = "mainSchema")]
public class ProductEntity
{
    [Key]
    [Column("id")]
    public Guid Id { get; }

    [Column("name")]
    public string Name { get; set; } = string.Empty;

    [Column("price")]
    public decimal Price { get; set; }

    [Column("description")]
    public string Description { get; set; } = string.Empty;

    public delegate void UpdateAction<T>(T entity);
}