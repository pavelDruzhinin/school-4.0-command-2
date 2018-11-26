using Microsoft.EntityFrameworkCore.Migrations;

namespace SmartTrash.Migrations
{
    public partial class SeedData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "WasteCollectionAreas",
                columns: new[] { "Id", "FilledVolume", "Latitude", "Longitude", "Name", "Volume" },
                values: new object[,]
                {
                    { 1, 136m, 61.79087f, 34.36776f, "Мусорная площадка 1", 1100m },
                    { 18, 613m, 61.79088f, 34.37862f, "Мусорная площадка 18", 1100m },
                    { 17, 178m, 61.78965f, 34.37432f, "Мусорная площадка 17", 1100m },
                    { 16, 365m, 61.78819f, 34.37271f, "Мусорная площадка 16", 1100m },
                    { 15, 103m, 61.78845f, 34.36686f, "Мусорная площадка 15", 1100m },
                    { 14, 267m, 61.78695f, 34.36066f, "Мусорная площадка 14", 1100m },
                    { 13, 36m, 61.78621f, 34.35516f, "Мусорная площадка 13", 1100m },
                    { 12, 432m, 61.78534f, 34.34936f, "Мусорная площадка 12", 1100m },
                    { 11, 321m, 61.78689f, 34.34767f, "Мусорная площадка 11", 1100m },
                    { 10, 237m, 61.79022f, 34.34173f, "Мусорная площадка 10", 1100m },
                    { 9, 434m, 61.7935f, 34.34128f, "Мусорная площадка 9", 1100m },
                    { 8, 74m, 61.7968f, 34.33304f, "Мусорная площадка 8", 1100m },
                    { 7, 34m, 61.79863f, 34.32402f, "Мусорная площадка 7", 1100m },
                    { 6, 4m, 61.80109f, 34.32463f, "Мусорная площадка 6", 1100m },
                    { 5, 814m, 61.80639f, 34.33181f, "Мусорная площадка 5", 1100m },
                    { 4, 134m, 61.8019f, 34.34448f, "Мусорная площадка 4", 1100m },
                    { 3, 748m, 61.79012f, 34.3732f, "Мусорная площадка 3", 1100m },
                    { 2, 541m, 61.78953f, 34.37f, "Мусорная площадка 2", 1100m },
                    { 19, 345m, 61.79287f, 34.37489f, "Мусорная площадка 19", 1100m },
                    { 20, 197m, 61.80373f, 34.34081f, "Мусорная площадка 20", 1100m }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "WasteCollectionAreas",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "WasteCollectionAreas",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "WasteCollectionAreas",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "WasteCollectionAreas",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "WasteCollectionAreas",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "WasteCollectionAreas",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "WasteCollectionAreas",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "WasteCollectionAreas",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "WasteCollectionAreas",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "WasteCollectionAreas",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "WasteCollectionAreas",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "WasteCollectionAreas",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "WasteCollectionAreas",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "WasteCollectionAreas",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "WasteCollectionAreas",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "WasteCollectionAreas",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "WasteCollectionAreas",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "WasteCollectionAreas",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "WasteCollectionAreas",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "WasteCollectionAreas",
                keyColumn: "Id",
                keyValue: 20);
        }
    }
}
