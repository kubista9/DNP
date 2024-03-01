using System.ComponentModel.DataAnnotations;

namespace Shared.Models;

public class GradeInCourse
{
	public int GradeInCourseId { get; set; }
	/*[Required(ErrorMessage = "CourseCode is required.")]*/
	/*[StringLength(4, ErrorMessage = "CourseCode must be a maximum of 4 characters long.")]
	[RegularExpression("^(DNP1|DBS1|SWE1)$", ErrorMessage = "Invalid programme.")]*/
	public string CourseCode { get; set; }
	/*[Required(ErrorMessage = "Grade is required.")]*/
	public int Grade { get; set; }

	public GradeInCourse()
	{

	}
}
