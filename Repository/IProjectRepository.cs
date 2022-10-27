using project.Models;

namespace project.Repository;
  public interface IProjectRepository
  {
    IEnumerable<Inscricao> GetAllInscricao();
    void AddCurso(Curso nomeCurso);
    void AddCandidato(Candidato candidato);
    void AddInscricao(Inscricao inscricao);
  }
