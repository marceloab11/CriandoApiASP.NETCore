using Microsoft.AspNetCore.Mvc;
using ScreenSoud.API.Endpoints.Requests;
using ScreenSoud.Shared.Modelos.Modelos;
using ScreenSound.Banco;
using ScreenSound.Modelos;

namespace ScreenSoud.API.Endpoints
{
    public static class GeneroExtensions
    {

        public static void AddEndpointsGenero(this WebApplication app)
        {
            app.MapGet("/Generos", ([FromServices] Dal<Genero> dal) =>
            {
                return Results.Ok(dal.Listar());
            });

            app.MapGet("/Generos/{nome}", ([FromServices] Dal<Genero> dal, string nome) =>
            {
                var genero = dal.RecuperarPor(a => a.Nome.ToUpper().Equals(nome.ToUpper()));
                if (genero is null)
                {
                    return Results.NotFound();
                }

                return Results.Ok(genero);
            });

            app.MapPost("/Generos", ([FromServices] Dal<Genero> dal, [FromBody] GeneroRequest GeneroRequest) =>
            {
                var genero = new Genero(GeneroRequest.Nome) { Descricao = GeneroRequest.descricao};
                dal.Adicionar(genero);
                return Results.Ok();
            });

            app.MapDelete("/Generos/{id}", ([FromServices] Dal<Genero> dal, int id) =>
            {
                var genero = dal.RecuperarPor(a => a.Id == id);

                if (genero is null)
                {
                    return Results.NotFound();
                }

                dal.Delete(genero);
                return Results.NoContent();
            });
        }
    }
}
