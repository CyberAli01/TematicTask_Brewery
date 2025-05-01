namespace BreweryApp.Models
{
    public class OrderBeer
    {
        public int OrderId { get; set; }
        public Order Order { get; set; }
        public int BeerId { get; set; }
        public Beer Beer { get; set; }
        public int Quantity { get; set; }
    }
}