using Microsoft.EntityFrameworkCore.Migrations;

namespace AgenciaViagemUp.Migrations
{
    public partial class InicialAgenciaVip : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ClienteModel",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Idade = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClienteModel", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DestinoModel",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Pais = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Estado = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Cidade = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DestinoModel", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PassagemModel",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClienteModelId = table.Column<int>(type: "int", nullable: false),
                    DestinoModelId = table.Column<int>(type: "int", nullable: false),
                    Preco = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PassagemModel", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PassagemModel_ClienteModel_ClienteModelId",
                        column: x => x.ClienteModelId,
                        principalTable: "ClienteModel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PassagemModel_DestinoModel_DestinoModelId",
                        column: x => x.DestinoModelId,
                        principalTable: "DestinoModel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PassagemModel_ClienteModelId",
                table: "PassagemModel",
                column: "ClienteModelId");

            migrationBuilder.CreateIndex(
                name: "IX_PassagemModel_DestinoModelId",
                table: "PassagemModel",
                column: "DestinoModelId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PassagemModel");

            migrationBuilder.DropTable(
                name: "ClienteModel");

            migrationBuilder.DropTable(
                name: "DestinoModel");
        }
    }
}
