using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Space.Migrations
{
    public partial class Start : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SpaceObjects",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "TEXT", nullable: false),
                    TypeObj = table.Column<string>(type: "TEXT", nullable: true),
                    Name = table.Column<string>(type: "TEXT", nullable: true),
                    DistToSun = table.Column<float>(type: "REAL", nullable: false),
                    Weight = table.Column<float>(type: "REAL", nullable: false),
                    Diametr = table.Column<float>(type: "REAL", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SpaceObjects", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Asteroids",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Speed = table.Column<float>(type: "REAL", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Asteroids", x => x.id);
                    table.ForeignKey(
                        name: "FK_Asteroids_SpaceObjects_id",
                        column: x => x.id,
                        principalTable: "SpaceObjects",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BlackHole",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Density = table.Column<float>(type: "REAL", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BlackHole", x => x.id);
                    table.ForeignKey(
                        name: "FK_BlackHole_SpaceObjects_id",
                        column: x => x.id,
                        principalTable: "SpaceObjects",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Planets",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "TEXT", nullable: false),
                    TiltAngle = table.Column<float>(type: "REAL", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Planets", x => x.id);
                    table.ForeignKey(
                        name: "FK_Planets_SpaceObjects_id",
                        column: x => x.id,
                        principalTable: "SpaceObjects",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Stars",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "TEXT", nullable: false),
                    DegOfIllumination = table.Column<float>(type: "REAL", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Stars", x => x.id);
                    table.ForeignKey(
                        name: "FK_Stars_SpaceObjects_id",
                        column: x => x.id,
                        principalTable: "SpaceObjects",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Asteroids");

            migrationBuilder.DropTable(
                name: "BlackHole");

            migrationBuilder.DropTable(
                name: "Planets");

            migrationBuilder.DropTable(
                name: "Stars");

            migrationBuilder.DropTable(
                name: "SpaceObjects");
        }
    }
}
