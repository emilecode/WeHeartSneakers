namespace WeHeartSneakers.API.DTOs.Products;

public record UpdateProductDto(
	string? Name,
	string? Description,
	decimal? Price,
	bool? IsActive
);
