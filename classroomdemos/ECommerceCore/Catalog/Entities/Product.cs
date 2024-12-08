namespace Catalog.Entities
{

    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double UnitPrice { get; set; }
        public int Quantity { get; set; }
        public string ImageUrl { get; set; }

        public override string ToString()
        {
            return Id + " " + Name + " " + Description;
        }
    }
}
