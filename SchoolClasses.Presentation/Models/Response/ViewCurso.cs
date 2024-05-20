namespace SchoolClasses.Presentation.Models.Response
{
    public class ViewCurso
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
