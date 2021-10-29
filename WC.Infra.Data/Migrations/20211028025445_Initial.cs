using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WC.Infra.Data.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Ecommerces",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Create_At = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Update_At = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ecommerces", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Marcas",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Create_At = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Update_At = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Marcas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RotasSemente",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    EcommerceIdId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    MarcaIdId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Url = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Pesquisa = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Create_At = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Update_At = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RotasSemente", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RotasSemente_Ecommerces_EcommerceIdId",
                        column: x => x.EcommerceIdId,
                        principalTable: "Ecommerces",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_RotasSemente_Marcas_MarcaIdId",
                        column: x => x.MarcaIdId,
                        principalTable: "Marcas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "RotasRamificada",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RotaRamificadaIdId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    EcommerceIdId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    MarcaIdId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Url = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    WasScraping = table.Column<bool>(type: "bit", nullable: false),
                    Create_At = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Update_At = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RotasRamificada", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RotasRamificada_Ecommerces_EcommerceIdId",
                        column: x => x.EcommerceIdId,
                        principalTable: "Ecommerces",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_RotasRamificada_Marcas_MarcaIdId",
                        column: x => x.MarcaIdId,
                        principalTable: "Marcas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_RotasRamificada_RotasSemente_RotaRamificadaIdId",
                        column: x => x.RotaRamificadaIdId,
                        principalTable: "RotasSemente",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Produtos",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RotaRamificadaIdId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    EcommerceIdId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    MarcaIdId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Titulo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Descricao = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Categoria = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SKU = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Marca = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MediaAvaliacao = table.Column<float>(type: "real", nullable: false),
                    PrecoPromocional = table.Column<float>(type: "real", nullable: false),
                    Preco = table.Column<float>(type: "real", nullable: false),
                    Create_At = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Update_At = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Produtos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Produtos_Ecommerces_EcommerceIdId",
                        column: x => x.EcommerceIdId,
                        principalTable: "Ecommerces",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Produtos_Marcas_MarcaIdId",
                        column: x => x.MarcaIdId,
                        principalTable: "Marcas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Produtos_RotasRamificada_RotaRamificadaIdId",
                        column: x => x.RotaRamificadaIdId,
                        principalTable: "RotasRamificada",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
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

            migrationBuilder.InsertData(
                table: "ImagensProduto",
                columns: new[] { "Id", "Create_At", "Name", "ProdutoEntityId", "Update_At", "Url" },
                values: new object[] { new Guid("f98129f9-d1f5-4f97-997b-e446e2165ae8"), new DateTime(2021, 10, 27, 23, 54, 45, 554, DateTimeKind.Local).AddTicks(6336), "Rafael", null, new DateTime(2021, 10, 27, 23, 54, 45, 555, DateTimeKind.Local).AddTicks(7100), "rafael.angelo@gmail.com" });

            migrationBuilder.CreateIndex(
                name: "IX_ImagensProduto_ProdutoEntityId",
                table: "ImagensProduto",
                column: "ProdutoEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_Produtos_EcommerceIdId",
                table: "Produtos",
                column: "EcommerceIdId");

            migrationBuilder.CreateIndex(
                name: "IX_Produtos_MarcaIdId",
                table: "Produtos",
                column: "MarcaIdId");

            migrationBuilder.CreateIndex(
                name: "IX_Produtos_RotaRamificadaIdId",
                table: "Produtos",
                column: "RotaRamificadaIdId");

            migrationBuilder.CreateIndex(
                name: "IX_RotasRamificada_EcommerceIdId",
                table: "RotasRamificada",
                column: "EcommerceIdId");

            migrationBuilder.CreateIndex(
                name: "IX_RotasRamificada_MarcaIdId",
                table: "RotasRamificada",
                column: "MarcaIdId");

            migrationBuilder.CreateIndex(
                name: "IX_RotasRamificada_RotaRamificadaIdId",
                table: "RotasRamificada",
                column: "RotaRamificadaIdId");

            migrationBuilder.CreateIndex(
                name: "IX_RotasSemente_EcommerceIdId",
                table: "RotasSemente",
                column: "EcommerceIdId");

            migrationBuilder.CreateIndex(
                name: "IX_RotasSemente_MarcaIdId",
                table: "RotasSemente",
                column: "MarcaIdId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ImagensProduto");

            migrationBuilder.DropTable(
                name: "Produtos");

            migrationBuilder.DropTable(
                name: "RotasRamificada");

            migrationBuilder.DropTable(
                name: "RotasSemente");

            migrationBuilder.DropTable(
                name: "Ecommerces");

            migrationBuilder.DropTable(
                name: "Marcas");
        }
    }
}
