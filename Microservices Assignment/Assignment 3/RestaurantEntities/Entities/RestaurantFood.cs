using System.Collections.Generic;

namespace RestaurantEntities.Entities
{
    public class RestaurantFood
    {
        public long FoodId { get; set; }
        public Food Food { get; set; }
    }

    public class RestaurantMenu
    {
        public RestaurantMenu()
        {
            Foods = new List<RestaurantFood>();
        }
        public long Id { get; set; }
        public long RestaurantId { get; set; }
        public Restaurant Restaurant { get; set; }
        public List<RestaurantFood> Foods { get; set; }
    }
}
