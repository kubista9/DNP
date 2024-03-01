using Shared.DTOs;
using Shared.Models;

namespace Application.LogicInterfaces;

public interface IHoleScoreLogic
{
	Task<HoleScore> CreateAsync(HoleScoreCreationDto dto);
	Task<IEnumerable<HoleScore>> GetAsync(SearchHoleScoreParametersDto searchParameters);
	Task<HoleScoreBasicDto> GetByIdAsync(int id);
}
