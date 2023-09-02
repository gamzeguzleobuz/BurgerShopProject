using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BurgerShopProject.Migrations
{
    /// <inheritdoc />
    public partial class SeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Extras",
                columns: new[] { "Id", "ExtraImageName", "ExtraName", "ExtraPrice", "Quantity" },
                values: new object[,]
                {
                    { 1, "extra-1.png", "Fries", 5m, 1 },
                    { 2, "extra-3.png", "Onion Ring", 10m, 1 },
                    { 3, "extra-5.png", "Cola", 15m, 1 },
                    { 4, "extra-7.png", "Ice-Tea", 5m, 1 },
                    { 5, "extra-2.png", "Curly Fries", 15m, 1 },
                    { 6, "extra-9.png", "Honey Mustard", 15m, 1 },
                    { 7, "extra-6.png", "Cola-Zero", 15m, 1 }
                });

            migrationBuilder.InsertData(
                table: "Menus",
                columns: new[] { "Id", "MenuImageName", "MenuName", "MenuPrice", "MenuSize", "Quantity" },
                values: new object[,]
                {
                    { 1, "bigKing.png", "Big King", 22m, 0, 1 },
                    { 2, "bigChicken.png", "Big Turkey", 12m, 0, 1 },
                    { 3, "burger (1).png", "Double Whopper", 34m, 0, 1 },
                    { 4, "burger (2).png", "King Chicken", 14m, 0, 1 },
                    { 5, "product-1.png", "Double Kofte Burger", 42m, 0, 1 },
                    { 6, "product-2.png", "Bacon Burger", 20m, 0, 1 },
                    { 7, "product-4.png", "Double King Vegan", 10m, 0, 1 },
                    { 8, "product-5.png", "Eggcellent Burger", 18m, 0, 1 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Extras",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Extras",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Extras",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Extras",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Extras",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Extras",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Extras",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 8);
        }
    }
}
