using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace cadastro_documento_api.Migrations
{
    public partial class update_type_field_titulo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Titulo",
                table: "Documento",
                type: "longtext",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.UpdateData(
                table: "Processo",
                keyColumn: "Id",
                keyValue: 1,
                column: "CriadoEm",
                value: new DateTime(2022, 11, 10, 19, 16, 55, 977, DateTimeKind.Local).AddTicks(5686));

            migrationBuilder.UpdateData(
                table: "Processo",
                keyColumn: "Id",
                keyValue: 2,
                column: "CriadoEm",
                value: new DateTime(2022, 11, 10, 19, 16, 55, 977, DateTimeKind.Local).AddTicks(5698));

            migrationBuilder.UpdateData(
                table: "Processo",
                keyColumn: "Id",
                keyValue: 3,
                column: "CriadoEm",
                value: new DateTime(2022, 11, 10, 19, 16, 55, 977, DateTimeKind.Local).AddTicks(5699));

            migrationBuilder.UpdateData(
                table: "Processo",
                keyColumn: "Id",
                keyValue: 4,
                column: "CriadoEm",
                value: new DateTime(2022, 11, 10, 19, 16, 55, 977, DateTimeKind.Local).AddTicks(5700));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Titulo",
                table: "Documento",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.UpdateData(
                table: "Processo",
                keyColumn: "Id",
                keyValue: 1,
                column: "CriadoEm",
                value: new DateTime(2022, 11, 10, 18, 40, 11, 727, DateTimeKind.Local).AddTicks(7292));

            migrationBuilder.UpdateData(
                table: "Processo",
                keyColumn: "Id",
                keyValue: 2,
                column: "CriadoEm",
                value: new DateTime(2022, 11, 10, 18, 40, 11, 727, DateTimeKind.Local).AddTicks(7305));

            migrationBuilder.UpdateData(
                table: "Processo",
                keyColumn: "Id",
                keyValue: 3,
                column: "CriadoEm",
                value: new DateTime(2022, 11, 10, 18, 40, 11, 727, DateTimeKind.Local).AddTicks(7307));

            migrationBuilder.UpdateData(
                table: "Processo",
                keyColumn: "Id",
                keyValue: 4,
                column: "CriadoEm",
                value: new DateTime(2022, 11, 10, 18, 40, 11, 727, DateTimeKind.Local).AddTicks(7307));
        }
    }
}
