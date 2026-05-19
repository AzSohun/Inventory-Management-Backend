using FluentValidation;
using InventoryManagement.Application.DTOs;
using InventoryManagement.Application.Interfaces;
using InventoryManagement.Domain.Entities;
using Microsoft.AspNetCore.Mvc;


namespace InventoryManagement.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {

        private readonly IValidator<CreateProductDto> _validator;
        private readonly IProductRepository _repository;


        public ProductsController(IValidator<CreateProductDto> validator, IProductRepository repository)
        {
            _validator = validator;
            _repository = repository;
        }


        [HttpPost]
        public async Task<IActionResult> CreateProduct([FromBody] CreateProductDto dto)
        {

            var validateResult = await _validator.ValidateAsync(dto);

            if (!validateResult.IsValid)
            {
                return BadRequest(validateResult.Errors);
            }

            var newProduct = new Product
            {
                Id = Guid.NewGuid(),
                Name = dto.Name,
                Price = dto.Price,
                StockQuantity = dto.StockQuantity
            };

            await _repository.CreateAsync(newProduct);

            return CreatedAtAction(nameof(GetProductById), new {id = newProduct.Id}, newProduct);

        }


        [HttpGet("{id}")]
        public async Task<IActionResult> GetProductById(Guid id)
        {

            var product = await _repository.GetByIdAsync(id);

            if(product == null)
            {
                return NotFound();
            }

            return Ok(product);

        }
    }
}
