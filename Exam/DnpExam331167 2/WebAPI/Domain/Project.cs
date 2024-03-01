using System.Text.Json.Serialization;

namespace WebAPI.Domain;

public class Project
{
	public int Id { get; set; }
	public string Description { get; set; }
	public string Estimate { get; set; }

	[JsonIgnore]
	public ICollection<UserStory> UserStories { get; set; }
	public Project()
	{

	}
}
