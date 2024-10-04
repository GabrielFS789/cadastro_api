
using backend.DataContext;
using backend.DTOs;
using backend.Model;
using backend.Repositories;
using backend.Repositories.InterfaceRepository;
using backend.Services;
using backend.Services.Interface;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers().AddNewtonsoftJson();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IEntidadeRepository, EntidadeRepository>();
builder.Services.AddScoped<IUnitOfWorkRepository, UnitOfWorkRepository>();
builder.Services.AddScoped<ITokenService, TokenService>();


builder.Services.AddDbContext<AppDbContext>();
builder.Services.AddAutoMapper(typeof(EntidadeDTO));

builder.Services.AddAuthentication();
builder.Services.AddAuthentication("Bearer").AddJwtBearer();

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
