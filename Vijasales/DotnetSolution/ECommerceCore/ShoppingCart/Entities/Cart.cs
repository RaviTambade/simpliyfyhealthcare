namespace ShoppingCart.Entities
{
    public class Cart
    {
        public List<Items> Items { get; set; }
        public Cart()
        {
            Items = new List<Items>();
        }

    }
}
