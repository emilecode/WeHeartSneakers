using WeHeartSneakers.API.DTOs.Products;
namespace WeHeartSneakers.API.Services;

public interface IProductService
{
	Task<ProductResponseDto> CreateAsync(CreateProductDto dto);
}
