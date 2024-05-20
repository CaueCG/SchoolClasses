using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolClasses.Application.RequestModels
{
    public class InputAlunoTurma
    {
        [Required(ErrorMessage = "Nenhum aluno selecionado")]
        public int IdAluno { get; set; }

        [Required(ErrorMessage = "Nenhuma turma selecionada")]
        public int IdTurma { get; set; }

    }
}
