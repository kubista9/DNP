using Microsoft.EntityFrameworkCore;
using Shared.Models;

namespace WebAPI.Data;

public class GolfDbContext : DbContext
{
	public DbSet<Player> Players { get; set; }
	public DbSet<HoleScore> HoleScores { get; set; }

	protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
	{
		optionsBuilder.UseSqlite("Data Source = ../WebAPI/Data/Golf.db");
		optionsBuilder.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
	}

	protected override void OnModelCreating(ModelBuilder modelBuilder)
	{
		modelBuilder.Entity<Player>().HasKey(player => player.PlayerId);
		modelBuilder.Entity<HoleScore>().HasKey(hole => hole.HoleScoreId);
		modelBuilder.Entity<HoleScore>()
			.HasOne(hole => hole.Player)
			.WithMany(player => player.Scores)
			.HasForeignKey(hole => hole.PlayerId);
	}
}

