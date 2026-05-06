using System.ComponentModel.DataAnnotations;

namespace LoggingTask.Application.Dto;

public class RequestProductDto
{
    [Required]
    public string Name { get; set; } = string.Empty;

    [Required]
    public decimal Price { get; set; }
    
    public string Description { get; set; } = string.Empty;
}