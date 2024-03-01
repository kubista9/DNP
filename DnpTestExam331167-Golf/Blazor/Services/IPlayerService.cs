using Shared.DTOs;
using Shared.Models;

namespace Blazor.Services;

public interface IPlayerService
{
	Task<Player> Create(PlayerCreationDto dto);
	Task<IEnumerable<Player>> GetPlayers(string? name = null);
}
