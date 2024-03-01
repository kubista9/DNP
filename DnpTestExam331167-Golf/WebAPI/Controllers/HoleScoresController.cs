using Application.LogicInterfaces;
using Microsoft.AspNetCore.Mvc;
using Shared.DTOs;
using Shared.Models;

namespace WebAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class HoleScoresController : ControllerBase
{
	private readonly IHoleScoreLogic _holeScoreLogic;

	public HoleScoresController(IHoleScoreLogic holeScoreLogic)
	{
		_holeScoreLogic = holeScoreLogic;
	}

	[HttpPost]
	public async Task<ActionResult<HoleScore>> CreateAsync([FromBody]HoleScoreCreationDto dto)
	{
		try
		{
			HoleScore created = await _holeScoreLogic.CreateAsync(dto);
			return Created($"/holeScores/{created.HoleId}", created);
		}
		catch (Exception e)
		{
			Console.WriteLine(e);
			return StatusCode(500, e.Message);
		}
	}

	[HttpGet]
	public async Task<ActionResult<IEnumerable<HoleScore>>> GetAsync([FromQuery] int holeId, [FromQuery] int roundId,
		[FromQuery] int numberOfStrikes)
	{
		try
		{
			SearchHoleScoreParametersDto parameters = new(holeId, roundId, numberOfStrikes);
			var todos = await _holeScoreLogic.GetAsync(parameters);
			return Ok(todos);
		}
		catch (Exception e)
		{
			Console.WriteLine(e);
			return StatusCode(500, e.Message);
		}
	}

	[HttpGet("{id:int}")]
	public async Task<ActionResult<HoleScoreBasicDto>> GetById([FromRoute] int id)
	{
		try
		{
			HoleScoreBasicDto result = await _holeScoreLogic.GetByIdAsync(id);
			return Ok(result);
		}
		catch (Exception e)
		{
			Console.WriteLine(e);
			return StatusCode(500, e.Message);
		}
	}
}
