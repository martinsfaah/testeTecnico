namespace project.Models
{
  public class Curso
  {
    public int CursoId { get; set; }
    public string Nome { get; set; }
    public ICollection<Inscricao> Inscricoes { get; set; }

  }
}