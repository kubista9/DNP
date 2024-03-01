using Microsoft.EntityFrameworkCore.ChangeTracking;
using Shared.Models;

namespace WebApplication1.Data;

public class DataAccess : IDataAccess
{
	private readonly StudentContext _context;

	public DataAccess(StudentContext context)
	{
		_context = context;
	}

	public async Task<Student> CreateStudentAsync(Student student)
	{
		/*ValidateStudent(dto);*/
		Student studentToCreate = new Student()
		{
			Name = student.Name,
			Programme = student.Programme
		};

		EntityEntry<Student> newStudent = await _context.Students.AddAsync(studentToCreate);
		await _context.SaveChangesAsync();
		return newStudent.Entity;
	}

	/*public Task<ICollection<Student>> GetAllStudentsAsync()
	{
		throw new NotImplementedException();
	}

	public Task AddGradeToStudentAsync(GradeInCourse grade, int studentId)
	{
		throw new NotImplementedException();
	}

	public Task<StatisticsOverviewDto> GetCourseStatisticsAsync()
	{
		throw new NotImplementedException();
	}*/
}
