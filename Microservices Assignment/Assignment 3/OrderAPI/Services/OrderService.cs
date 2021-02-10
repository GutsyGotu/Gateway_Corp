using OrderEntities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace OrderAPI.Services
{
    public class OrderService
    {
        public IEnumerable<Order> GetOrders(long? id = null)
        {
            var orders = new List<Order>();
            var restaurants = GetRestaurants();
            if (id != null)
            {
                restaurants = restaurants.Where(r => r.RestaurantId == id);
            }
            foreach (var restaurant in restaurants)
            {
                for (int i = 1; i <= 3; i++)
                {
                    orders.Add(new Order
                    {
                        Id = i,
                        Number = $"{restaurant.Name}_OrderNumber_{i}",
                        Amount = (double)i * 4.96,
                        Food = $"Food_{i}",
                        FoodId = i,
                        PlaceOn = DateTime.Now.AddMinutes(i * (-10)),
                        Quantity = i,
                        RestaurantId = restaurant.RestaurantId,
                        Restaurant = restaurant
                    });
                }
            }
            return orders;
        }

        private IEnumerable<Restaurant> GetRestaurants()
        {
            var restaurants = new List<Restaurant>();
            for (int i = 1; i <= 3; i++)
            {
                restaurants.Add(new Restaurant
                {
                    Id = i,
                    RestaurantId = i,
                    Name = $"Restaurant_{i}",
                    Address = $"Address_{i}"
                });
            }
            return restaurants;
        }
    }
}
