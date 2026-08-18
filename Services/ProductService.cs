
using WeHeartSneakers.API.Data;
using WeHeartSneakers.API.Entities;
using WeHeartSneakers.API.DTOs.Products;
namespace WeHeartSneakers.API.Services;

public class ProductService : IProductService
{
	private readonly AppDbContext _context;
	public ProductService(AppDbContext context)
	{
		_context = context;
	}

	public async Task<ProductResponseDto> CreateAsync(CreateProductDto dto)
	{
		var product = new Product
		{
			Name = dto.Name,
			Description = dto.Description,
			Price = dto.Price,
			IsActive = true,
			CreatedAt = DateTime.UtcNow
		};

		_context.Products.Add(product);
		await _context.SaveChangesAsync();
		return new ProductResponseDto(
			product.Id,
			product.Name,
			product.Description,
			product.Price,
			product.IsActive,
			product.CreatedAt,
			product.UpdatedAt
		);
	}

}
