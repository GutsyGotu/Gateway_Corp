using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using RestaurantAPI.Services;
using RestaurantEntities.Entities;
using System.Collections.Generic;

namespace RestaurantAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FoodController : ControllerBase
    {
        private readonly ILogger<FoodController> _logger;

        public FoodController(ILogger<FoodController> logger)
        {
            _logger = logger;
        }

        /// <summary>
        /// Get foods
        /// </summary>
        /// <returns></returns>
        [HttpGet, Route("GetFoods")]
        public IEnumerable<Food> Get()
        {
            return new FoodService().GetFoods();
        }
    }
}
