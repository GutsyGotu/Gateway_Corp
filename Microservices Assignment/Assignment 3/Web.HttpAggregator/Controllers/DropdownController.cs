using CommonObjects.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using RestSharp;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Web.HttpAggregator.Util;

namespace Web.HttpAggregator.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DropdownController : ControllerBase
    {
        private readonly ILogger<DropdownController> _logger;

        public DropdownController(ILogger<DropdownController> logger)
        {
            _logger = logger;
        }

        ///// <summary>
        ///// Get orders
        ///// </summary>
        ///// <returns></returns>
        //[HttpGet, Route("GetOrders")]
        //public IEnumerable<DropdownDto> GetOrders()
        //{
        //    return new OrderService().GetOrders().Select(r => new DropdownDto { Id = r.Id, Name = r.Number });
        //}


        ///// <summary>
        ///// Get foods
        ///// </summary>
        ///// <returns></returns>
        //[HttpGet, Route("GetFoods")]
        //public IEnumerable<DropdownDto> GetFoods()
        //{
        //    return new FoodService().GetFoods().Select(r => new DropdownDto { Id = r.Id, Name = r.Name });
        //}

        /// <summary>
        ///  Get restaurants
        /// </summary>
        /// <returns></returns>
        [HttpGet, Route("GetRestaurants")]
        public async Task<IEnumerable<DropdownDto>> GetRestaurants()
        {
            var restaurants = await HttpCall.GetRequest<List<DropdownDto>>("https://localhost:44369/Dropdown/GetRestaurants");
            var foods = await HttpCall.GetRequest<List<DropdownDto>>("https://localhost:44369/Dropdown/GetFoods");
            restaurants.AddRange(foods);
            return restaurants;
        }
    }
}
