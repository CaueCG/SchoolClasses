using System.ComponentModel.DataAnnotations;

namespace SchoolClasses.Presentation.Models.Request
{
    public class InputAluno
    {
        public string Nome { get; set; }
        public string Usuario { get; set; }
        public string Senha { get; set; }
        public bool IsAtivo { get; set; } = true;
    }
}
