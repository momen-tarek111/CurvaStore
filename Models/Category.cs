using System.ComponentModel.DataAnnotations;

namespace CurvaStore.Models
{
    public class Category
    {
        [Key]
        public int id { get; set; }
        public string Name { get; set; }
       
    }
}
