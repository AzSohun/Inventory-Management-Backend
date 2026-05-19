using System;
using System.Collections.Generic;
using System.Text;

namespace InventoryManagement.Application.DTOs
{
    internal class ProductDto
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Name { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public int StockQuantity { get; set; }
    }
}
