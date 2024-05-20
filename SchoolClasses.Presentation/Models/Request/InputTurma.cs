using System.ComponentModel.DataAnnotations;

namespace SchoolClasses.Presentation.Models.Request
{
    public class InputTurma
    {
        public int IdCurso { get; set; }
        public string Nome { get; set; }
        public int Ano { get; set; }
        public bool IsAtivo { get; set; } = true;
    }
}
