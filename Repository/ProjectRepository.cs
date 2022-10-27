using project.Models;

namespace project.Repository;

  public class ProjectRepository : IProjectRepository
  {
    protected readonly ProjectContext _context;
    public ProjectRepository(ProjectContext context)
    {
      _context = context;
    }

    public IEnumerable<Inscricao> GetInscricao()
    {
      return _context.Inscricao;
    }

    public void AddCandidato(Candidato candidato)
    {
      if (candidato.Cpf.Length != 11 || candidato == null) throw new InvalidOperationException();

      _context.Candidato.Add(candidato);

    }
    
     public void AddCurso(Curso nomeCurso)
    {
      if (nomeCurso == null) throw new InvalidOperationException();

      _context.Curso.Add(nomeCurso);

    }

    public void AddInscricao(Inscricao inscricao)
    {
      if (inscricao == null) throw new InvalidOperationException();

      _context.Inscricao.Add(inscricao);

    }

  }
