using CurvaStore.Validation;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CurvaStore.Models
{
    public class Blog
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "you must enter the Blog Name")]
        [StringLength(90, ErrorMessage = "the name is very long,don't enter greater than 90 chars")]
        public string Tittle { get; set; }
        [Required(ErrorMessage = "you must enter the Blog Description")]
        [StringLength(2000, ErrorMessage = "the Description is very long,don't enter greater than 2000 chars")]
        public string Description { get; set; }
        [NotMapped]
        [Required (ErrorMessage ="you must enter image for Blog")]
        public IFormFile BlogImage { get; set; }
        public string Img { get; set; }
        [Required (ErrorMessage ="You must enter Date")]
        [DateOfBlog]
        public DateTime dateTime { get; set; }
        
    }
}
