using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CoreEV4.Migrations
{
    public partial class firsA : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Hospitals",
                columns: table => new
                {
                    hId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    hName = table.Column<string>(nullable: true),
                    hAddress = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hospitals", x => x.hId);
                });

            migrationBuilder.CreateTable(
                name: "Patients",
                columns: table => new
                {
                    pId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    pName = table.Column<string>(maxLength: 50, nullable: false),
                    bGroup = table.Column<string>(nullable: true),
                    Dob = table.Column<DateTime>(nullable: false),
                    Address = table.Column<string>(nullable: false),
                    pImage = table.Column<string>(nullable: false),
                    pStatus = table.Column<string>(nullable: false),
                    hId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Patients", x => x.pId);
                    table.ForeignKey(
                        name: "FK_Patients_Hospitals_hId",
                        column: x => x.hId,
                        principalTable: "Hospitals",
                        principalColumn: "hId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Patients_hId",
                table: "Patients",
                column: "hId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Patients");

            migrationBuilder.DropTable(
                name: "Hospitals");
        }
    }
}
