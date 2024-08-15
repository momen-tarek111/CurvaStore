using CurvaStore.Validation;
using System.ComponentModel.DataAnnotations;

namespace CurvaStore.ModelView
{
    public class ChangePassword
    {
        [Required]
        
        [DataType(DataType.Password)]
        public string currpassword {  get; set; }
        [Required]
        [DataType(DataType.Password)]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 6)]

        public string newpassword { get; set; }
        [Required]
        [DataType(DataType.Password)]
        [Compare("newpassword", ErrorMessage = "The new password and confirmation password do not match.")]
        public string confirmnewpassword { get; set; }

    }

}
