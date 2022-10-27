using Microsoft.EntityFrameworkCore;
using project.Models;

namespace project.Repository;

public class ProjectContext : DbContext, IProjectContext
{
  public ProjectContext(DbContextOptions<ProjectContext> options) : base(options) {}
  public DbSet<Inscricao>? Inscricao { get; set; }
  public DbSet<Candidato>? Candidato { get; set; }
  public DbSet<Curso>? Curso { get; set; }
  protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
  {
    if(!optionsBuilder.IsConfigured)
    {
      string connectionString = "Server=127.0.0.1;Database=project;User Id=sa;Password=Project27out;";
      optionsBuilder.UseSqlServer(connectionString);
    }

  }
  protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      modelBuilder.Entity<Candidato>()
          .HasKey(c => c.CandidatoId);

      modelBuilder.Entity<Curso>()
          .HasKey(c => c.CursoId);

      modelBuilder.Entity<Inscricao>();
      //     .HasKey(i => i.CandidatoId, i.CursoId)
      //     .HasForeignKey(i => i.candidatoId, i.cursoId);
      
      // modelBuilder.Entity<Inscricao>()
      //     .HasKey(i => i.CursoId)
      //     .HasForeignKey(i => i.candidatoId, i.cursoId);


    }

}
