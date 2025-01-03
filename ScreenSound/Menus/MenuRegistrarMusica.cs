using ScreenSound.Banco;
using ScreenSound.Modelos;

namespace ScreenSound.Menus;

internal class MenuRegistrarMusica : Menu
{
    public override void Executar(Dictionary<string, Artista> artistasRegistrados)
    {
        base.Executar(artistasRegistrados);
        ExibirTituloDaOpcao("Registro de músicas");
        Console.Write("Digite o artista cuja música deseja registrar: ");
        string nomeDoArtista = Console.ReadLine()!;

        ScreenSoundContext context = new ScreenSoundContext();
        Dal<Artista> artistaDal = new Dal<Artista>(context);
        var artistaRecuperado = artistaDal.RecuperarPor(a => a.Nome.Equals(nomeDoArtista));

        if (artistaRecuperado is not null)
        {
            Console.Write("Agora digite o título da música: ");
            string tituloDaMusica = Console.ReadLine()!;
            Console.Write("Agora digite o ano de lançamento da música: ");
            string anoLançamento = Console.ReadLine()!;
            artistaRecuperado.AdicionarMusica(new Musica(tituloDaMusica) {AnoLancamento = Convert.ToInt32(anoLançamento) });
            Console.WriteLine($"A música {tituloDaMusica} de {nomeDoArtista} foi registrada com sucesso!");
            artistaDal.Atualizar(artistaRecuperado);
            Thread.Sleep(4000);
            Console.Clear();
        }
        else
        {
            Console.WriteLine($"\nO artista {nomeDoArtista} não foi encontrado!");
            Console.WriteLine("Digite uma tecla para voltar ao menu principal");
            Console.ReadKey();
            Console.Clear();
        }
    }
}
