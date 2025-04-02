using Microsoft.EntityFrameworkCore;
using Semester6.Models;
//using ToetsRegistratie.Models;

public class ToetsContext : DbContext
{
    public DbSet<Student> Studenten { get; set; }
    public DbSet<Docent> Docenten { get; set; }
    public DbSet<Vak> Vakken { get; set; }
    public DbSet<Toets> Toetsen { get; set; }
    public DbSet<ToetsResultaat> ToetsResultaten { get; set; }
    public DbSet<CijferWijziging> CijferWijzigingen { get; set; }


    // Deze constructor is voor runtime (zoals je al had)
    public ToetsContext(DbContextOptions<ToetsContext> options) : base(options) { }

    // ===>>> Deze lege constructor toevoegen:
    public ToetsContext() { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ToetsResultaat>()
            .HasIndex(tr => new { tr.StudentId, tr.ToetsId, tr.IsHerkansing })
            .IsUnique();
    }
}
