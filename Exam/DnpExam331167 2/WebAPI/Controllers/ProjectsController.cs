using System.Collections;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Data;
using WebAPI.Domain;

namespace WebAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class ProjectsController : ControllerBase
{
	private readonly IDataService _dataService;

	public ProjectsController(IDataService dataService)
	{
		_dataService = dataService;
	}

	[HttpPost]
	public ObjectResult CreateProject(Project project)
	{
		try
		{
			_dataService.CreateProject(project);
		}
		catch (Exception e)
		{
			Console.WriteLine(e);
			return StatusCode(500, e.Message);
		}

		return Created($"/projects/{project.Id}", project);;
	}

	[HttpPost]
	public ObjectResult CreateUserStory(UserStory userStory)
	{
		try
		{
			_dataService.AddUserStory(userStory);
		}
		catch (Exception e)
		{
			Console.WriteLine(e);
			return StatusCode(500, e.Message);
		}
		return Created($"/userStories/{userStory.ProjectId}.}}", userStory);;
	}

	[HttpGet("Project/{id}")]
	public ObjectResult GetProjectById(int id)
	{
		try
		{
			_dataService.GetProjectById(id);
		}
		catch (Exception e)
		{
			// Log the exception
			return StatusCode(500, e.Message);
		}
	}
	/*return Created($"/userStories/{userStory.ProjectId}.}}", userStory);;*/
}
