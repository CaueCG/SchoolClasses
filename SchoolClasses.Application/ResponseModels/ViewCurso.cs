using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolClasses.Application.ResponseModels
{
    public class ViewCurso : ViewBaseResponse
    {
        public ViewCurso() { }

        public ViewCurso(int id, string nome)
        {
            Id = id;
            Nome = nome;
        }

        public int Id { get; set; }
        public string Nome { get; set; }
    }
}
