
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

	[HttpGet]
	public async Task<ActionResult<List<ProductResponseDto>>> GetAll()
	{
		var products = await _productService.GetAllAsync();
		return Ok(products);
	}

	[HttpGet("{id}")]
	public async Task<ActionResult<ProductResponseDto?>> GetById(int id)
	{
		var product = await _productService.GetByIdAsync(id);
		if (product == null)
		{
			return NotFound();
		}
		return Ok(product);
	}

	[HttpPatch("{id}")]
	public async Task<ActionResult<ProductResponseDto>> update(int id,UpdateProductDto dto)
	{
		var product = await _productService.UpdateAsync(id,dto);
		return Ok(product);
	}
}
