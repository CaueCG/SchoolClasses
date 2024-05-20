namespace SchoolClasses.Presentation.Models.Response
{
    public class ViewAluno
    {
        public ViewAluno() { }

        public ViewAluno(int id, string nome, string usuario, DateTime dtCriacao, bool isAtivo)
        {
            Id = id;
            Nome = nome;
            Usuario = usuario;
            DtCriacao = dtCriacao;
            IsAtivo = isAtivo;
        }

        public int Id { get; set; }
        public string Nome { get; set; }
        public string Usuario { get; set; }
        public DateTime DtCriacao { get; set; }
        public bool IsAtivo { get; set; }
    }
}
