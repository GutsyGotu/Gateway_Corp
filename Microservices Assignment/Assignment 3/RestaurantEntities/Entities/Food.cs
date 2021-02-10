using RestaurantEntities.Enum;

namespace RestaurantEntities.Entities
{
    public class Food
    {
        public Food()
        {
        }

        public long Id { get; set; }
        public string Name { get; set; }
        public FoodEnum Type { get; set; }
        public string TypeName => Type.ToString();
    }
}