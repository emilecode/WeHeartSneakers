using Microsoft.EntityFrameworkCore;
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

	public async Task<List<ProductResponseDto>> GetAllAsync()
	{
		return await _context.Products.Select(p => new ProductResponseDto(
			p.Id,
			p.Name,
			p.Description,
			p.Price,
			p.IsActive,
			p.CreatedAt,
			p.UpdatedAt

		)).ToListAsync();
	}

	public async Task<ProductResponseDto?> GetByIdAsync(int id)
	{

		var product = await _context.Products.FirstOrDefaultAsync(p => p.Id == id);
		if (product == null) return null;
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
	public async Task<ProductResponseDto?> UpdateAsync(int id, UpdateProductDto dto)
	{

		var product = await _context.Products.FirstOrDefaultAsync(p => p.Id == id);
		if (product == null) return null;

		if (dto.Name != null)
		{
			product.Name = dto.Name;
		}
		if (dto.Description != null)
		{
			product.Description = dto.Description;
		}
		if (dto.Price.HasValue)
		{
			product.Price = dto.Price.Value;
		}
		if (dto.IsActive.HasValue)
		{
			product.IsActive = dto.IsActive.Value;
		}
		product.UpdatedAt = DateTime.UtcNow;

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
