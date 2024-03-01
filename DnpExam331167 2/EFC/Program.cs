// See https://aka.ms/new-console-template for more information

using System.Security.Cryptography;
using ConsoleApp.Entities;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using AppContext = ConsoleApp.Data.AppContext;

Show GoT = new Show()
{
	ShowId = 1,
	Title = "Game of Thrones",
	Year = 2015,
	Genre = "Drama"
};

Show Office = new Show()
{
	ShowId = 2,
	Title = "Office",
	Year = 2014,
	Genre = "Comedy"
};

Episode episode1GoT = new Episode()
{
	EpisodeId = 1,
	Title = "drakarys",
	Runtime = 45,
	SeasonId = "SE0403"
};

Episode episode2Got = new Episode()
{
	EpisodeId = 2,
	Title = "Baratheon",
	Runtime = 54,
	SeasonId = "SE0407"
};

Episode episode1Office = new Episode()
{
	EpisodeId = 14,
	Title = "Dwight",
	Runtime = 33,
	SeasonId = "SE0303"
};

Episode episode2Office = new Episode()
{
	EpisodeId = 15,
	Title = "Michael",
	Runtime = 27,
	SeasonId = "SE0504"
};

Show newShow1 = await AddShow(GoT);
Show newSHow2 = await AddShow(Office);
Episode newEpisode1 = await AddEpisode(episode1GoT);
Episode newEpisode2 = await AddEpisode(episode2Got);
Episode newEpisode3 = await AddEpisode(episode1Office);
Episode newEpisode4 = await AddEpisode(episode2Office);

async Task<Show> AddShow(Show show)
{
	using AppContext context = new();
	EntityEntry<Show> entry = await context.Shows.AddAsync(show);
	await context.SaveChangesAsync();
	return entry.Entity;
}

async Task<Episode> AddEpisode(Episode episode)
{
	using AppContext context = new();
	EntityEntry<Episode> entry = await context.Episodes.AddAsync(episode);
	await context.SaveChangesAsync();
	return entry.Entity;
}
