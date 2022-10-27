namespace project.Models
{
  using System.ComponentModel.DataAnnotations;
  public class Inscricao
  {
    [Key]
    public int CandidatoId { get; set; }
    [Key]
    public int CursoId { get; set; }

  }
}