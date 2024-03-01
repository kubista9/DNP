using Domain.DTOs;
using Domain.models;

namespace Application.DaoInterfaces;

public interface IPostDao
{
	Task<Post> CreateAsync(Post post);
	Task<IEnumerable<Post>> GetAsync(SearchPostParametersDto searchParameters);
	Task UpdateAsync(Post post);
	Task<Post> GetByIdAsync(int id);
}
