using System.ComponentModel.DataAnnotations;
namespace WeHeartSneakers.API.DTOs.Products;

public record CreateProductDto
(
	[Required]
	[StringLength(150)]
	string Name,

	[StringLength(2000)]
	string? Description,
	
	[Range(0.01,double.MaxValue)]
	decimal Price
);
