using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace cadastro_documento_api.Migrations
{
    public partial class relational_file_document : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Arquivo",
                table: "Documento");

            migrationBuilder.AddColumn<Guid>(
                name: "ArquivoId",
                table: "Documento",
                type: "char(36)",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                collation: "ascii_general_ci");

            migrationBuilder.UpdateData(
                table: "Processo",
                keyColumn: "Id",
                keyValue: 1,
                column: "CriadoEm",
                value: new DateTime(2022, 11, 11, 21, 55, 50, 724, DateTimeKind.Local).AddTicks(2966));

            migrationBuilder.UpdateData(
                table: "Processo",
                keyColumn: "Id",
                keyValue: 2,
                column: "CriadoEm",
                value: new DateTime(2022, 11, 11, 21, 55, 50, 724, DateTimeKind.Local).AddTicks(2979));

            migrationBuilder.UpdateData(
                table: "Processo",
                keyColumn: "Id",
                keyValue: 3,
                column: "CriadoEm",
                value: new DateTime(2022, 11, 11, 21, 55, 50, 724, DateTimeKind.Local).AddTicks(2981));

            migrationBuilder.UpdateData(
                table: "Processo",
                keyColumn: "Id",
                keyValue: 4,
                column: "CriadoEm",
                value: new DateTime(2022, 11, 11, 21, 55, 50, 724, DateTimeKind.Local).AddTicks(2982));

            migrationBuilder.CreateIndex(
                name: "IX_Documento_ArquivoId",
                table: "Documento",
                column: "ArquivoId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Documento_File_ArquivoId",
                table: "Documento",
                column: "ArquivoId",
                principalTable: "File",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Documento_File_ArquivoId",
                table: "Documento");

            migrationBuilder.DropIndex(
                name: "IX_Documento_ArquivoId",
                table: "Documento");

            migrationBuilder.DropColumn(
                name: "ArquivoId",
                table: "Documento");

            migrationBuilder.AddColumn<string>(
                name: "Arquivo",
                table: "Documento",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

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
    }
}
