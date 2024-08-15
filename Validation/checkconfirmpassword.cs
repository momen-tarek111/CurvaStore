using CurvaStore.Models;
using CurvaStore.ModelView;
using System.ComponentModel.DataAnnotations;

namespace CurvaStore.Validation
{
    public class checkconfirmpassword: ValidationAttribute
    {
            protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
            {
                ChangePassword p = (ChangePassword)validationContext.ObjectInstance;
                string conpass=value.ToString();
                
                if (Equals(conpass,p.newpassword))
                {
                    return new ValidationResult("the confirm password must matched with new password");
                }
                
                return ValidationResult.Success;
            }
        
    }
}
