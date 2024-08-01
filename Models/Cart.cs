using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CurvaStore.Models
{
    public class Cart
    {
        [Key]
        public int Id { get; set; }
        public string UserId { get; set; }
        [ForeignKey("UserId")]
        public int productId { get; set; }
        public int colorSizeId { get; set; }
        public int QuantityOfProduct {  get; set; }
        public Product ?product { get; set; }
        public ColorSize ?colorsize { get; set; }
    }
}
