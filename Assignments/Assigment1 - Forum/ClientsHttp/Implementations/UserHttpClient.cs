using System.Net.Http.Json;
using System.Text.Json;
using ClientsHttp.ClientInterfaces;
using Domain.DTOs;
using Domain.models;

namespace ClientsHttp.Implementations;

public class UserHttpClient : IUserService
{
	private readonly HttpClient _client;

	public UserHttpClient(HttpClient client)
	{
		_client = client;
	}

	public async Task<User> Create(UserCreationDto dto)
	{
		HttpResponseMessage response = await _client.PostAsJsonAsync("/users", dto);
		string result = await response.Content.ReadAsStringAsync();
		if (!response.IsSuccessStatusCode)
		{
			throw new Exception(result);
		}

		User user = JsonSerializer.Deserialize<User>(result, new JsonSerializerOptions
		{
			PropertyNameCaseInsensitive = true
		})!;
		return user;
	}


	public async Task<IEnumerable<User>> GetUsersAsync(string? usernameContains = null)
	{
		string uri = "/users";
		if (!string.IsNullOrEmpty(usernameContains))
		{
			uri += $"?username={usernameContains}";
		}

		HttpResponseMessage response = await _client.GetAsync(uri);
		string result = await response.Content.ReadAsStringAsync();
		if (!response.IsSuccessStatusCode)
		{
			throw new Exception(result);
		}

		IEnumerable<User> users = JsonSerializer.Deserialize<IEnumerable<User>>(result, new JsonSerializerOptions
		{
			PropertyNameCaseInsensitive = true
		})!;
		return users;
	}

}
