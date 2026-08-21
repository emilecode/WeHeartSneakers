using System.ComponentModel.DataAnnotations;
namespace WeHeartSneakers.API.DTOs.Products;

public record UpdateProductDto(

	string? Name,
	string? Description,

	[Range(0.01, double.MaxValue)]
	decimal? Price,

	bool? IsActive
);
