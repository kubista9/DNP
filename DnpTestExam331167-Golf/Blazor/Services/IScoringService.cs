using Shared.DTOs;
using Shared.Models;

namespace Blazor.Services;

public interface IScoringService
{
	Task CreateAsync(HoleScoreCreationDto dto);
	Task<ICollection<HoleScore>> GetAsync(int holeId, int roundId, int numberOfStrikes);
	Task<HoleScoreBasicDto> GetByIdAsync(int id);
}
