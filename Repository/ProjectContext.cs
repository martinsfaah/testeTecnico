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
    optionsBuilder.UseSqlite("Data Source=Project.db");
  }
  protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      modelBuilder.Entity<Candidato>()
          .HasKey(c => c.CandidatoId);

      modelBuilder.Entity<Curso>()
          .HasKey(c => c.CursoId);

      
      modelBuilder.Entity<Inscricao>()
        .HasKey(bc => new { bc.CandidatoId, bc.CursoId });  
      modelBuilder.Entity<Inscricao>()
        .HasOne(bc => bc.Candidato)
        .WithMany(b => b.Inscricoes)
        .HasForeignKey(bc => bc.CandidatoId);  
      modelBuilder.Entity<Inscricao>()
        .HasOne(bc => bc.Curso)
        .WithMany(c => c.Inscricoes)
        .HasForeignKey(bc => bc.CursoId);


    }

}
