using SchoolClasses.Application.Validations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolClasses.Application.RequestModels
{
    public class InputTurma
    {
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public int IdCurso { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [AnoTurmaValidation]
        public int Ano { get; set; }
        public bool IsAtivo { get; set; } = true;
    }
}
