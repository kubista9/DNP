using ConsoleApp.Entities;
using Microsoft.EntityFrameworkCore;

namespace ConsoleApp.Data;

public class AppContext : DbContext
{
	public DbSet<Show> Shows { get; set; }
	public DbSet<Episode> Episodes { get; set; }

	protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
	{
		optionsBuilder.UseSqlite(@"Data Source = /Users/jakubkuka/RiderProjects/DnpExam331167/EFC/Data/Shows");
		optionsBuilder.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
	}

	protected override void OnModelCreating(ModelBuilder modelBuilder)
	{
		modelBuilder.Entity<Episode>().HasKey(episode => episode.EpisodeId);
		modelBuilder.Entity<Show>().HasKey(show => show.ShowId);
	}
}
