using System.Collections;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using WebAPI.Domain;

namespace WebAPI.Data;

public class DataService : IDataService
{
	private static ArrayList _projects = new ArrayList();
	private static ArrayList _userStories = new ArrayList();


	public DataService()
	{

	}

	public void CreateProject(Project project)
	{
		_projects.Add(project);
	}

	public void AddUserStory(UserStory userStory)
	{
		_userStories.Add(userStory);
	}

	public IEnumerable<Project> GetProjectById(int id)
	{
		IEnumerable<Project> projectWithId = from Project project in _projects where project.Id == id select project;
		return projectWithId;
	}
}
