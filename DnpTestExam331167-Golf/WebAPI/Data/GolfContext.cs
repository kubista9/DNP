using Shared.Models;

namespace EfcDataAccess;

public class GolfContext : DbContext
{
	public DbSet<Player> Players { get; set; }
	public DbSet<HoleScore> HoleScores { get; set; }

	protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
	{
		optionsBuilder.UseSqlite("Data Source = /Users/jakubkuka/RiderProjects/DnpTestExam331167/EfcDataAccess/Golf.db");
		optionsBuilder.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
	}

	protected override void OnModelCreating(ModelBuilder modelBuilder)
	{
		modelBuilder.Entity<Player>().HasKey(p => p.PlayerId);
		modelBuilder.Entity<HoleScore>().HasKey(holeScore => holeScore.HoleId);
	}
}
