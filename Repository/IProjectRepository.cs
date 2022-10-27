using project.Models;

namespace project.Repository;
  public interface IProjectRepository
  {
    IEnumerable<Inscricao> GetInscricao();
    void AddCurso(Curso nomeCurso);
    void AddCandidato(Candidato candidato);
    void AddInscricao(Inscricao inscricao);
  }
