namespace Blazor.Services;

public interface IStatsService
{
	Task<double> GetHoleIdAvgStrikes(int holeId);
	Task<int> GetRoundIdStrikesByPlayer(int roundId, int playerId);
	Task<int> GetPlayerIdHandicap(int playerId);

}
