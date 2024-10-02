
using backend.DataContext;
using backend.DTOs;
using backend.Model;
using backend.Repositories;
using backend.Repositories.InterfaceRepository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers().AddNewtonsoftJson();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IEntidadeRepository, EntidadeRepository>();

builder.Services.AddDbContext<AppDbContext>();
builder.Services.AddAutoMapper(typeof(EntidadeDTO));

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
