using Shared.DTOs;
using Shared.Models;

namespace WebApplication1.Data;

public interface IDataAccess
{
	Task<Student> CreateStudentAsync(Student student);
	/*Task<ICollection<Student>> GetAllStudentsAsync();
	Task AddGradeToStudentAsync(GradeInCourse grade, int studentId);
	Task<StatisticsOverviewDto> GetCourseStatisticsAsync();*/
}
