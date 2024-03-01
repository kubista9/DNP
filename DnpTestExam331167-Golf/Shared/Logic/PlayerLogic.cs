using Application.DaoInterfaces;
using Application.LogicInterfaces;
using Shared.DTOs;
using Shared.Models;

namespace Application.Logic;

public class PlayerLogic : IPlayerLogic
{
	private readonly IPlayerDao _playerDao;

	public PlayerLogic(IPlayerDao playerDao)
	{
		_playerDao = playerDao;
	}

	public async Task<Player> CreateAsync(PlayerCreationDto dto)
	{
		Player? existing = await _playerDao.GetByNameAsync(dto.Name);
		if (existing != null)
			throw new Exception("Name already taken!");

		ValidateData(dto);
		Player toCreate = new Player
		{
			Name = dto.Name,
			Age = (int)dto.Age,
			Phone = dto.Phone,
			MembershipFee = dto.MembershipFee,
			MembershipType = dto.MembershipType
		};

		Player created = await _playerDao.CreateAsync(toCreate);

		return created;
	}

	public Task<IEnumerable<Player>> GetAsync(SearchPlayerParametersDto searchParameters)
	{
		return _playerDao.GetAsync(searchParameters);
	}

	private static void ValidateData(PlayerCreationDto userToCreate)
	{
	}
}
