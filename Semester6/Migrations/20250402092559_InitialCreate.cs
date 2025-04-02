using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Semester6.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Docenten",
                columns: table => new
                {
                    DocentId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naam = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Docenten", x => x.DocentId);
                });

            migrationBuilder.CreateTable(
                name: "Studenten",
                columns: table => new
                {
                    StudentId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naam = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Studenten", x => x.StudentId);
                });

            migrationBuilder.CreateTable(
                name: "Vakken",
                columns: table => new
                {
                    VakId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naam = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DocentId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vakken", x => x.VakId);
                    table.ForeignKey(
                        name: "FK_Vakken_Docenten_DocentId",
                        column: x => x.DocentId,
                        principalTable: "Docenten",
                        principalColumn: "DocentId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Toetsen",
                columns: table => new
                {
                    ToetsId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naam = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Datum = table.Column<DateTime>(type: "datetime2", nullable: false),
                    VakId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Toetsen", x => x.ToetsId);
                    table.ForeignKey(
                        name: "FK_Toetsen_Vakken_VakId",
                        column: x => x.VakId,
                        principalTable: "Vakken",
                        principalColumn: "VakId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ToetsResultaten",
                columns: table => new
                {
                    ToetsResultaatId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StudentId = table.Column<int>(type: "int", nullable: false),
                    ToetsId = table.Column<int>(type: "int", nullable: false),
                    IsHerkansing = table.Column<bool>(type: "bit", nullable: false),
                    Cijfer = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ToetsResultaten", x => x.ToetsResultaatId);
                    table.ForeignKey(
                        name: "FK_ToetsResultaten_Studenten_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Studenten",
                        principalColumn: "StudentId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ToetsResultaten_Toetsen_ToetsId",
                        column: x => x.ToetsId,
                        principalTable: "Toetsen",
                        principalColumn: "ToetsId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Toetsen_VakId",
                table: "Toetsen",
                column: "VakId");

            migrationBuilder.CreateIndex(
                name: "IX_ToetsResultaten_StudentId_ToetsId_IsHerkansing",
                table: "ToetsResultaten",
                columns: new[] { "StudentId", "ToetsId", "IsHerkansing" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ToetsResultaten_ToetsId",
                table: "ToetsResultaten",
                column: "ToetsId");

            migrationBuilder.CreateIndex(
                name: "IX_Vakken_DocentId",
                table: "Vakken",
                column: "DocentId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ToetsResultaten");

            migrationBuilder.DropTable(
                name: "Studenten");

            migrationBuilder.DropTable(
                name: "Toetsen");

            migrationBuilder.DropTable(
                name: "Vakken");

            migrationBuilder.DropTable(
                name: "Docenten");
        }
    }
}
