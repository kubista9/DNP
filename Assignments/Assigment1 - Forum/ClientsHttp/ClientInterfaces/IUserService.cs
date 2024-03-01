

using Domain.DTOs;
using Domain.models;

namespace ClientsHttp.ClientInterfaces;

public interface IUserService
{
	Task<User> Create(UserCreationDto dto);
	Task<IEnumerable<User>> GetUsersAsync(string? usernameContains = null);
}
