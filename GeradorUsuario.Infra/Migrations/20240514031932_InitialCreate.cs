using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace GeradorUsuario.Infra.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    Uuid = table.Column<Guid>(type: "uuid", nullable: false),
                    NomeUsuario = table.Column<string>(type: "text", nullable: false),
                    Email = table.Column<string>(type: "text", nullable: false),
                    Senha = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.Uuid);
                });

            migrationBuilder.InsertData(
                table: "Usuarios",
                columns: new[] { "Uuid", "Email", "NomeUsuario", "Senha" },
                values: new object[,]
                {
                    { new Guid("29bd07ff-c2f1-4cf5-ace6-9641a1e875e2"), "jose@email.com", "José", "1234" },
                    { new Guid("501ab281-194b-458e-af85-1f50d56e0e4b"), "juliana@email.com", "Juliana", "5678" },
                    { new Guid("57e3bf36-56cd-4fff-8a91-e1b08b461444"), "Ana@email.com", "Ana", "5678" },
                    { new Guid("84eb80ad-ca7f-4443-80f7-a44a7127fc34"), "pedro@email.com", "Pedro", "1234" },
                    { new Guid("86a71477-4469-44b2-bbe7-e0bde16ea3d8"), "joao@email.com", "João", "1234" },
                    { new Guid("8a7007d0-ea74-4e26-a20d-eb90f52763a9"), "lucas@email.com", "Lucas", "1234" },
                    { new Guid("9102494e-eae0-4bf7-aada-f1251ab38296"), "carlos@email.com", "Carlos", "1234" },
                    { new Guid("a18dd8ce-b0d3-49b3-ba7e-f9da81a46ed8"), "mariana@email.com", "Mariana", "5678" },
                    { new Guid("aaed7b82-5b79-4ed8-82e4-d0e790e791cd"), "paula@email.com", "Paula", "5678" },
                    { new Guid("d311130e-5b3c-4325-b3a0-0cb7bcba916c"), "maria@email.com", "Maria", "5678" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Usuarios");
        }
    }
}
