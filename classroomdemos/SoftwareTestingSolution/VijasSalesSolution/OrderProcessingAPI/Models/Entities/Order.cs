namespace OrderProcessingAPI.Models.Entities
{
    public class Order
    {
        public int Id { get; set; } 
        public string Owner { get; set; }
        public double TotalAmount { get; set; }
       

    }
}
