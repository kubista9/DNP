using Microsoft.AspNetCore.Mvc;
using Shared.DTOs;
using Shared.Models;
using WebAPI.Data;

namespace WebAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class PlayersController : ControllerBase
{

	private readonly IDataAccess _dataAccess;

	public PlayersController(IDataAccess dataAccess)
	{
		_dataAccess = dataAccess;
	}

	[HttpPost]
	public async Task<ActionResult<Player>> CreatePlayerAsync(PlayerCreationDto dto)
	{
		try
		{
			Player player = await _dataAccess.CreatePlayerAsync(dto);
			/*Console.WriteLine("Player with name: " + player.Name + "successfully created");*/
			return Created($"/players/{player.PlayerId}", player);

		}
		catch (Exception e)
		{
			Console.WriteLine(e);
			return StatusCode(500, e.Message);
		}
	}

	[HttpPost]
	[Route("/holeScores")]
	public async Task<ActionResult<HoleScore>> CreateHoleScoreAsync(HoleScoreCreationDto dto)
	{
		try
		{
			HoleScore holeScore = await _dataAccess.CreateHoleScoreAsync(dto);
			Console.WriteLine("Hole score with hole score id: " + holeScore.HoleScoreId + "successfully created");
			return Created($"/holeScores/{holeScore.HoleScoreId}", holeScore);
		}
		catch (Exception e)
		{
			Console.WriteLine(e);
			return StatusCode(500, e.Message);
		}
	}
}
