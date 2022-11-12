using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace cadastro_documento_api.Migrations
{
    public partial class file_entity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "File",
                type: "char(36)",
                nullable: false,
                collation: "ascii_general_ci",
                oldClrType: typeof(int),
                oldType: "int")
                .OldAnnotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "Documento",
                type: "char(36)",
                nullable: false,
                collation: "ascii_general_ci",
                oldClrType: typeof(int),
                oldType: "int")
                .OldAnnotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn);

            migrationBuilder.UpdateData(
                table: "Processo",
                keyColumn: "Id",
                keyValue: 1,
                column: "CriadoEm",
                value: new DateTime(2022, 11, 11, 21, 26, 43, 469, DateTimeKind.Local).AddTicks(6837));

            migrationBuilder.UpdateData(
                table: "Processo",
                keyColumn: "Id",
                keyValue: 2,
                column: "CriadoEm",
                value: new DateTime(2022, 11, 11, 21, 26, 43, 469, DateTimeKind.Local).AddTicks(6849));

            migrationBuilder.UpdateData(
                table: "Processo",
                keyColumn: "Id",
                keyValue: 3,
                column: "CriadoEm",
                value: new DateTime(2022, 11, 11, 21, 26, 43, 469, DateTimeKind.Local).AddTicks(6851));

            migrationBuilder.UpdateData(
                table: "Processo",
                keyColumn: "Id",
                keyValue: 4,
                column: "CriadoEm",
                value: new DateTime(2022, 11, 11, 21, 26, 43, 469, DateTimeKind.Local).AddTicks(6852));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "File",
                type: "int",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "char(36)")
                .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn)
                .OldAnnotation("Relational:Collation", "ascii_general_ci");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "Documento",
                type: "int",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "char(36)")
                .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn)
                .OldAnnotation("Relational:Collation", "ascii_general_ci");

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
    }
}
