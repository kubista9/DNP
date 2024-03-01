using Microsoft.AspNetCore.Mvc;
using WebAPI.Data;

namespace WebAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class StatisticsController : ControllerBase
{
	private readonly IDataAccess _dataAccess;

	public StatisticsController(IDataAccess dataAccess)
	{
		_dataAccess = dataAccess;
	}

	[HttpGet("AverageStrikes/{holeId}")]
	public async Task<ActionResult<double>> GetHoleIdAvgStrikes(int holeId)
	{
		try
		{
			var averageStrikes = await _dataAccess.GetAverageStrikesAsync(holeId);
			return Ok(averageStrikes);
		}
		catch (Exception e)
		{
			// Log the exception
			return StatusCode(500, e.Message);
		}
	}

	[HttpGet("RoundIdStrikesByPlayer/{roundId}/{playerId}")]
	public async Task<ActionResult<int>> GetRoundIdStrikesByPlayer(int roundId, int playerId)
	{
		try
		{
			var playerIdHandicap = await _dataAccess.GetRoundIdStrikesByPlayer(roundId, playerId);
			return Ok(playerIdHandicap);
		}
		catch (Exception e)
		{
			// Log the exception
			return StatusCode(500, e.Message);
		}
	}


	[HttpGet("PlayerHandicap/{playerId}")]
	public async Task<ActionResult<int>> GetPlayerIdHandicap(int playerId)
	{
		try
		{
			var playerIdHandicap = await _dataAccess.GetPlayerIdHandicap(playerId);
			return Ok(playerIdHandicap);
		}
		catch (Exception e)
		{
			// Log the exception
			return StatusCode(500, e.Message);
		}
	}
}
