
using Microsoft.AspNetCore.Mvc;
using WeHeartSneakers.API.Services;
using WeHeartSneakers.API.DTOs.Products;


namespace WeHeartSneakers.API.Controllers;

[ApiController]
[Route("api/products")]
public class ProductController : ControllerBase
{
	private readonly IProductService _productService;

	public ProductController(IProductService productService)
	{
		_productService = productService;
	}
	[HttpPost]
	public async Task<ActionResult<ProductResponseDto>> Create(CreateProductDto dto)
	{
		var product = await _productService.CreateAsync(dto);
		return Ok(product);
	}
}
