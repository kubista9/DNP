using Shared.DTOs;
using Shared.Models;

namespace Blazor.Services;

public interface IPlayerService
{
	Task<Player> CreatePlayerAsync(PlayerCreationDto dto);
}
