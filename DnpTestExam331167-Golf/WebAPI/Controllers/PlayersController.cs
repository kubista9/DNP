using Application.LogicInterfaces;
using Microsoft.AspNetCore.Mvc;
using Shared.DTOs;
using Shared.Models;

namespace WebAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class PlayerController : ControllerBase
{
	private readonly IPlayerLogic _playerLogic;

	public PlayerController(IPlayerLogic playerLogic)
	{
		_playerLogic = playerLogic;
	}

	[HttpPost]
	public async Task<ActionResult<Player>> CreateAsync([FromBody]PlayerCreationDto dto)
	{
		try
		{
			Player player = await _playerLogic.CreateAsync(dto);
			return Created($"/players", player);
		}
		catch (Exception e)
		{
			Console.WriteLine(e.ToString());
			return StatusCode(500,  $"An error occurred while creating the player. {e}");
		}
	}

	[HttpGet]
	public async Task<ActionResult<IEnumerable<Player>>> GetAsync([FromQuery] string? name)
	{
		try
		{
			SearchPlayerParametersDto parameters = new(name);
			IEnumerable<Player> users = await _playerLogic.GetAsync(parameters);
			return Ok(users);
		}
		catch (Exception e)
		{
			Console.WriteLine(e);
			return StatusCode(500, e.Message);
		}
	}
}
