using Microsoft.EntityFrameworkCore;
using project.Models;

namespace project.Repository
{
  public interface IProjectContext
  {
  public DbSet<Inscricao>? Inscricao { get; set; }
  public DbSet<Candidato>? Candidato { get; set; }
  public DbSet<Curso>? Curso { get; set; }
  
  public int SaveChanges(); 
  }
}