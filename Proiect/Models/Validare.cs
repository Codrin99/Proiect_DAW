using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Proiect.Models
{
    public class Validare : ValidationAttribute
    {
         protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            Produs p =(Produs)validationContext.ObjectInstance;
            int i = 0;
            bool result = int.TryParse(p.Pret, out i);

            return result ? ValidationResult.Success : new ValidationResult("Te rugam introdu un numar");
        }
    }
}