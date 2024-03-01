using Domain.models;
using Shared.DTOs;

namespace Application.DaoInterfaces;

public interface IUserDao
{
	Task<User> CreateAsync(User user);
	Task<User?> GetByUsernameAsync(string userName);
	Task<IEnumerable<User>> GetAsync(SearchUserParametersDto searchParameters);
	Task<User?> GetByIdAsync(int dtoOwnerId);
}
