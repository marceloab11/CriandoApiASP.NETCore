using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ScreenSound.Migrations
{
    /// <inheritdoc />
    public partial class PopularTabela : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData("Artistas", new string[] {"Nome", "Bio", "FotoPerfil" },
            new object[] {"Matue",
                "Matheus Brasileiro Aguiar, mais conhecido como Matuê, nasceu em uma família de classe média de Fortaleza, no Ceará, em 11 de outubro de 1993.",
                "https://images.app.goo.gl/WSeYkx7shV2aHHqFA" });

            migrationBuilder.InsertData("Artistas", new string[] { "Nome", "Bio", "FotoPerfil" },
            new object[] {"MC Cabelinho",
                "Victor Hugo Oliveira do Nascimento (Rio de Janeiro, 28 de janeiro de 1996), mais conhecido como MC Cabelinho, é um cantor, compositor e ator brasileiro.",
                "https://images.app.goo.gl/zJA4pjBGAzYDvTnD6" });

            migrationBuilder.InsertData("Artistas", new string[] { "Nome", "Bio", "FotoPerfil" },
            new object[] {"Filipe Ret",
                "Filipe Cavaleiro de Macedo da Silva Faria, mais conhecido como Filipe Ret (Rio de Janeiro, 19 de junho de 1985), é um rapper, cantor, compositor",
                "https://images.app.goo.gl/tCDTjF42i5KQryYT8" });

            migrationBuilder.InsertData("Artistas", new string[] { "Nome", "Bio", "FotoPerfil" },
            new object[] {"Orochi",
                "Orochi começou a fazer rap profissionalmente em 2013 aos 14 anos. Sua primeira batalha no campo profissional foi no bairro, um campo de batalha em São Gonçalo, no Rio de Janeiro.",
                "https://images.app.goo.gl/78BbJJsEK5Yoxf1bA" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM Artistas");
        }
    }
}
