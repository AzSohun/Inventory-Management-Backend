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

        private readonly ProductDbContext _context;
        private readonly ProductRepository _repository;


        public ProductsController(ProductDbContext context, ProductRepository repository)
        {
            _context = context;
            _repository = repository;
        }

    }
}
