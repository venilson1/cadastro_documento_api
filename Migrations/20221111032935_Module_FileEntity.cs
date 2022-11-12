using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace cadastro_documento_api.Migrations
{
    public partial class Module_FileEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "File",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    FileBytes = table.Column<byte[]>(type: "longblob", nullable: false),
                    ContentType = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    FileName = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_File", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.UpdateData(
                table: "Processo",
                keyColumn: "Id",
                keyValue: 1,
                column: "CriadoEm",
                value: new DateTime(2022, 11, 11, 0, 29, 34, 966, DateTimeKind.Local).AddTicks(7643));

            migrationBuilder.UpdateData(
                table: "Processo",
                keyColumn: "Id",
                keyValue: 2,
                column: "CriadoEm",
                value: new DateTime(2022, 11, 11, 0, 29, 34, 966, DateTimeKind.Local).AddTicks(7656));

            migrationBuilder.UpdateData(
                table: "Processo",
                keyColumn: "Id",
                keyValue: 3,
                column: "CriadoEm",
                value: new DateTime(2022, 11, 11, 0, 29, 34, 966, DateTimeKind.Local).AddTicks(7659));

            migrationBuilder.UpdateData(
                table: "Processo",
                keyColumn: "Id",
                keyValue: 4,
                column: "CriadoEm",
                value: new DateTime(2022, 11, 11, 0, 29, 34, 966, DateTimeKind.Local).AddTicks(7660));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "File");

            migrationBuilder.UpdateData(
                table: "Processo",
                keyColumn: "Id",
                keyValue: 1,
                column: "CriadoEm",
                value: new DateTime(2022, 11, 10, 23, 49, 33, 136, DateTimeKind.Local).AddTicks(5292));

            migrationBuilder.UpdateData(
                table: "Processo",
                keyColumn: "Id",
                keyValue: 2,
                column: "CriadoEm",
                value: new DateTime(2022, 11, 10, 23, 49, 33, 136, DateTimeKind.Local).AddTicks(5312));

            migrationBuilder.UpdateData(
                table: "Processo",
                keyColumn: "Id",
                keyValue: 3,
                column: "CriadoEm",
                value: new DateTime(2022, 11, 10, 23, 49, 33, 136, DateTimeKind.Local).AddTicks(5314));

            migrationBuilder.UpdateData(
                table: "Processo",
                keyColumn: "Id",
                keyValue: 4,
                column: "CriadoEm",
                value: new DateTime(2022, 11, 10, 23, 49, 33, 136, DateTimeKind.Local).AddTicks(5315));
        }
    }
}
