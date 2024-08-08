using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CurvaStore.Models
{
    public class WishList
    {
        [Key]
        public int id { get; set; }
        public int ProductId { get; set; }
        [ForeignKey("ProductId")]
        public string UserId { get; set; }
        public Product ?product { get; set; }

    }
}
