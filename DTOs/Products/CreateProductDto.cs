namespace WeHeartSneakers.API.DTOs.Products;

public record CreateProductDto
(
	string Name,
	string? Description,
	decimal Price
);
