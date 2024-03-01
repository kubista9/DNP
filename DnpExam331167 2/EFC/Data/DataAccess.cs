using System.Text.Json;
using ConsoleApp.Entities;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace ConsoleApp.Data;

public class DataAccess
{
	private readonly AppContext _context;

	public DataAccess(AppContext context)
	{
		_context = context;
	}

	public async Task<Show> CreateShow(Show show)
	{
		Show showToCreate = new Show()
		{
			ShowId = show.ShowId,
			Title = show.Title,
			Year = show.Year,
			Genre = show.Genre
		};

		EntityEntry<Show> newPlayer = await _context.Shows.AddAsync(showToCreate);
		await _context.SaveChangesAsync();
		return newPlayer.Entity;
	}

	public async Task<Episode> AddEpisodeToShow(Episode episode, Show show)
	{
		Episode episodeToCreate = new Episode()
		{
			EpisodeId = episode.EpisodeId,
			Title = episode.Title,
			Runtime = episode.Runtime,
			SeasonId = episode.SeasonId,
			ShowId = show.ShowId
		};

		EntityEntry<Episode> newEpisode = await _context.Episodes.AddAsync(episodeToCreate);
		await _context.SaveChangesAsync();
		return newEpisode.Entity;
	}

	public async Task<IEnumerable<Show>> GetAll(string? filter1, int? filter2 )
	{
		string uri = "/shows";
		if (!string.IsNullOrEmpty(filter1))
		{
			uri += $"?shows={filter1}";
		}
		if (filter2 != null)
		{
			uri += $"?shows={filter2}";
		}
		if (!string.IsNullOrEmpty(filter1) && filter2 != null)
		{
			uri += $"?shows={filter1}/{filter2}";
		}

		HttpResponseMessage response = await _client.GetAsync(uri);
		string result = await response.Content.ReadAsStringAsync();
		if (!response.IsSuccessStatusCode)
		{
			throw new Exception(result);
		}

		IEnumerable<Show> shows = JsonSerializer.Deserialize<IEnumerable<Show>>(result, new JsonSerializerOptions
		{
			PropertyNameCaseInsensitive = true
		})!;
		return shows;
	}

}
