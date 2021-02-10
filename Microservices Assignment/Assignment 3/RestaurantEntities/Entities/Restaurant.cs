namespace RestaurantEntities.Entities
{
    public class Restaurant
    {
        public Restaurant()
        {
        }
        public long Id { get; set; }
        public string Name { get; set; }
        public Address Address { get; set; }
        public int StaffMembers { get; set; }
    }
}
