using Microsoft.AspNetCore.Mvc;
using ScreenSound.Banco;
using ScreenSound.Modelos;
using System.Data.SqlTypes;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<ScreenSoundContext>();

builder.Services.AddTransient<Dal<Artista>>();

builder.Services.AddTransient<Dal<Musica>>();

builder.Services.Configure<Microsoft.AspNetCore.Http.Json.JsonOptions>(options => options.SerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);

var app = builder.Build();

app.MapGet("/Artistas", ([FromServices] Dal<Artista> dal) =>
{
    return Results.Ok(dal.Listar());
});

app.MapGet("/Artistas/{nome}", ([FromServices] Dal < Artista > dal, string nome) =>
{
     var artista = dal.RecuperarPor(a => a.Nome.ToUpper().Equals(nome.ToUpper()));
    if (artista is null)
    {
        return Results.NotFound();
    }

    return Results.Ok(artista);
});

app.MapPost("/Artistas", ([FromServices] Dal < Artista > dal, [FromBody] Artista artista) =>
{
    dal.Adicionar(artista);
    return Results.Ok();
});

app.MapDelete("/Artistas/{id}", ([FromServices] Dal<Artista> dal, int id) =>
{
    var artista = dal.RecuperarPor(a => a.Id == id);

    if (artista is null)
    {
        return Results.NotFound();
    }

    dal.Delete(artista);
    return Results.NoContent();   
});

app.MapPut("/Artistas", ([FromServices] Dal < Artista > dal, [FromBody] Artista artista) =>
{
    var artistaAtualizar = dal.RecuperarPor(a => a.Id == artista.Id);
    if(artista is null)
    {
        return Results.NotFound();
    }

    artistaAtualizar.Nome = artista.Nome;
    artistaAtualizar.Bio = artista.Bio;
    artistaAtualizar.FotoPerfil = artista.FotoPerfil;

    dal.Atualizar(artistaAtualizar);
    return Results.Ok();
});

/////////////////// musicas ///////////////////

app.MapGet("/Musicas", ([FromServices] Dal<Musica> dal) =>
{
    return Results.Ok(dal.Listar());
});

app.MapGet("/Musicas/{nome}", ([FromServices] Dal<Musica> dal, string nome) =>
{
    var musica = dal.RecuperarPor(a => a.Nome.ToUpper().Equals(nome.ToUpper()));
    if (musica is null)
    {
        return Results.NotFound();
    }

    return Results.Ok(musica);
});

app.MapPost("/Musicas", ([FromServices] Dal<Musica> dal, [FromBody] Musica musica) =>
{
    dal.Adicionar(musica);
    return Results.Ok();
});

app.MapDelete("/musicas/{id}", ([FromServices] Dal<Musica> dal, int id) =>
{
    var musica = dal.RecuperarPor(a => a.Id == id);

    if (musica is null)
    {
        return Results.NotFound();
    }

    dal.Delete(musica);
    return Results.NoContent();
});

app.MapPut("/Musicas", ([FromServices] Dal<Musica> dal, [FromBody] Musica musica) =>
{
    var musicaAtualizar = dal.RecuperarPor(a => a.Id == musica.Id);
    if (musicaAtualizar is null)
    {
        return Results.NotFound();
    }

    musicaAtualizar.Nome = musica.Nome;
    musicaAtualizar.AnoLancamento = musica.AnoLancamento;
    musicaAtualizar.Artista = musica.Artista;

    dal.Atualizar(musicaAtualizar);
    return Results.Ok();
});

app.Run();
