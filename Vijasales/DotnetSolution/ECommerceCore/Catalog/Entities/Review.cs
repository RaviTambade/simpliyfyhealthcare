using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalog.Entities.Review
{
    public class Reviews
    {
        public int Id { get; set; }
        public int ProductId {  get; set; }
        public int UserId {  get; set; }
        public int Rating {  get; set; }
        public string ReviewText {  get; set; }
        public DateTime Created_at { get; set; }



    }
}
