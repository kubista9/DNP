namespace WebAPI.Domain;

public class UserStory
{
	public int ProjectId { get; set; }
	public string Title { get; set; }
	public string Status { get; set; }
	public string Responsible { get; set; }

	public UserStory()
	{

	}
}
