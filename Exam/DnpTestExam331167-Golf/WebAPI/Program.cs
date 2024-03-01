using Application.DaoInterfaces;
using Application.Logic;
using Application.LogicInterfaces;
using EfcDataAccess;
using EfcDataAccess.DAOs;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IPlayerDao, PlayerEfcDao>();
builder.Services.AddScoped<IPlayerLogic, PlayerLogic>();

builder.Services.AddScoped<IHoleScoreDao, HoleScoreEfcDao>();
builder.Services.AddScoped<IHoleScoreLogic, HoleScoreLogic>();

builder.Services.AddDbContext<GolfContext>();

/*builder.Services.AddScoped(
	sp =>
		new HttpClient {
			BaseAddress = new Uri("https://localhost:7093")
		}
);*/

var app = builder.Build();
// Configure the HTTP request pipeline.

app.UseCors(x => x
	.AllowAnyMethod()
	.AllowAnyHeader()
	.SetIsOriginAllowed(origin => true) // allow any origin
	.AllowCredentials());

if (app.Environment.IsDevelopment())
{
	app.UseSwagger();
	app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
