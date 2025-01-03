using ScreenSound.Banco;
using ScreenSound.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScreenSound.Menus
{
    internal class MenuMusicasPorano : Menu
    {
        public override void Executar(Dictionary<string, Artista> artistasRegistrados)
        {
            base.Executar(artistasRegistrados);
            ExibirTituloDaOpcao("Exibir Musicas por ano");
            Console.Write("Digite o ano que deseja buscar:");
            var anoMusica = Console.ReadLine();

            ScreenSoundContext context = new ScreenSoundContext();
            Dal<Musica> musicaDal = new Dal<Musica>(context);
            var listaMusica = musicaDal.ListarPor(a => a.AnoLancamento == Convert.ToInt32(anoMusica));

            if(listaMusica is not null )
            {
                Console.WriteLine($"\nMusicas do Ano {anoMusica}:");
                foreach (var musica in listaMusica)
                {
                    musica.ExibirFichaTecnica();
                }
                Console.WriteLine("\nDigite uma tecla para voltar ao menu principal");
                Console.ReadKey();
                Console.Clear();
            }
            else
            {
                Console.WriteLine($"\nO ano {anoMusica} não foi encontrada!");
                Console.WriteLine("Digite uma tecla para voltar ao menu principal");
                Console.ReadKey();
                Console.Clear();
            }
        }
    }
}
