using Application.LogicInterfaces;
using Domain.DTOs;
using Domain.models;
using Microsoft.AspNetCore.Mvc;
using Shared.DTOs;

namespace WebAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class UserController : ControllerBase
{
	private readonly IUserLogic _userLogic;

	public UserController(IUserLogic userLogic)
	{
		_userLogic = userLogic;
	}

	[HttpPost]
	public async Task<ActionResult<User>> CreateAsync(UserCreationDto dto)
	{
		try
		{
			User user = await _userLogic.CreateAsync(dto);
			return Created($"/users/{user.Username}", user);
		}
		catch (Exception e)
		{
			Console.WriteLine(e);
			return StatusCode(500, e.Message);
		}
	}

	[HttpGet]
	public async Task<ActionResult<IEnumerable<User>>> GetAsync([FromQuery] string? username)
	{
		try
		{
			SearchUserParametersDto parameters = new(username);
			IEnumerable<User> users = await _userLogic.GetAsync(parameters);
			return Ok(users);
		}
		catch (Exception e)
		{
			Console.WriteLine(e);
			return StatusCode(500, e.Message);
		}
	}
}
