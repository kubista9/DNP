using Domain.DTOs;
using Domain.models;
using Shared.DTOs;

namespace Application.LogicInterfaces;

public interface IUserLogic
{
	Task<User> CreateAsync(UserCreationDto dto);
	Task<IEnumerable<User>> GetAsync(SearchUserParametersDto parameters);
}
