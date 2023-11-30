using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UsuariosAPI.Migrations
{
    public partial class Inicial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "UsuariosAPI",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Idade = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsuariosAPI", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "UsuariosAPI",
                columns: new[] { "Id", "Email", "Idade", "Nome" },
                values: new object[] { 1, "MarcosDeOliveira@yahoo.com", 23, "Marcos de Oliveira" });

            migrationBuilder.InsertData(
                table: "UsuariosAPI",
                columns: new[] { "Id", "Email", "Idade", "Nome" },
                values: new object[] { 2, "MariaDeOliveira@yahoo.com", 23, "Maria de Oliveira" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UsuariosAPI");
        }
    }
}
