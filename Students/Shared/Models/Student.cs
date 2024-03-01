using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Shared.Models;

public class Student
{
	public int StudentId { get; set; }
	/*[MaxLength(25, ErrorMessage = "Name has more than 25 characters.")]*/
	/*[Required(ErrorMessage = "Name is required.")]*/
	public string Name { get; set; }
	/*[RegularExpression("^(Software|GBE|Mechanical)$", ErrorMessage = "Invalid programme.")]*/
	/*[Required(ErrorMessage = "Programme is required.")]*/
	public string Programme { get; set; }
	[JsonIgnore] public ICollection<GradeInCourse> Grades { get; set; } = new List<GradeInCourse>();

	public Student(int studentId, string name, string programme)
	{
		StudentId = studentId;
		Name = name;
		Programme = programme;
	}

	public Student()
	{
	}
}
