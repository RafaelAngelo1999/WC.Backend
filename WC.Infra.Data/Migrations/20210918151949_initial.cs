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
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Model = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SKU = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MediaAvaliacao = table.Column<float>(type: "real", nullable: false),
                    Create_At = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Update_At = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Produtos", x => x.Id);
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
                values: new object[] { new Guid("e6f0c0fa-4d41-42b8-9931-15f5f2c8eca8"), new DateTime(2021, 9, 18, 12, 19, 49, 140, DateTimeKind.Local).AddTicks(6247), "Rafael", null, new DateTime(2021, 9, 18, 12, 19, 49, 141, DateTimeKind.Local).AddTicks(9306), "rafael.angelo@gmail.com" });

            migrationBuilder.CreateIndex(
                name: "IX_ImagensProduto_ProdutoEntityId",
                table: "ImagensProduto",
                column: "ProdutoEntityId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ImagensProduto");

            migrationBuilder.DropTable(
                name: "Produtos");
        }
    }
}
