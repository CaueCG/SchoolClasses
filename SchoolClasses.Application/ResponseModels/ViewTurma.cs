using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolClasses.Application.ResponseModels
{
    public class ViewTurma : ViewBaseResponse
    {
        public ViewTurma() { }
        public ViewTurma(int id, int idCurso, string nome, int ano, bool isAtivo, DateTime dtCriacao)
        {
            Id = id;
            IdCurso = idCurso;
            Nome = nome;
            Ano = ano;
            IsAtivo = isAtivo;
            DtCriacao = dtCriacao;
        }

        public int Id { get; set; }
        public int IdCurso { get; set; }
        public string Nome { get; set; }
        public int Ano { get; set; }
        public bool IsAtivo { get; set; }
        public DateTime DtCriacao { get; set; }

    }
}
