namespace ShoppingCartTest.Models
{
    public class Cart
    {
        public List<Items> Items { get; set; }
        public Cart()
        {
            this.Items = new List<Items>();
        }
    }
}
