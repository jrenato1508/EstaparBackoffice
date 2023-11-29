using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EstaparGarage.Data.Migrations
{
    public partial class formadepagamento : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "FormasPagamento",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Codigo = table.Column<string>(type: "Varchar(50)", nullable: false),
                    Descricao = table.Column<string>(type: "Varchar(50)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FormasPagamento", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Garangens",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Codigo = table.Column<string>(type: "Varchar(50)", nullable: false),
                    Nome = table.Column<string>(type: "Varchar(50)", nullable: false),
                    Preco_1aHora = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Preco_HorasExtra = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Preco_Mensalista = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Garangens", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Passagens",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NomeGaragem = table.Column<string>(type: "Varchar(50)", nullable: false),
                    CarroPlaca = table.Column<string>(type: "Varchar(50)", nullable: false),
                    CarroMarca = table.Column<string>(type: "Varchar(50)", nullable: false),
                    CarroModelo = table.Column<string>(type: "Varchar(50)", nullable: false),
                    DataHoraEntrada = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DataHoraSaida = table.Column<DateTime>(type: "datetime2", nullable: true),
                    FormaPagamento = table.Column<string>(type: "Varchar(50)", nullable: false),
                    PrecoTotal = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Passagens", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FormasPagamento");

            migrationBuilder.DropTable(
                name: "Garangens");

            migrationBuilder.DropTable(
                name: "Passagens");
        }
    }
}
