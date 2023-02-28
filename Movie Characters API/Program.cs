using Microsoft.EntityFrameworkCore;
using Movie_Characters_API.Models;
using Movie_Characters_API.Services.CharacterDataAccess;
using Movie_Characters_API.Services.FranchiseDataAccess;
using Movie_Characters_API.Services.MovieDataAccess;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//AutoMapper
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

//SQLConnectionString
builder.Services.AddDbContext<MovieDbContext>(options =>
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("DefaultConnection")));
//Services for DataAccess
builder.Services.AddTransient<ICharacterService, CharacterService>();
builder.Services.AddTransient<IMovieService, MovieService>();
builder.Services.AddTransient<IFranchiseService, FranchiseService>();

builder.Services.Configure<RouteOptions>(options => options.LowercaseUrls = true);


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

