using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Estacionamento.Migrations
{
    /// <inheritdoc />
    public partial class Quinta : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Estadia",
                keyColumn: "VeiculoId",
                keyValue: 1,
                columns: new[] { "DtHrEntrada", "DtHrSaida" },
                values: new object[] { new DateTime(2015, 6, 1, 13, 45, 30, 0, DateTimeKind.Unspecified), new DateTime(2015, 6, 1, 13, 45, 45, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Estadia",
                keyColumn: "VeiculoId",
                keyValue: 2,
                columns: new[] { "DtHrEntrada", "DtHrSaida" },
                values: new object[] { new DateTime(2015, 6, 1, 13, 46, 0, 0, DateTimeKind.Unspecified), new DateTime(2015, 6, 1, 13, 46, 15, 0, DateTimeKind.Unspecified) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Estadia",
                keyColumn: "VeiculoId",
                keyValue: 1,
                columns: new[] { "DtHrEntrada", "DtHrSaida" },
                values: new object[] { new DateTime(2025, 2, 9, 21, 43, 10, 270, DateTimeKind.Local).AddTicks(3015), new DateTime(2025, 2, 9, 21, 43, 10, 271, DateTimeKind.Local).AddTicks(4372) });

            migrationBuilder.UpdateData(
                table: "Estadia",
                keyColumn: "VeiculoId",
                keyValue: 2,
                columns: new[] { "DtHrEntrada", "DtHrSaida" },
                values: new object[] { new DateTime(2025, 2, 9, 21, 43, 10, 271, DateTimeKind.Local).AddTicks(5929), new DateTime(2025, 2, 9, 21, 43, 10, 271, DateTimeKind.Local).AddTicks(5932) });
        }
    }
}
