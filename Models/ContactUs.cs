using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;

namespace CurvaStore.Models
{
    public class ContactUs
    {
        [Key]
        public int Id { get; set; }
        [Required (ErrorMessage = "the FullName not valid")]
        public string FullName { get; set; }
        [Required(ErrorMessage = "the Email not valid")]
        [EmailAddress(ErrorMessage = "the Email not valid")]
        public string Email { get; set; }
        [Required(ErrorMessage = "the Phone not valid")]
        [RegularExpression(@"^\d{11}$",ErrorMessage = "the Phone not valid")]
        public string Phone { get; set; }
        [Required(ErrorMessage = "the Message not valid")]
        public string Message { get; set; }
    }
}
