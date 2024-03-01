using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using HttpClients.ClientInterfaces;
using Shared.DTOs;
using Shared.Models;

namespace HttpClients.Implementations;

public class TodoHttpClient : ITodoService
{
	private readonly HttpClient _client;

	public TodoHttpClient(HttpClient client)
	{
		this._client = client;
	}

	public async Task CreateAsync(TodoCreationDto dto)
	{
		HttpResponseMessage response = await _client.PostAsJsonAsync("/todos",dto);
		if (!response.IsSuccessStatusCode)
		{
			string content = await response.Content.ReadAsStringAsync();
			throw new Exception(content);
		}
	}

	public async Task<ICollection<Todo>> GetAsync(string? userName, int? userId, bool? completedStatus, string? titleContains)
	{
		string query = ConstructQuery(userName, userId, completedStatus, titleContains);

		HttpResponseMessage response = await _client.GetAsync("/todos"+query);
		string content = await response.Content.ReadAsStringAsync();
		if (!response.IsSuccessStatusCode)
		{
			throw new Exception(content);
		}

		ICollection<Todo> todos = JsonSerializer.Deserialize<ICollection<Todo>>(content, new JsonSerializerOptions
		{
			PropertyNameCaseInsensitive = true
		})!;
		return todos;
	}

	private static string ConstructQuery(string? userName, int? userId, bool? completedStatus, string? titleContains)
	{
		string query = "";
		if (!string.IsNullOrEmpty(userName))
		{
			query += $"?username={userName}";
		}

		if (userId != null)
		{
			query += string.IsNullOrEmpty(query) ? "?" : "&";
			query += $"userid={userId}";
		}

		if (completedStatus != null)
		{
			query += string.IsNullOrEmpty(query) ? "?" : "&";
			query += $"completedstatus={completedStatus}";
		}

		if (!string.IsNullOrEmpty(titleContains))
		{
			query += string.IsNullOrEmpty(query) ? "?" : "&";
			query += $"titlecontains={titleContains}";
		}

		return query;
	}

	public async Task UpdateAsync(TodoUpdateDto dto)
	{
		string dtoAsJson = JsonSerializer.Serialize(dto);
		StringContent body = new StringContent(dtoAsJson, Encoding.UTF8, "application/json");

		HttpResponseMessage response = await _client.PatchAsync("/todos", body);
		if (!response.IsSuccessStatusCode)
		{
			string content = await response.Content.ReadAsStringAsync();
			throw new Exception(content);
		}
	}

	public async Task<TodoBasicDto> GetByIdAsync(int id)
	{
		HttpResponseMessage response = await _client.GetAsync($"/todos/{id}");
		string content = await response.Content.ReadAsStringAsync();
		if (!response.IsSuccessStatusCode)
		{
			throw new Exception(content);
		}

		TodoBasicDto todo = JsonSerializer.Deserialize<TodoBasicDto>(content,
			new JsonSerializerOptions
			{
				PropertyNameCaseInsensitive = true
			}
		)!;
		return todo;
	}

	public async Task DeleteAsync(int id)
	{
		HttpResponseMessage response = await _client.DeleteAsync($"Todos/{id}");
		if (!response.IsSuccessStatusCode)
		{
			string content = await response.Content.ReadAsStringAsync();
			throw new Exception(content);
		}
	}
}
