using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Estacionamento.Migrations
{
    /// <inheritdoc />
    public partial class Setima : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "ValorReferencia",
                columns: new[] { "Id", "DtIniVigencia", "VlrHrAdicional", "VlrHrInicial" },
                values: new object[] { 1, new DateTime(2015, 6, 1, 13, 45, 30, 0, DateTimeKind.Unspecified), 5m, 3m });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ValorReferencia",
                keyColumn: "Id",
                keyValue: 1);
        }
    }
}
