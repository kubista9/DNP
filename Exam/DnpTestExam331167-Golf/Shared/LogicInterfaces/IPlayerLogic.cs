using Shared.DTOs;
using Shared.Models;

namespace Application.LogicInterfaces;

public interface IPlayerLogic
{
	Task<Player> CreateAsync(PlayerCreationDto playerToCreate);
	public Task<IEnumerable<Player>> GetAsync(SearchPlayerParametersDto searchParameters);
}
