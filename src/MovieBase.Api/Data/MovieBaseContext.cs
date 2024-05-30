using Microsoft.EntityFrameworkCore;
using MovieBase.Api.Data.Entities;

namespace MovieBase.Api.Data;

public class MovieBaseContext : DbContext
{
    protected override void OnConfiguring(DbContextOptionsBuilder options) =>
        options.UseSqlite("Data Source=movies.db");

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        builder.ApplyConfigurationsFromAssembly(typeof(MovieBaseContext).Assembly);
        builder.UseCollation("NOCASE");
    }

    public DbSet<Movie> Movies => Set<Movie>();
    public DbSet<Review> Reviews => Set<Review>();
}