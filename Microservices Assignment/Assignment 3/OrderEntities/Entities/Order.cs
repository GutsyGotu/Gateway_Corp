using System;

namespace OrderEntities.Entities
{
    public class Order
    {
        public long Id { get; set; }
        public string Number { get; set; }

        public DateTime PlaceOn { get; set; }
        public long RestaurantId { get; set; }
        public Restaurant Restaurant { get; set; }

        public long FoodId { get; set; }
        public string Food { get; set; }

        public int Quantity { get; set; }
        public double Amount { get; set; }
    }
}
