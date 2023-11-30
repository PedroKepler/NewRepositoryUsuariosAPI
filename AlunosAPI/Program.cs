using Usuarios.Context;
using Usuarios.Services;
using Usuarios.Services;
using Usuarios.Context;
using Usuarios.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

using System.Text;

using System.Text.Json.Serialization;





var builder = WebApplication.CreateBuilder(args);



builder.Services.AddControllers().AddJsonOptions(options =>

    options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);



builder.Services.AddDbContext<AppDbContext>(options =>

options.UseSqlServer(builder.Configuration.GetConnectionString("DevConnection")));

// Add services to the container.

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IUsuarioService, UsuarioService>();

var app = builder.Build();



app.UseCors(c =>

{

    c.WithOrigins("http://localhost:3000");

    c.AllowAnyHeader();

    c.AllowAnyMethod();

    c.AllowAnyOrigin();

});



// Configure the HTTP request pipeline.

if (app.Environment.IsDevelopment())

{





}



app.UseHttpsRedirection();

app.UseSwagger();

app.UseSwaggerUI();

app.MapControllers();

app.UseAuthentication();

app.UseAuthorization();



var summaries = new[]

{

    "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"

};



app.MapGet("/weatherforecast", () =>

{

    var forecast = Enumerable.Range(1, 5).Select(index =>

        new WeatherForecast

        (

            DateTime.Now.AddDays(index),

            Random.Shared.Next(-20, 55),

            summaries[Random.Shared.Next(summaries.Length)]

        ))

        .ToArray();

    return forecast;

})

.WithName("GetWeatherForecast");



app.Run();



internal record WeatherForecast(DateTime Date, int TemperatureC, string? Summary)

{

    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);

}