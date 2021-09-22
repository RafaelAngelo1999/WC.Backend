using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WC.Infra.Data.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Produtos",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Titulo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Descricao = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Model = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SKU = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EstoqueQuantidade = table.Column<float>(type: "real", nullable: false),
                    MediaAvaliacao = table.Column<int>(type: "int", nullable: false),
                    PrecoPromocional = table.Column<float>(type: "real", nullable: false),
                    Preco = table.Column<float>(type: "real", nullable: false),
                    Create_At = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Update_At = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Produtos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RotasSemente",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Url = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Pesquisa = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Create_At = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Update_At = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RotasSemente", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ImagensProduto",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Url = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Create_At = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Update_At = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ProdutoEntityId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ImagensProduto", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ImagensProduto_Produtos_ProdutoEntityId",
                        column: x => x.ProdutoEntityId,
                        principalTable: "Produtos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "RotasRamificada",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Url = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    WasScraping = table.Column<bool>(type: "bit", nullable: false),
                    Create_At = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Update_At = table.Column<DateTime>(type: "datetime2", nullable: false),
                    RotaSementeEntityId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RotasRamificada", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RotasRamificada_RotasSemente_RotaSementeEntityId",
                        column: x => x.RotaSementeEntityId,
                        principalTable: "RotasSemente",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "ImagensProduto",
                columns: new[] { "Id", "Create_At", "Name", "ProdutoEntityId", "Update_At", "Url" },
                values: new object[] { new Guid("d9f3de3b-54fc-42af-8b57-bb1390f6ac86"), new DateTime(2021, 9, 19, 9, 48, 34, 227, DateTimeKind.Local).AddTicks(9090), "Rafael", null, new DateTime(2021, 9, 19, 9, 48, 34, 228, DateTimeKind.Local).AddTicks(7788), "rafael.angelo@gmail.com" });

            migrationBuilder.CreateIndex(
                name: "IX_ImagensProduto_ProdutoEntityId",
                table: "ImagensProduto",
                column: "ProdutoEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_RotasRamificada_RotaSementeEntityId",
                table: "RotasRamificada",
                column: "RotaSementeEntityId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ImagensProduto");

            migrationBuilder.DropTable(
                name: "RotasRamificada");

            migrationBuilder.DropTable(
                name: "Produtos");

            migrationBuilder.DropTable(
                name: "RotasSemente");
        }
    }
}
