using Movie_Server.Database;
using Microsoft.EntityFrameworkCore;
using Movie_Server.Services;
using Movie_Server.Container;
using AutoMapper;
using Movie_Server.Helper;
using Serilog;
using Microsoft.AspNetCore.RateLimiting;
using Movie_Server.Models;
using Movie_Server.Database.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
var builder = WebApplication.CreateBuilder(args);
// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(); 

// builder.Services.AddCors(p=>p.AddPolicy("corspolicy",build=> {
//     build.WithOrigins("https://domain.com").AllowAnyMethod().AllowAnyHeader();
// }));

builder.Services.AddCors(p=>p.AddDefaultPolicy(build=> {
    build.WithOrigins("*").AllowAnyMethod().AllowAnyHeader();
}));
// rate limit
builder.Services.AddRateLimiter(options => {
    options.AddFixedWindowLimiter(policyName:"fixedwindow",opt=> {
       opt.Window = TimeSpan.FromSeconds(10); 
       opt.PermitLimit = 100;
       opt.QueueLimit = 0;
       opt.QueueProcessingOrder = System.Threading.RateLimiting.QueueProcessingOrder.OldestFirst;
    });
});
builder.Services.AddTransient<IUserServices,UserServices> ();
builder.Services.AddTransient<IAuthorizeServices,AuthorizeServices> ();
builder.Services.AddTransient<ISupplierServices,SupplierServices> ();
builder.Services.AddTransient<IMovieServices,MovieServices> ();
builder.Services.AddTransient<IVoucherServices,VoucherServices> ();
builder.Services.AddTransient<IListMovieServices,ListMovieServices> ();

var connectionString = builder.Configuration.GetConnectionString("Movie_Server");
builder.Services.AddDbContext<MovieserverContext>(options => {
     options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
});

var automapper =  new MapperConfiguration(item => item.AddProfile(new AutoMapperHandler()));
IMapper mapper = automapper.CreateMapper();
builder.Services.AddSingleton(mapper);

builder.Services.AddAuthentication().AddJwtBearer(options => {
    options.TokenValidationParameters = new TokenValidationParameters {
       ValidateIssuerSigningKey = true,
       ValidateAudience = false,
       ValidateIssuer = false,
       IssuerSigningKey =  new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration.GetSection("Appsettings:Token").Value))
    };
});

builder.Host.UseSerilog((context, configuration) => configuration.ReadFrom.Configuration(context.Configuration));


 var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseRateLimiter();

app.UseSerilogRequestLogging();

app.UseCors();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
