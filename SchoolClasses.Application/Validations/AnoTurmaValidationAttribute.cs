using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolClasses.Application.Validations
{
    public class AnoTurmaValidationAttribute : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            if (value != null)
            {
                if (value.ToString().Length != 4)
                    return new ValidationResult("O Ano da turma deve conter 4 dígitos");

                if (int.TryParse(value.ToString(), out var intValue))
                {
                    if (intValue < DateTime.Now.Year)
                        return new ValidationResult($"O Ano da turma deve ser maior ou igual ao ano atual ({DateTime.Now.Year}).");
                }
                else
                    return new ValidationResult("Ano deve ser um número válido.");

            }

            return ValidationResult.Success;
        }
    }
}
