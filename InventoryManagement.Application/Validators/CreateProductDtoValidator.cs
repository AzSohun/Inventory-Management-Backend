using FluentValidation;
using InventoryManagement.Application.DTOs;


namespace InventoryManagement.Application.Validators
{
    public class CreateProductDtoValidator: AbstractValidator<CreateProductDto>
    {

        public CreateProductDtoValidator()
        {
            RuleFor(x => x.Name).MaximumLength(100).WithMessage("Product Name Must Not Exceed 100 Characters.");

            RuleFor(x => x.Price).GreaterThan(0).WithMessage("Product Price Must Be Greater Than 0");

            RuleFor(x => x.StockQuantity).GreaterThanOrEqualTo(0).WithMessage("Stock Qunatity Must Not Be Negative.");
        }
    }
}
