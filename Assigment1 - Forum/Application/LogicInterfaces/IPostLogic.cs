using Domain.DTOs;
using Domain.models;

namespace Application.LogicInterfaces;

public interface IPostLogic
{
	Task<Post> CreateAsync(PostCreationDto dto);
	Task<IEnumerable<Post>> GetAsync(SearchPostParametersDto searchParameters);
	Task UpdateAsync(PostUpdateDto dto);
	Task<PostBasicDto> GetByIdAsync(int id);
}
