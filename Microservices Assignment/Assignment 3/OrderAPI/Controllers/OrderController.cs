using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using OrderAPI.Services;
using OrderEntities.Entities;
using System.Collections.Generic;

namespace OrderAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OrderController : ControllerBase
    {
        private readonly ILogger<OrderController> _logger;

        public OrderController(ILogger<OrderController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<Order> GetOrders()
        {
            return new OrderService().GetOrders();
        }


        [HttpGet, Route("GetOrder/{id}")]
        public IEnumerable<Order> GetOrder(long id)
        {
            return new OrderService().GetOrders(id: id);
        }

    }
}
