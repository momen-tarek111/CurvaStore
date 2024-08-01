using CurvaStore.Validation;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CurvaStore.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "you must enter the Product Code")]
        [RegularExpression(@"^\d{5}$", ErrorMessage = "you must enter numbers only and length must be 5 digit")]
        public string code { get; set; }
        [Required(ErrorMessage = "you must enter the Product Name")]
        [StringLength(50,ErrorMessage ="the name is very long,don't enter greater than 50 chars")]
        public string Name { get; set; }
        [Required(ErrorMessage = "you must enter the Product Description if no found Description enter e ")]
        [StringLength(1000, ErrorMessage = "the name is very long,don't enter greater than 200 chars")]
        public string Description { get; set; }
        [Required(ErrorMessage = "you must enter the Product Price")]
        [Range(1,50000,ErrorMessage ="You must enter value between 1 to 50000")]
        [PriceProduct]
        public double price { get; set; }
        [Required(ErrorMessage = "enter 0 if no discount")]
        [Range(0, 50000, ErrorMessage = "You must enter value between 0 to 50000")]
        [OldPriceProduct]
        public double OldPrice { get; set; }
        [Required (ErrorMessage ="you Must Enter the Brand Name if no found Brand enter e")]
        [StringLength(20, ErrorMessage = "the name is very long,don't enter greater than 20 chars")]
        
        public string BrandName { get; set; }
        
        [StringLength(20, ErrorMessage = "the name is very long,don't enter greater than 20 chars")]
        [Required(ErrorMessage = "you Must Enter the Club Name if no found Club enter e")]
        public string ClubName { get; set; }
        
        [RegularExpression(@"\d{4}/\d{2}|e", ErrorMessage = "you must enter season like this 2022/23 OR Enter E if not found Season")]
        public string Season { get; set; }
        public bool InStock { get; set; }
        [NotMapped]
        [Required (ErrorMessage ="You must enter image for Product")]
        public IFormFile ProductImage { get; set; }
        public string? Img { get; set; }
        [Required (ErrorMessage ="you must choose the category")]
        public int CategoroyID { get; set; }
        [ForeignKey("CategoroyID")]
        public Category? category { get; set; }
    }
}
