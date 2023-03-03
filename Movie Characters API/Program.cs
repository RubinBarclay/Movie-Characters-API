using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Movie_Characters_API.Models;
using Movie_Characters_API.Services.CharacterDataAccess;
using Movie_Characters_API.Services.FranchiseDataAccess;
using Movie_Characters_API.Services.MovieDataAccess;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);

builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "v1",
        Title = " Movie-Characters-API",
        Description = "A movie themed REST API with full CRUD functionality built with ASP.NET and Entity Framework.",
       
    });
    options.IncludeXmlComments(xmlPath);
});


//AutoMapper
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

//SQLConnectionString
builder.Services.AddDbContext<MovieDbContext>(options =>
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("DefaultConnection")));
//Services for DataAccess
builder.Services.AddTransient<IFranchiseService, FranchiseService>();
builder.Services.AddTransient<IMovieService, MovieService>();
builder.Services.AddTransient<ICharacterService, CharacterService>();

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

