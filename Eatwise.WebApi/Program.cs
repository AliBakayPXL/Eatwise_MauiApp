using Eatwise.Infrastructure.Data;
using Eatwise.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Eatwise.Application.Interfaces;
using Eatwise.Application.Services;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Dependency Injection for DbContext
builder.Services.AddDbContext<EatwiseDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
//Repos DI
builder.Services.AddScoped<IIngredientRepository, IngredientRepository>();
builder.Services.AddScoped<IDishRepository, DishRepository>();
builder.Services.AddScoped<IEatenItemRepository, EatenItemRepository>();
//Services DI
builder.Services.AddScoped<ICatalogService, CatalogService>();
builder.Services.AddScoped<IDiaryService, DiaryService>();
builder.Services.AddScoped<IHistoryService, HistoryService>();

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
