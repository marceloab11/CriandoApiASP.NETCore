using ScreenSoud.Shared.Modelos.Modelos;

namespace ScreenSoud.API.Endpoints.Requests
{
    public record class MusicaRequest(string nome, int artistaId, int anoLancamento, ICollection<GeneroRequest> Generos= null)
    {
    }
}
