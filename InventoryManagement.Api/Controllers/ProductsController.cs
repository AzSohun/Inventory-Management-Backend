using FluentValidation;
using InventoryManagement.Application.DTOs;
using InventoryManagement.Application.Interfaces;
using InventoryManagement.Application.Validators;
using InventoryManagement.Domain.Entities;
using InventoryManagement.Infastructure.Data;
using InventoryManagement.Infastructure.Repositories;
using Microsoft.AspNetCore.Http;
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

            return Ok(newProduct);

        }


    }
}
