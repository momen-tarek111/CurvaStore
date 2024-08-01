﻿using CurvaStore.Models;
using System.ComponentModel.DataAnnotations;

namespace CurvaStore.Validation
{
    public class DateOfBlog:ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
              Blog blog =  (Blog)validationContext.ObjectInstance;
              
              DateTime date;
              if(DateTime.TryParse(value.ToString(), out date)) {
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
