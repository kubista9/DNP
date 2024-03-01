using System.Text.Json;
using Shared.DTOs;
using Shared.Models;

namespace Blazor.Services;

public class ScoringHttpClient : IScoringService
{
	private readonly HttpClient _client;

	public ScoringHttpClient(HttpClient client)
	{
		_client = client;
	}

	public async Task CreateAsync(HoleScoreCreationDto dto)
	{
		HttpResponseMessage response = await _client.PostAsJsonAsync("/holeScores", dto);
		if (!response.IsSuccessStatusCode)
		{
			string content = await response.Content.ReadAsStringAsync();
			throw new Exception(content);
		}
	}

	public async Task<ICollection<HoleScore>> GetAsync(int holeId, int roundId, int numberOfStrikes)
	{
		string query = ConstructQuery(holeId, roundId, numberOfStrikes);
		HttpResponseMessage response = await _client.GetAsync("/holeScores" + query);
		string content = await response.Content.ReadAsStringAsync();
		if (!response.IsSuccessStatusCode)
		{
			throw new Exception(content);
		}
		ICollection<HoleScore> holeScores = JsonSerializer.Deserialize<ICollection<HoleScore>>(
			content, new JsonSerializerOptions{PropertyNameCaseInsensitive = true})!;
		return holeScores;
	}

	public async Task<HoleScoreBasicDto> GetByIdAsync(int id)
	{
		HttpResponseMessage response = await _client.GetAsync($"/holeScores/{id}");
		string content = await response.Content.ReadAsStringAsync();
		if (!response.IsSuccessStatusCode)
		{
			throw new Exception(content);
		}

		HoleScoreBasicDto holeScore = JsonSerializer.Deserialize<HoleScoreBasicDto>(content, new JsonSerializerOptions
		{
			PropertyNameCaseInsensitive = true
		})!;
		return holeScore;
	}

	private static string ConstructQuery(int holeId, int roundId, int numberOfStrikes)
	{
		string query = "";
		if (holeId != null)
		{
			query += string.IsNullOrEmpty(query) ? "?" : "&";
			query += $"holeId={holeId}";
		}
		if (roundId != null)
		{
			query += string.IsNullOrEmpty(query) ? "?" : "&";
			query += $"roundId={roundId}";
		}
		if (numberOfStrikes != null)
		{
			query += string.IsNullOrEmpty(query) ? "?" : "&";
			query += $"numberOfStrikes={numberOfStrikes}";
		}
		return query;
	}
}
