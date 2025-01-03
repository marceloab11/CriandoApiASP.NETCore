using ScreenSound.Banco;
using ScreenSound.Modelos;

namespace ScreenSound.Menus;

internal class MenuMostrarArtistas : Menu
{
    public override void Executar(Dictionary<string, Artista> musicasRegistradas)
    {
        //base.Executar(musicasRegistradas);
        ExibirTituloDaOpcao("Exibindo todos os artistas registradas na nossa aplicação");

        ScreenSoundContext context = new ScreenSoundContext();
         Dal<Artista> artistaDal = new Dal<Artista>(context);
        var listaArtistas = artistaDal.Listar();
        foreach (Artista artista in listaArtistas)
        {
            Console.WriteLine(artista.ToString());
            Thread.Sleep(4000);
            Console.Clear();
        }

        Console.WriteLine("\nDigite uma tecla para voltar ao menu principal");
        Console.ReadKey();
        Console.Clear();
    }
}
