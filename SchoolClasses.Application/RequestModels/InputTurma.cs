using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolClasses.Application.RequestModels
{
    public class InputTurma
    {
        public int IdCurso { get; set; }
        public string Nome { get; set; }
        public int Ano { get; set; }
        public bool IsAtivo { get; set; }
    }
}
