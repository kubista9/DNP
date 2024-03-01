using Application.DaoInterfaces;
using Domain.DTOs;
using Domain.models;

namespace FileData.DAOs;

public class PostFileDao : IPostDao
{
	private readonly FileContext _context;

	public PostFileDao(FileContext context)
	{
		_context = context;
	}

	public Task<Post> CreateAsync(Post post)
	{
		int id = 1;
		if (_context.Posts.Any())
		{
			id = _context.Posts.Max(p => p.Id);
			id++;
		}

		post.Id = id;

		_context.Posts.Add(post);
		_context.SaveChanges();

		return Task.FromResult(post);
	}

	public Task<IEnumerable<Post>> GetAsync(SearchPostParametersDto searchParameters)
	{
		IEnumerable<Post> result = _context.Posts.AsEnumerable();

		if (!string.IsNullOrEmpty(searchParameters.Username))
		{
			result = _context.Posts.Where(post =>
				post.Owner.Username.Equals(searchParameters.Username, StringComparison.OrdinalIgnoreCase));
		}

		if (searchParameters.UserId != null)
		{
			result = result.Where(p => p.Owner.Id == searchParameters.UserId);
		}

		if (!string.IsNullOrEmpty(searchParameters.TitleContains))
		{
			result = result.Where(p =>
				p.Title.Contains(searchParameters.TitleContains, StringComparison.OrdinalIgnoreCase));
		}

		return Task.FromResult(result);
	}

	public Task<Post?> GetByIdAsync(int id)
	{
		Post? existing = _context.Posts.FirstOrDefault(p =>p.Id == id);
		return Task.FromResult(existing);
	}

	public Task UpdateAsync(Post toUpdate)
	{
		Post? existing = _context.Posts.FirstOrDefault(post => post.Id == toUpdate.Id);
		if (existing == null)
		{
			throw new Exception($"Post with id {toUpdate.Id} does not exist!");
		}

		_context.Posts.Remove(existing);
		_context.Posts.Add(toUpdate);

		_context.SaveChanges();

		return Task.CompletedTask;
	}
}
