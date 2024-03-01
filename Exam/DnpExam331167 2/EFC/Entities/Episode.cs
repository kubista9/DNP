namespace ConsoleApp.Entities;

public class Episode
{
	public int EpisodeId { get; set; }
	public string Title { get; set; }
	public int Runtime { get; set; }
	public string SeasonId { get; set; }
	public int ShowId { get; set; }

	public Episode()
	{

	}
}
