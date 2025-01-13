using Microsoft.AspNetCore.Mvc;
using ScreenSound.Banco;
using ScreenSound.Modelos;

namespace ScreenSoud.API.Endpoints
{
    public static class ArtistasExtensions
    {
        public static void AddEndpointsArtistas(this WebApplication app)
        {
            app.MapGet("/Artistas", ([FromServices] Dal<Artista> dal) =>
            {
                return Results.Ok(dal.Listar());
            });

            app.MapGet("/Artistas/{nome}", ([FromServices] Dal<Artista> dal, string nome) =>
            {
                var artista = dal.RecuperarPor(a => a.Nome.ToUpper().Equals(nome.ToUpper()));
                if (artista is null)
                {
                    return Results.NotFound();
                }

                return Results.Ok(artista);
            });

            app.MapPost("/Artistas", ([FromServices] Dal<Artista> dal, [FromBody] Artista artista) =>
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

            app.MapPut("/Artistas", ([FromServices] Dal<Artista> dal, [FromBody] Artista artista) =>
            {
                var artistaAtualizar = dal.RecuperarPor(a => a.Id == artista.Id);
                if (artista is null)
                {
                    return Results.NotFound();
                }

                artistaAtualizar.Nome = artista.Nome;
                artistaAtualizar.Bio = artista.Bio;
                artistaAtualizar.FotoPerfil = artista.FotoPerfil;

                dal.Atualizar(artistaAtualizar);
                return Results.Ok();
            });
        }
    }
}
