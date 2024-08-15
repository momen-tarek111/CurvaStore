using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace CurvaStore.Models
{
    public class CurvaUser:IdentityUser
    {
        public string ?FullName { get; set; }
        public string ?Gender { get; set; }
        public DateOnly ?date { get; set; }
        [NotMapped]
        public IFormFile ?UserImage { get; set; }
        public string? Img { get; set; }

    }
}
