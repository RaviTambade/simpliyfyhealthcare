using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CodeFirstApproachTest.Models
{
    public class SP_Product
    {
        [Required]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ProductId { get; set; }  

        [Required]
        [StringLength(100)]
        public string Name { get; set; }  

        public decimal UnitPrice { get; set; } 

        public int Stock { get; set; }

        [StringLength(100)]
        public string Description { get; set; } 
    }
}
