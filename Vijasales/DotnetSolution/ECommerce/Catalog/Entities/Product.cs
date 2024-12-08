using System;

namespace Catalog.Entities
{
    public class  Product
    {


        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Brand { get; set; }
        public decimal Price { get; set; }
        public int Stock { get; set; }
        public string Category { get; set; }
        public DateTime LastModified { get; set; }
        public string ImageUrl { get; set; }
        public override string ToString()
        {
            return Id + " " + Title + " " + Description;
        }


    }
}


  

