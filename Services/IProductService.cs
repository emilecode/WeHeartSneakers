using WeHeartSneakers.API.DTOs.Products;
namespace WeHeartSneakers.API.Services;

public interface IProductService
{
	Task<ProductResponseDto> CreateAsync(CreateProductDto dto);
	Task<List<ProductResponseDto>> GetAllAsync(string? search);
	Task<ProductResponseDto?> GetByIdAsync(int id);
	Task<ProductResponseDto?> UpdateAsync(int id, UpdateProductDto dto);
	Task<bool> DeleteAsync(int id);
}
