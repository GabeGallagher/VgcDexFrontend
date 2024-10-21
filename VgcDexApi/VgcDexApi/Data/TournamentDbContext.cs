using Microsoft.EntityFrameworkCore;

namespace VgcDexApi.Models
{
  public class TournamentDbContext : DbContext
  {
    public TournamentDbContext(DbContextOptions<TournamentDbContext> options) : base(options) { }

    public DbSet<Tournament> Tournaments { get; set; }
  }

}
