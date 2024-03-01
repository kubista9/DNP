using Shared.DTOs;

namespace Blazor.Services;

public class ScoringHttpClient : IScoringService
{
	private readonly HttpClient _client;

	public ScoringHttpClient(HttpClient client)
	{
		_client = client;
	}

	public async Task CreateHoleScoreAsync(HoleScoreCreationDto dto)
	{
		HttpResponseMessage response = await _client.PostAsJsonAsync("/holeScores", dto);
		if (!response.IsSuccessStatusCode)
		{
			string content = await response.Content.ReadAsStringAsync();
			throw new Exception(content);
		}
	}
}
