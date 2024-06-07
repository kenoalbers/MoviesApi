// Include movie namespace with the Movies prefix
using Movies = Kenoalbers.Movies.Api.Features.Movies;

var builder = WebApplication.CreateBuilder(args);

// Mock data
builder.Services.AddSingleton<Movies.Data.Mock>();
// "Data-query" layer
builder.Services.AddTransient<Movies.Repository.IRepository, Movies.Repository.Repository>();

// Api framework
builder.Services.AddFastEndpoints();
// OpenApi documentation
builder.Services.SwaggerDocument();

var app = builder.Build();

app.UseFastEndpoints();
app.UseSwaggerGen();

app.Run();