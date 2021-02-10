using RestaurantEntities.Entities;
using System.Collections.Generic;
namespace RestaurantAPI.Services
{
    public class RestaurantService
    {
        public List<Restaurant> GetRestaurants()
        {
            var restaurants = new List<Restaurant>();
            for (int i = 1; i <= 7; i++)
            {
                restaurants.Add(new Restaurant
                {
                    Id = i,
                    Name = $"Restaurant_{i}",
                    Address = new Address
                    {
                        Id = i,
                        Street = $"Street_{i}",
                        Number = i,
                        City = $"City_{i}",
                        State = $"State_{i}",
                        Zip = $"Zip_{i}",
                        Country = $"Country_{i}"
                    },
                    StaffMembers = i * 10
                });
            }
            return restaurants;
        }


        public RestaurantMenu GetMenu(long id)
        {
            var restaurant = GetRestaurants().Find(r => r.Id == id);
            var menu = new RestaurantMenu()
            {
                Id=1,
                Restaurant = restaurant,
                RestaurantId = restaurant.Id
            };

            var foods = new FoodService().GetFoods();
            for (int i = 0; i < foods.Count; i++)
            {
                var food = foods[i];
                menu.Foods.Add(new RestaurantFood
                {
                    Food = food,
                    FoodId = food.Id
                });
            }
            return menu;
        }
    }
}
