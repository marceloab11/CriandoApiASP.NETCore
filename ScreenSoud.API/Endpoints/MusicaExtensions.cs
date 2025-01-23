using Microsoft.AspNetCore.Mvc;
using ScreenSoud.API.Endpoints.Requests;
using ScreenSoud.API.Endpoints.Response;
using ScreenSoud.Shared.Modelos.Modelos;
using ScreenSound.Banco;
using ScreenSound.Modelos;

namespace ScreenSoud.API.Endpoints
{
    public static class MusicaExtensions
    {
        private static ICollection<MusicaResponse> EntityListToResponseList(IEnumerable<Musica> musicaList)
        {
            return musicaList.Select(a => EntityToResponse(a)).ToList();
        }

        private static MusicaResponse EntityToResponse(Musica musica)
        {
            return new MusicaResponse(musica.Id, musica.Nome!, musica.Artista!.Id, musica.Artista.Nome);
        }
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

            app.MapPost("/Musicas", ([FromServices] Dal<Musica> dal,
                [FromServices] Dal<Genero> dalGenero, [FromBody]
               MusicaRequest musicaRequest) =>
            {
                Musica musica = new Musica(musicaRequest.nome)
                {
                    AnoLancamento = musicaRequest.anoLancamento,
                    ArtistaId = musicaRequest.artistaId,
                    Generos = musicaRequest.Generos is not null?
                    GeneroRequestConverter(musicaRequest.Generos, dalGenero):
                    new List<Genero>()
                };
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

        private static ICollection<Genero> GeneroRequestConverter
            (ICollection<GeneroRequest> generos, Dal<Genero>
            dalgenero)
        {
            var listaDeGeneros = new List<Genero> ();
            foreach (var item in generos)
            {
                var entity = RequestToEntity(item);
                var genero = dalgenero.RecuperarPor
                    (g => g.Nome.ToUpper().Equals(item.Nome.ToUpper()));
                if (genero is not null)
                {
                    listaDeGeneros.Add(genero);
                } 
                else
                {
                    listaDeGeneros.Add(entity);
                } 
              
            }

            return listaDeGeneros;
        }

        private static Genero RequestToEntity(GeneroRequest genero)
        {
            return new Genero(genero.Nome) { Descricao = genero.descricao, };
        }
    }
}
