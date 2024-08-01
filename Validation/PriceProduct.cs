using CurvaStore.Models;
using CurvaStore.ModelView;
using System.ComponentModel.DataAnnotations;

namespace CurvaStore.Validation
{
    public class PriceProduct:ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            Product p = (Product)validationContext.ObjectInstance;
            double price;
            if(double.TryParse(value.ToString(), out price))
            {
                if (price >= p.OldPrice &&p.OldPrice!=0)
                {
                    return new ValidationResult("you must enter price less than Old Price , enter 0 in Old Price in no discount status");
                }
            }
            return ValidationResult.Success;
        }
    }
}
