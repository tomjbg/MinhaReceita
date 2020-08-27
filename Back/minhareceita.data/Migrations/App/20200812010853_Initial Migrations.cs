using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace minhareceita.data.Migrations.App
{
    public partial class InitialMigrations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Perfil",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Username = table.Column<string>(type: "varchar(100)", nullable: false),
                    DataNascimento = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DataInscricao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Foto = table.Column<string>(type: "text", nullable: true),
                    UsuarioId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Perfil", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Receita",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Nome = table.Column<string>(type: "varchar(100)", nullable: false),
                    Avaliacao = table.Column<int>(nullable: false),
                    Video = table.Column<string>(type: "varchar(150)", nullable: true),
                    Curtidas = table.Column<int>(nullable: false),
                    TempoPreparoMinutos = table.Column<int>(nullable: false),
                    QtdPorcoes = table.Column<int>(nullable: false),
                    QtdFavoritados = table.Column<int>(nullable: false),
                    Imagens = table.Column<string>(type: "text", nullable: true),
                    Ingredientes = table.Column<string>(type: "text", nullable: true),
                    PerfilId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Receita", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Receita_Perfil_PerfilId",
                        column: x => x.PerfilId,
                        principalTable: "Perfil",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Categoria",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Descricao = table.Column<string>(type: "varchar(130)", nullable: false),
                    ReceitaId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categoria", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Categoria_Receita_ReceitaId",
                        column: x => x.ReceitaId,
                        principalTable: "Receita",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Comentario",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Descricao = table.Column<string>(type: "varchar(150)", nullable: true),
                    PerfilId = table.Column<int>(nullable: false),
                    ReceitaId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comentario", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Comentario_Perfil_PerfilId",
                        column: x => x.PerfilId,
                        principalTable: "Perfil",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Comentario_Receita_ReceitaId",
                        column: x => x.ReceitaId,
                        principalTable: "Receita",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ModoPreparoEtapa",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Etapa = table.Column<int>(nullable: false),
                    Descricao = table.Column<string>(type: "varchar(150)", nullable: false),
                    ReceitaId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ModoPreparoEtapa", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ModoPreparoEtapa_Receita_ReceitaId",
                        column: x => x.ReceitaId,
                        principalTable: "Receita",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Categoria_ReceitaId",
                table: "Categoria",
                column: "ReceitaId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Comentario_PerfilId",
                table: "Comentario",
                column: "PerfilId");

            migrationBuilder.CreateIndex(
                name: "IX_Comentario_ReceitaId",
                table: "Comentario",
                column: "ReceitaId");

            migrationBuilder.CreateIndex(
                name: "IX_ModoPreparoEtapa_ReceitaId",
                table: "ModoPreparoEtapa",
                column: "ReceitaId");

            migrationBuilder.CreateIndex(
                name: "IX_Receita_PerfilId",
                table: "Receita",
                column: "PerfilId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Categoria");

            migrationBuilder.DropTable(
                name: "Comentario");

            migrationBuilder.DropTable(
                name: "ModoPreparoEtapa");

            migrationBuilder.DropTable(
                name: "Receita");

            migrationBuilder.DropTable(
                name: "Perfil");
        }
    }
}
