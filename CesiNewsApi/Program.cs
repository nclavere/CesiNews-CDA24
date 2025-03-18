using CesiNewsDomain.Services;
using CesiNewsInfrastructure.Repositories;
using CesiNewsModel.Context;
using CesiNewsModel.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

var connectionString =
    builder.Configuration.GetConnectionString("DefaultConnection")
        ?? throw new InvalidOperationException("Connection string"
        + "'DefaultConnection' not found.");

builder.Services.AddDbContext<NewsDbContext>(options =>
    options.UseSqlServer(connectionString));

builder.Services.AddAuthentication(IdentityConstants.ApplicationScheme)
 .AddIdentityCookies();
builder.Services.AddAuthorizationBuilder();

builder.Services.AddIdentityCore<User>()
 .AddEntityFrameworkStores<NewsDbContext>()
 .AddApiEndpoints();

// Add services to the container.
builder.Services.AddScoped<SupportRepository>();
builder.Services.AddScoped<TexteRepository>();
builder.Services.AddScoped<VideoRepository>();
builder.Services.AddScoped<CategorieRepository>();
builder.Services.AddScoped<ArticleRepository>();
builder.Services.AddScoped<SupportService>();
builder.Services.AddScoped<CategorieService>();
builder.Services.AddScoped<ArticleService>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.MapIdentityApi<User>();

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
