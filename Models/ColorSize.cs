using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Drawing;

namespace CurvaStore.Models
{
    public class ColorSize
    {
        
        public int id {  get; set; }
        public int ProductId { get; set; }
        [ForeignKey ("ProductId")]
        
        public string color { get; set; }
        [Required (ErrorMessage ="you must enter size of Product")]
        [RegularExpression(@"^\d+$|^[a-zA-Z]+$")]
        public string Size { get; set; }
        [Required(ErrorMessage = "you must enter size of Product")]
        [Range (1,10000,ErrorMessage = "min value = 1 && max value = 10000")]
        public int Quantity { get; set; }
    }
}
