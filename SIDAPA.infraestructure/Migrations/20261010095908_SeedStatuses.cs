using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SIDAPA.infraestructure.Migrations
{
    /// <inheritdoc />
    public partial class SeedStatuses : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                schema: "sidapa",
                table: "cat_estatus",
                columns: new[] { "id_estatus", "nombre", "orden" },
                values: new object[,]
                {
                    { (short)1, "Recibida", (short)1 },
                    { (short)2, "En revisión", (short)2 },
                    { (short)3, "En espera de documentos", (short)3 },
                    { (short)4, "Expediente completo", (short)4 },
                    { (short)5, "Factura leída", (short)5 },
                    { (short)6, "Factura confirmada", (short)6 },
                    { (short)7, "En clasificación", (short)7 },
                    { (short)8, "Borrador de pedimento", (short)8 },
                    { (short)9, "En glosa", (short)9 },
                    { (short)10, "Con anotaciones", (short)10 },
                    { (short)11, "Glosado (Vo.Bo.)", (short)11 },
                    { (short)12, "Archivo generado", (short)12 },
                    { (short)13, "Rechazado por validador", (short)13 },
                    { (short)14, "Validado", (short)14 },
                    { (short)15, "Cerrado", (short)15 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "sidapa",
                table: "cat_estatus",
                keyColumn: "id_estatus",
                keyValue: (short)1);

            migrationBuilder.DeleteData(
                schema: "sidapa",
                table: "cat_estatus",
                keyColumn: "id_estatus",
                keyValue: (short)2);

            migrationBuilder.DeleteData(
                schema: "sidapa",
                table: "cat_estatus",
                keyColumn: "id_estatus",
                keyValue: (short)3);

            migrationBuilder.DeleteData(
                schema: "sidapa",
                table: "cat_estatus",
                keyColumn: "id_estatus",
                keyValue: (short)4);

            migrationBuilder.DeleteData(
                schema: "sidapa",
                table: "cat_estatus",
                keyColumn: "id_estatus",
                keyValue: (short)5);

            migrationBuilder.DeleteData(
                schema: "sidapa",
                table: "cat_estatus",
                keyColumn: "id_estatus",
                keyValue: (short)6);

            migrationBuilder.DeleteData(
                schema: "sidapa",
                table: "cat_estatus",
                keyColumn: "id_estatus",
                keyValue: (short)7);

            migrationBuilder.DeleteData(
                schema: "sidapa",
                table: "cat_estatus",
                keyColumn: "id_estatus",
                keyValue: (short)8);

            migrationBuilder.DeleteData(
                schema: "sidapa",
                table: "cat_estatus",
                keyColumn: "id_estatus",
                keyValue: (short)9);

            migrationBuilder.DeleteData(
                schema: "sidapa",
                table: "cat_estatus",
                keyColumn: "id_estatus",
                keyValue: (short)10);

            migrationBuilder.DeleteData(
                schema: "sidapa",
                table: "cat_estatus",
                keyColumn: "id_estatus",
                keyValue: (short)11);

            migrationBuilder.DeleteData(
                schema: "sidapa",
                table: "cat_estatus",
                keyColumn: "id_estatus",
                keyValue: (short)12);

            migrationBuilder.DeleteData(
                schema: "sidapa",
                table: "cat_estatus",
                keyColumn: "id_estatus",
                keyValue: (short)13);

            migrationBuilder.DeleteData(
                schema: "sidapa",
                table: "cat_estatus",
                keyColumn: "id_estatus",
                keyValue: (short)14);

            migrationBuilder.DeleteData(
                schema: "sidapa",
                table: "cat_estatus",
                keyColumn: "id_estatus",
                keyValue: (short)15);
        }
    }
}
