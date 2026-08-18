namespace WeHeartSneakers.API.DTOs.Products;

public record ProductResponseDto(
	int Id,
	string Name,
	string? Description,
	decimal Price,
	bool IsActive,
	DateTime CreatedAt,
	DateTime? UpdatedAt
);
