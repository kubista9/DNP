using Application.LogicInterfaces;
using Microsoft.AspNetCore.Mvc;
using Domain.DTOs;
using Domain.models;

namespace WebAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class PostController : ControllerBase
{
	private readonly IPostLogic _postLogic;

	public PostController(IPostLogic postLogic)
	{
		_postLogic = postLogic;
	}

	[HttpPost]
	public async Task<ActionResult<Post>> CreateAsync(PostCreationDto dto)
	{
		try
		{
			Post post = await _postLogic.CreateAsync(dto);
			return Created($"/posts/{post.Title}", post);
		}
		catch (Exception e)
		{
			Console.WriteLine(e);
			return StatusCode(500, e.Message);
		}
	}

	[HttpGet]
	public async Task<ActionResult<IEnumerable<Post>>> GetAsync([FromQuery] string? username, int? userId,
		string? titleContains)
	{
		try
		{
			SearchPostParametersDto parameters = new (username,  userId, titleContains);
			IEnumerable<Post> posts = await _postLogic.GetAsync(parameters);
			return Ok(posts);
		}
		catch (Exception e)
		{
			Console.WriteLine(e);
			return StatusCode(500, e.Message);
		}
	}
}
