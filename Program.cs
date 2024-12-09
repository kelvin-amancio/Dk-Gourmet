using DkGourmet.Data;
using DkGourmet.Services;
using DkGourmet.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen();

var dkCnn = builder.Configuration.GetConnectionString("DkCnn");

builder.Services.AddDbContext<AppDbContext>(options => options.UseMySql(dkCnn, ServerVersion.AutoDetect(dkCnn)));

builder.Services.AddTransient<IDkService, DkService>();

builder.WebHost.UseUrls("http://*:8080");

var app = builder.Build();

app.UseSwagger();

app.UseSwaggerUI();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();