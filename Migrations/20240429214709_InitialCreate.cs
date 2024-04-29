using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace api_noticias.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categoria",
                columns: table => new
                {
                    CategoriaId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nom_Categoria = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categoria", x => x.CategoriaId);
                });

            migrationBuilder.CreateTable(
                name: "Noticia",
                columns: table => new
                {
                    NoticiaId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CategoriaId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Titulo = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Resumen = table.Column<string>(type: "nvarchar(1500)", maxLength: 1500, nullable: false),
                    Img = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    Contenido = table.Column<string>(type: "nvarchar(max)", maxLength: 8000, nullable: false),
                    Calificacion = table.Column<int>(type: "int", nullable: false, defaultValueSql: "0"),
                    Nom_Autor = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FechaCreacion = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "SYSDATETIME()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Noticia", x => x.NoticiaId);
                    table.ForeignKey(
                        name: "FK_Noticia_Categoria_CategoriaId",
                        column: x => x.CategoriaId,
                        principalTable: "Categoria",
                        principalColumn: "CategoriaId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Categoria",
                columns: new[] { "CategoriaId", "Nom_Categoria" },
                values: new object[,]
                {
                    { new Guid("fe2de405-c38e-4c90-ac52-da0540dfb401"), "Deportivas" },
                    { new Guid("fe2de405-c38e-4c90-ac52-da0540dfb402"), "Culturales" },
                    { new Guid("fe2de405-c38e-4c90-ac52-da0540dfb403"), "Sociales" },
                    { new Guid("fe2de405-c38e-4c90-ac52-da0540dfb404"), "De Farandula" },
                    { new Guid("fe2de405-c38e-4c90-ac52-da0540dfb405"), "Cientificas" },
                    { new Guid("fe2de405-c38e-4c90-ac52-da0540dfb406"), "Económicas" },
                    { new Guid("fe2de405-c38e-4c90-ac52-da0540dfb4ef"), "Política" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Noticia_CategoriaId",
                table: "Noticia",
                column: "CategoriaId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Noticia");

            migrationBuilder.DropTable(
                name: "Categoria");
        }
    }
}
