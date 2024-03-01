using Shared.DTOs;
using Shared.Models;

namespace Application.DaoInterfaces;

public interface IHoleScoreDao
{
	Task<HoleScore> CreateAsync(HoleScore holeScore);
	Task<IEnumerable<HoleScore>> GetAsync(SearchHoleScoreParametersDto searchParameters);
	Task<HoleScore?> GetByIdAsync(int todoId);
}
