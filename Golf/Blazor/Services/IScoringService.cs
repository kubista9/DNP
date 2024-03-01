using Shared;
using Shared.DTOs;
using Shared.Models;

namespace Blazor.Services;

public interface IScoringService
{
	Task CreateHoleScoreAsync(HoleScoreCreationDto dto);
}
