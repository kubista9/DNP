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

	public async Task<Player> CreatePlayerAsync(PlayerCreationDto dto)
	{
		HttpResponseMessage response = await _client.PostAsJsonAsync("/players", dto);
		string result = await response.Content.ReadAsStringAsync();
		if (!response.IsSuccessStatusCode)
		{
			throw new Exception(result);
		}

		Player player = JsonSerializer.Deserialize<Player>(result, new JsonSerializerOptions
		{
			PropertyNameCaseInsensitive = true
		})!;
		return player;
	}
}
