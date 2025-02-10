using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Estacionamento.Migrations
{
    /// <inheritdoc />
    public partial class Quarta : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Estadia",
                columns: new[] { "VeiculoId", "DtHrEntrada", "DtHrSaida", "VlrCalculado" },
                values: new object[,]
                {
                    { 1, new DateTime(2025, 2, 9, 21, 43, 10, 270, DateTimeKind.Local).AddTicks(3015), new DateTime(2025, 2, 9, 21, 43, 10, 271, DateTimeKind.Local).AddTicks(4372), 0m },
                    { 2, new DateTime(2025, 2, 9, 21, 43, 10, 271, DateTimeKind.Local).AddTicks(5929), new DateTime(2025, 2, 9, 21, 43, 10, 271, DateTimeKind.Local).AddTicks(5932), 0m }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Estadia",
                keyColumn: "VeiculoId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Estadia",
                keyColumn: "VeiculoId",
                keyValue: 2);
        }
    }
}
