namespace Shared.DTOs;

public class SearchPlayerParametersDto
{
	public string? Name { get;  }

	public SearchPlayerParametersDto(string? name)
	{
		Name = name;
	}
}
