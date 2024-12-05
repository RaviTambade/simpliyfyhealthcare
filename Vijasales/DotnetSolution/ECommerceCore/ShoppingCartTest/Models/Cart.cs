namespace ShoppingCartTest.Models
{
    public class Cart
    {
        public List<Item> Items { get; set; }
        public Cart()
        {
            this.Items = new List<Item>();
        }
    }
}
