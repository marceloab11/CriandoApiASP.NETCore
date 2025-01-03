using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ScreenSound.Migrations
{
    /// <inheritdoc />
    public partial class PopilarTabelaMusica : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData("Musicas", new string[] {"Nome", "AnoLancamento"},
                new object[] {"Maquina do tempo",2020});

            migrationBuilder.InsertData("Musicas", new string[] { "Nome", "AnoLancamento" },
                new object[] { "X1", 2021});

            migrationBuilder.InsertData("Musicas", new string[] { "Nome", "AnoLancamento" },
                new object[] { "Lenda", 2024});

            migrationBuilder.InsertData("Musicas", new string[] { "Nome", "AnoLancamento" },
                new object[] { "Balão", 2019});
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM Musicas");
        }
    }
}
