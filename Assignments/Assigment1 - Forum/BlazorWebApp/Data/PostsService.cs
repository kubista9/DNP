namespace BlazorWebApp.Data;

public class PostsService
{
	public Task<Post> GetPostAsync(string title)
	{
		return null;
	}

	public static async Post GetPostsAsync()
	{
		throw new NotImplementedException();
	}
}
