using api.Authors;
using api.Core.Interfaces;
using api.Data;
using api.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<DataContext>(opt => {

	opt.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection"));

});

builder.Services.AddTransient<IAuthorRepository, AuthorRepository>();
builder.Services.AddTransient<IUnitOfWork, UnitOfWork>();
builder.Services.AddMediatR(typeof(CreateAuthor.Handler));

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

using var scope = app.Services.CreateScope();

var services = scope.ServiceProvider;
try
{
	var context = services.GetRequiredService<DataContext>();
	await context.Database.MigrateAsync();
}
catch (Exception e)
{
	var logger = services.GetRequiredService<ILogger<Program>>();
	logger.LogError(e, "Error migration");
}

app.Run();
