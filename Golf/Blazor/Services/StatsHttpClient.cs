using System.Text.Json;

namespace Blazor.Services;

public class StatsHttpClient : IStatsService
{
	private readonly HttpClient _client;

	public StatsHttpClient(HttpClient client)
	{
		_client = client;
	}

	public async Task<double> GetHoleIdAvgStrikes(int holeId)
	{
		HttpResponseMessage response = await _client.GetAsync($"/Statistics/AverageStrikes/{holeId}");
		string content = await response.Content.ReadAsStringAsync();
		if (!response.IsSuccessStatusCode)
		{
			throw new Exception(content);
		}
		double score = JsonSerializer.Deserialize<double>(content, new JsonSerializerOptions
		{
			PropertyNameCaseInsensitive = true
		})!;
		return score;
	}

	public async Task<int> GetRoundIdStrikesByPlayer(int roundId, int playerId)
	{
		HttpResponseMessage response = await _client.GetAsync($"/Statistics/RoundIdStrikesByPlayer/{roundId}/{playerId}");
		string content = await response.Content.ReadAsStringAsync();
		if (!response.IsSuccessStatusCode)
		{

			throw new Exception(content);
		}
		int strikes = JsonSerializer.Deserialize<int>(content, new JsonSerializerOptions
		{
			PropertyNameCaseInsensitive = true
		})!;
		return strikes;
	}

	public async Task<int> GetPlayerIdHandicap(int playerId)
	{
		HttpResponseMessage response = await _client.GetAsync($"/Statistics/PlayerHandicap/{playerId}");
		string content = await response.Content.ReadAsStringAsync();
		if (!response.IsSuccessStatusCode)
		{
			throw new Exception(content);
		}
		int handicap = JsonSerializer.Deserialize<int>(content, new JsonSerializerOptions
		{
			PropertyNameCaseInsensitive = true
		})!;
		return handicap;
	}
}
