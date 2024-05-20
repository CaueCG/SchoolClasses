namespace SchoolClasses.Presentation.Models.Response
{
    public class ViewTurma
    {
        public ViewTurma() { }
        public ViewTurma(int id, int idCurso, string nomeCurso, string nome, int ano, bool isAtivo, DateTime dtCriacao)
        {
            Id = id;
            IdCurso = idCurso;
            NomeCurso = nomeCurso;
            Nome = nome;
            Ano = ano;
            IsAtivo = isAtivo;
            DtCriacao = dtCriacao;
        }

        public int Id { get; set; }
        public int IdCurso { get; set; }
        public string NomeCurso { get; set; }
        public string Nome { get; set; }
        public int Ano { get; set; }
        public bool IsAtivo { get; set; }
        public DateTime DtCriacao { get; set; }
    }
}
