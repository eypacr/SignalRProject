using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SignalR.DataAccessLayer.Migrations
{
    public partial class AddMenuTableSeedData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "MenuTables",
                columns: new[] { "MenuTableId", "Name", "Status" },
                values: new object[,]
                {
                    { 1, "Bahçe 01", false },
                    { 2, "Bahçe 02", false },
                    { 3, "Bahçe 03", false },
                    { 4, "Bahçe 04", false },
                    { 5, "Bahçe 05", false },
                    { 6, "Bahçe 06", false },
                    { 7, "Bahçe 07", false },
                    { 8, "Bahçe 08", false },
                    { 9, "Bahçe 09", false }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "MenuTables",
                keyColumn: "MenuTableId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "MenuTables",
                keyColumn: "MenuTableId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "MenuTables",
                keyColumn: "MenuTableId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "MenuTables",
                keyColumn: "MenuTableId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "MenuTables",
                keyColumn: "MenuTableId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "MenuTables",
                keyColumn: "MenuTableId",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "MenuTables",
                keyColumn: "MenuTableId",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "MenuTables",
                keyColumn: "MenuTableId",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "MenuTables",
                keyColumn: "MenuTableId",
                keyValue: 9);
        }
    }
}
