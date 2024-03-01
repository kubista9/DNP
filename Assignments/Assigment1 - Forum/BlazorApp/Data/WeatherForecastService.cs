namespace BlazorApp1.Data;

public class WeatherForecastService
{
	private static readonly string[] Summaries = new[]
	{
		"Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
	};

	public Task<WeatherForecast[]> GetForecastAsync(DateOnly startDate)
	{
		var client = new HttpClient();
		return null;
	}

	//contructor
}
