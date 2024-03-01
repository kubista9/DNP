using System.Text.Json;
using Shared.Models;

namespace Blazor.Data;

public class StudentHttpClient : IStudentService
{
	private readonly HttpClient _client;

	public StudentHttpClient(HttpClient client)
	{
		_client = client;
	}

	public async Task CreateAsync(Student student)
	{
		HttpResponseMessage response = await _client.PostAsJsonAsync("/students", student);
		string result = await response.Content.ReadAsStringAsync();
		if (!response.IsSuccessStatusCode)
		{
			throw new Exception(result);
		}

		/*Student student = JsonSerializer.Deserialize<Student>(result, new JsonSerializerOptions
		{
			PropertyNameCaseInsensitive = true
		})!;
		return student;*/
	}

	public Task<ICollection<Student>> GetAllStudentsAsync()
	{
		throw new NotImplementedException();
	}

	public Task AddGradeToStudentAsync(GradeInCourse grade, int studentId)
	{
		throw new NotImplementedException();
	}


}
