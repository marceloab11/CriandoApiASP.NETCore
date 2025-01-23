using Microsoft.AspNetCore.Mvc;
using ScreenSoud.API.Endpoints;
using ScreenSoud.Shared.Modelos.Modelos;
using ScreenSound.Banco;
using ScreenSound.Modelos;
using System.Data.SqlTypes;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<ScreenSoundContext>();

builder.Services.AddTransient<Dal<Artista>>();

builder.Services.AddTransient<Dal<Musica>>();

builder.Services.AddTransient<Dal<Genero>>();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.Configure<Microsoft.AspNetCore.Http.Json.JsonOptions>(options => options.SerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);

var app = builder.Build(); 

app.AddEndpointsArtistas();
app.AddEndpointsMusicas();
app.AddEndpointsGenero();

app.UseSwagger();
app.UseSwaggerUI();

app.Run();