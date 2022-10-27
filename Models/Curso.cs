namespace project.Models
{
  using System.ComponentModel.DataAnnotations;
  public class Curso
  {
    [Key]
    public int CursoId { get; set; }
    public string? Nome { get; set; }

  }
}