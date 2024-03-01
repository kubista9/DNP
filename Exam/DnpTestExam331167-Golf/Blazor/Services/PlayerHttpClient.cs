using System.Text.Json;
using Shared.DTOs;
using Shared.Models;

namespace Blazor.Services;

public class PlayerHttpClient : IPlayerService
{
	private readonly HttpClient _client;

	public PlayerHttpClient(HttpClient client)
	{
		_client = client;
	}

	public async Task<Player> Create(PlayerCreationDto dto)
	{
		try
		{
			HttpResponseMessage response = await _client.PostAsJsonAsync("/players", dto);
			string result = await response.Content.ReadAsStringAsync();
			Player player = JsonSerializer.Deserialize<Player>(result, new JsonSerializerOptions
			{
				PropertyNameCaseInsensitive = true
			})!;
			return player;
		}
		catch (Exception e)
		{
			Console.WriteLine(e);
			throw new Exception($"Error creating player: {e}", e);
		}
	}

	public async Task<IEnumerable<Player>> GetPlayers(string? name = null)
	{
		string uri = "/players";
		if (!string.IsNullOrEmpty(name))
		{
			uri += $"?Name={name}";
		}
		HttpResponseMessage response = await _client.GetAsync(uri);
		string result = await response.Content.ReadAsStringAsync();
		if (!response.IsSuccessStatusCode)
		{
			throw new Exception(result);
		}

		IEnumerable<Player> players = JsonSerializer.Deserialize<IEnumerable<Player>>(
			result, new JsonSerializerOptions{PropertyNameCaseInsensitive = true })!;
		return players;
	}
}
