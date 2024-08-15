using CurvaStore.Models;
using CurvaStore.ModelView;
using System.ComponentModel.DataAnnotations;

namespace CurvaStore.Validation
{
    public class dateval:ValidationAttribute

    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            DateTime date;
            if (DateTime.TryParse(value.ToString(), out date))
            {
                if (date > DateTime.Now)
                {
                    return new ValidationResult("not Enter date in futur");
                }
                return ValidationResult.Success;
            }
            return ValidationResult.Success;
        }
    }
}
