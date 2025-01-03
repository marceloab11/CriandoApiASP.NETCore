using ScreenSound.Banco;
using ScreenSound.Modelos;

namespace ScreenSound.Menus;

internal class MenuRegistrarArtista : Menu
{
    public override void Executar(Dictionary<string, Artista> artistasRegistrados)
    {
        ScreenSoundContext context = new ScreenSoundContext();
        Dal<Artista> artistaDal = new Dal<Artista>(context);
        /*base.Executar(artistasRegistrados)*/
        ;
        ExibirTituloDaOpcao("Registro dos Artistas");
        Console.Write("Digite o nome do artista que deseja registrar: ");
        string nomeDoArtista = Console.ReadLine()!;
        Console.Write("Digite a bio do artista que deseja registrar: ");
        string bioDoArtista = Console.ReadLine()!;
        Artista artista = new Artista(nomeDoArtista, bioDoArtista);
        artistaDal.Adicionar(artista);
        //artistasRegistrados.Add(nomeDoArtista, artista);
        Console.WriteLine($"O artista {nomeDoArtista} foi registrado com sucesso!");
        Thread.Sleep(4000);
        Console.Clear();
    }
}
