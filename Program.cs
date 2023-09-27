using Movie_Server.Database;
using Microsoft.EntityFrameworkCore;
using Movie_Server.Services;
using Movie_Server.Container;
using AutoMapper;
using Movie_Server.Helper;
using Serilog;
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

builder.Host.UseSerilog((context, configuration) => configuration.ReadFrom.Configuration(context.Configuration));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseSerilogRequestLogging();
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
