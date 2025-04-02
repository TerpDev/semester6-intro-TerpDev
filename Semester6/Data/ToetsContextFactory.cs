using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

public class ToetsContextFactory : IDesignTimeDbContextFactory<ToetsContext>
{
    public ToetsContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<ToetsContext>();
        optionsBuilder.UseSqlServer("Server=LAPTOP-DANIEL\\MSSQLSERVER02;Database=ToetsDB;Trusted_Connection=True;TrustServerCertificate=True");

        return new ToetsContext(optionsBuilder.Options);
    }
}
