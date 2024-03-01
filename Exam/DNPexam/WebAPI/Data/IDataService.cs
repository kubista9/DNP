using WebAPI.Domain;

namespace WebAPI.Data;

public interface IDataService
{
	void CreateProject(Project project);
	void AddUserStory(UserStory userStory);
	IEnumerable<Project> GetProjectById(int id);
}
