using Microsoft.AspNetCore.Mvc;
using Shared.Models;
using WebApplication1.Data;

namespace WebApplication1.Controllers;

[ApiController]
[Route("[controller]")]
public class StudentsController : ControllerBase
{
	private readonly IDataAccess _dataAccess;

	public StudentsController(IDataAccess dataAccess)
	{
		_dataAccess = dataAccess;
	}

	[HttpPost]
	public async Task<ActionResult<Student>> CreatePlayerAsync(Student student)
	{
		try
		{
			await _dataAccess.CreateStudentAsync(student);
			return Created($"/students/{student.StudentId}", student);

		}
		catch (Exception e)
		{
			Console.WriteLine(e);
			return StatusCode(500, e.Message);
		}
	}
}
