using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using ClientsHttp.ClientInterfaces;
using Domain.DTOs;
using Domain.models;

namespace ClientsHttp.Implementations;

public class PostHttpClient : IPostService
{
	private readonly HttpClient _client;

	public PostHttpClient(HttpClient client)
	{
		_client = client;
	}

	public async Task CreateAsync(PostCreationDto dto)
	{
		HttpResponseMessage response = await _client.PostAsJsonAsync("/posts",dto);
		if (!response.IsSuccessStatusCode)
		{
			string content = await response.Content.ReadAsStringAsync();
			throw new Exception(content);
		}
	}

	public async Task<ICollection<Post>> GetAsync(string? userName, int? userId, string? titleContains)
	{
		string query = ConstructQuery(userName, userId, titleContains);

		HttpResponseMessage response = await _client.GetAsync("/posts"+query);
		string content = await response.Content.ReadAsStringAsync();
		if (!response.IsSuccessStatusCode)
		{
			throw new Exception(content);
		}

		ICollection<Post> posts = JsonSerializer.Deserialize<ICollection<Post>>(content, new JsonSerializerOptions
		{
			PropertyNameCaseInsensitive = true
		})!;
		return posts;
	}

	private static string ConstructQuery(string? userName, int? userId, string? titleContains)
	{
		string query = "";
		if (!string.IsNullOrEmpty(userName))
		{
			query += $"?username={userName}";
		}

		if (userId != null)
		{
			query += string.IsNullOrEmpty(query) ? "?" : "&";
			query += $"userId={userId}";
		}

		if (!string.IsNullOrEmpty(titleContains))
		{
			query += string.IsNullOrEmpty(query) ? "?" : "&";
			query += $"titleContains={titleContains}";
		}

		return query;
	}

	public async Task UpdateAsync(PostUpdateDto dto)
	{
		string dtoAsJson = JsonSerializer.Serialize(dto);
		StringContent body = new StringContent(dtoAsJson, Encoding.UTF8, "application/json");

		HttpResponseMessage response = await _client.PatchAsync("/posts", body);
		if (!response.IsSuccessStatusCode)
		{
			string content = await response.Content.ReadAsStringAsync();
			throw new Exception(content);
		}
	}

	public async Task<PostBasicDto> GetByIdAsync(int id)
	{
		HttpResponseMessage response = await _client.GetAsync($"/posts/{id}");
		string content = await response.Content.ReadAsStringAsync();
		if (!response.IsSuccessStatusCode)
		{
			throw new Exception(content);
		}

		PostBasicDto todo = JsonSerializer.Deserialize<PostBasicDto>(content, new JsonSerializerOptions
		{
			PropertyNameCaseInsensitive = true
		})!;
		return todo;
	}


}
