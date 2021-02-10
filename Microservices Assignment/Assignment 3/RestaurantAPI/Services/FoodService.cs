using RestaurantEntities.Entities;
using RestaurantEntities.Enum;
using System.Collections.Generic;

namespace RestaurantAPI.Services
{
    public class FoodService
    {
        public List<Food> GetFoods()
        {
            var foods = new List<Food>();
            for (int i = 1; i <= 7; i++)
            {
                foods.Add(new Food
                {
                    Id = i,
                    Name = $"Food_{i}",
                    Type = FoodEnum.Chinese,
                });
            }
            return foods;
        }
    }
}
