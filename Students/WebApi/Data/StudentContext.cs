using Microsoft.EntityFrameworkCore;
using Shared.Models;

namespace WebApplication1.Data;

public class StudentContext : DbContext
{
	public DbSet<Student> Students { get; set; }
	public DbSet<GradeInCourse> Grades { get; set; }

	protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
	{
		optionsBuilder.UseSqlite("Data Source = ../WebAPI/Data/Student.db");
		optionsBuilder.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
	}

	protected override void OnModelCreating(ModelBuilder modelBuilder)
	{
		modelBuilder.Entity<Student>().HasKey(student => student.StudentId);
		modelBuilder.Entity<GradeInCourse>().HasKey(grade => grade.GradeInCourseId);
	}

}
