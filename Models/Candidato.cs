namespace project.Models
{
  public class Candidato
  {
    public int CandidatoId { get; set; }
    public string Nome { get; set; }
    public string Cpf { get; set; }

    public ICollection<Inscricao> Inscricoes { get; set; }

  }
}
