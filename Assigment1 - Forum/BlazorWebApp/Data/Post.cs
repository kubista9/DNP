using Domain.models;

namespace BlazorWebApp.Data;

public class Post
{
	public User? Owner { get; set; }
	public string? Title { get; set; }
	public string? PostBody { get; set; }
}
