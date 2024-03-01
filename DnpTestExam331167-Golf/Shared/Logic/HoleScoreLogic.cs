using Application.DaoInterfaces;
using Application.LogicInterfaces;
using Shared.DTOs;
using Shared.Models;

namespace Application.Logic;

public class HoleScoreLogic : IHoleScoreLogic
{
	private readonly IHoleScoreDao holeScoreDao;
	private readonly IPlayerDao playerDao;

	public HoleScoreLogic(IHoleScoreDao holeScoreDao, IPlayerDao playerDao)
	{
		this.holeScoreDao = holeScoreDao;
		this.playerDao = playerDao;
	}

	public async Task<HoleScore> CreateAsync(HoleScoreCreationDto dto)
	{
		/*Player? player = await playerDao.GetByIdAsync(dto.PlayerId);
		if (player == null)
		{
			throw new Exception($"Player with id {dto.PlayerId} was not found.");
		}*/

		HoleScore holeScore = new HoleScore(dto.HoleId, dto.RoundId, dto.NumberOfStrikes);

		ValidateHoleScore(holeScore);
		HoleScore created = await holeScoreDao.CreateAsync(holeScore);
		return created;
	}

	public Task<IEnumerable<HoleScore>> GetAsync(SearchHoleScoreParametersDto searchParameters)
	{
		return holeScoreDao.GetAsync(searchParameters);
	}

	public async Task<HoleScoreBasicDto> GetByIdAsync(int id)
	{
		HoleScore? holeScore = await holeScoreDao.GetByIdAsync(id);
		if (holeScore == null)
		{
			throw new Exception($"Hole score with id {id} not found");
		}

		return new HoleScoreBasicDto(holeScore.HoleId, holeScore.RoundId, holeScore.NumberOfStrikes);
	}

	private void ValidateHoleScore(HoleScore dto){}
}
