namespace ProductCatalogueTest.Models
{
    public class CardModel
    {
        public int Id { get; set; }
        public string ImageUrl { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int Stock {  get; set; }
        public float Price { get; set; }
    }
}
