namespace project.Models
{
  using System.ComponentModel.DataAnnotations;
  public class Candidato
  {
    [Key]
    public int CandidatoId { get; set; }
    public string? Nome { get; set; }
    public string? Cpf { get; set; }

    public ICollection<Inscricao>? Inscricoes { get; set; }

  }
}
