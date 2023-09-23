using Movie_Server.Repos;
using Microsoft.EntityFrameworkCore;
using Movie_Server.Services;
using Movie_Server.Container;
using AutoMapper;
using Movie_Server.Helper;
var builder = WebApplication.CreateBuilder(args);
// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
// connection string used for the database
builder.Services.AddTransient<IUserServices,UserServices> ();
var connectionString = builder.Configuration.GetConnectionString("Movie_Server");
builder.Services.AddDbContext<MovieserverContext>(options => {
     options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
});

var automapper =  new MapperConfiguration(item => item.AddProfile(new AutoMapperHandler()));
IMapper mapper = automapper.CreateMapper();
builder.Services.AddSingleton(mapper);

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
