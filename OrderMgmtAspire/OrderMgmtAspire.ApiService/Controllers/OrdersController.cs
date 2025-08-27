using Microsoft.AspNetCore.Mvc;
using OrderMgmtAspire.ApiService.Models;

namespace OrderMgmtAspire.ApiService.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrdersController : ControllerBase
    {
        private static readonly List<Order> Orders = new()
        {
            new Order { Id = 1, CustomerName = "Alice", Product = "Laptop", Quantity = 1, Price = 1200, OrderDate = DateTime.UtcNow.AddDays(-3) },
            new Order { Id = 2, CustomerName = "Bob", Product = "Phone", Quantity = 2, Price = 800, OrderDate = DateTime.UtcNow.AddDays(-1) },
            new Order { Id = 3, CustomerName = "Charlie", Product = "Headphones", Quantity = 3, Price = 150, OrderDate = DateTime.UtcNow }
        };

        [HttpGet]
        public IActionResult GetOrders() => Ok(Orders);

        [HttpGet("{id}")]
        public IActionResult GetOrder(int id) =>
            Orders.FirstOrDefault(o => o.Id == id) is Order order ? Ok(order) : NotFound();
    }
}
