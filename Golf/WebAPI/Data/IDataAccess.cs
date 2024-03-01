using Shared.DTOs;
using Shared.Models;

namespace WebAPI.Data;

public interface IDataAccess
{
	Task<Player> CreatePlayerAsync(PlayerCreationDto dto);
	Task<HoleScore> CreateHoleScoreAsync(HoleScoreCreationDto dto);
	Task<double> GetAverageStrikesAsync(int holeId);
	Task<int> GetPlayerIdHandicap(int playerId);
	Task<int> GetRoundIdStrikesByPlayer(int roundId, int playerId);

}
