using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace SchoolClasses.Application.Validations
{
    public class UsuarioValidationAttribute : ValidationAttribute
    {
        private const string Pattern = @"^[a-z0-9.]+@[a-z0-9]+\.[a-z]+\.([a-z]+)?$";

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value != null)
            {
                var email = value.ToString();

                if (Regex.IsMatch(email, Pattern, RegexOptions.IgnoreCase))
                    return ValidationResult.Success;
                else
                    return new ValidationResult("O formato do usuário é inválido.");
            }
            else
                return new ValidationResult("O campo usuário é obrigatório");
        }
    }
}
