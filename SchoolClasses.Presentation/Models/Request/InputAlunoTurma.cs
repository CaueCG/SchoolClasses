using System.ComponentModel.DataAnnotations;

namespace SchoolClasses.Presentation.Models.Request
{
    public class InputAlunoTurma
    {
        public int IdAluno { get; set; }
        public int IdTurma { get; set; }
    }
}
