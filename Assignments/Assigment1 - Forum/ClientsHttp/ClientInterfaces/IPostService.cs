using Domain.DTOs;
using Domain.models;

namespace ClientsHttp.ClientInterfaces;

public interface IPostService
{
	Task CreateAsync(PostCreationDto dto);
	Task<ICollection<Post>> GetAsync(string? username, int? userId, string? titleContains);
	Task UpdateAsync(PostUpdateDto dto);
	Task<PostBasicDto> GetByIdAsync(int id);
}
