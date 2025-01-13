using Microsoft.AspNetCore.Mvc;
using ScreenSound.Banco;
using ScreenSound.Modelos;

namespace ScreenSoud.API.Endpoints
{
    public static class MusicaExtensions
    {
        public static void AddEndpointsMusicas(this WebApplication app)
        {
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
        }
    }
}
