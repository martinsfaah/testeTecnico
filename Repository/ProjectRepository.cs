using Microsoft.EntityFrameworkCore;
using project.Models;

namespace project.Repository;

  public class ProjectRepository : IProjectRepository
  {
    protected readonly ProjectContext _context;
    public ProjectRepository(ProjectContext context)
    {
      _context = context;
      context.Database.EnsureCreated();
    }

    public IEnumerable<Inscricao> GetAllInscricao()
    {
      var all = _context.Inscricao.Include(o => o.Candidato).Include(o => o.Curso);
      return all;
    }

    public void AddCandidato(Candidato candidato)
    {
      if (candidato.Cpf.Length != 11 || candidato == null) throw new InvalidOperationException();

      _context.Candidato.Add(candidato);
      _context.SaveChanges();

    }
    
     public void AddCurso(Curso nomeCurso)
    {
      if (nomeCurso == null) throw new InvalidOperationException();

      _context.Curso.Add(nomeCurso);
      _context.SaveChanges();

    }

    public void AddInscricao(Inscricao inscricao)
    {
      if (inscricao == null) throw new InvalidOperationException();

      _context.Inscricao.Add(inscricao);
      _context.SaveChanges();

    }

  }
