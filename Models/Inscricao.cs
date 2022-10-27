namespace project.Models
{
  public class Inscricao
  {

    public int CandidatoId { get; set; }
    public Candidato Candidato { get; set; }
    public int CursoId { get; set; }
    public Curso Curso { get; set; }

  }
}