using Shared.DTOs;
using Shared.Models;

namespace Application.DaoInterfaces;

public interface IPlayerDao
{
	Task<Player> CreateAsync(Player player);
	Task<Player?> GetByNameAsync(string name);
	Task<IEnumerable<Player>> GetAsync(SearchPlayerParametersDto searchParameters);
	Task<Player?> GetByIdAsync(int id);
}
