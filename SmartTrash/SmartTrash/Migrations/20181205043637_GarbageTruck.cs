using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SmartTrash.Migrations
{
    public partial class GarbageTruck : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "WasteCollectionAreas",
                maxLength: 35,
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "GarbageTrucks",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    NumberPlate = table.Column<string>(nullable: false),
                    Model = table.Column<string>(nullable: true),
                    Volume = table.Column<decimal>(nullable: false),
                    MaintananceCostFactor = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GarbageTrucks", x => x.Id);
                    table.UniqueConstraint("AlternateKey_NumberPlate", x => x.NumberPlate);
                });

            migrationBuilder.InsertData(
                table: "GarbageTrucks",
                columns: new[] { "Id", "MaintananceCostFactor", "Model", "NumberPlate", "Volume" },
                values: new object[,]
                {
                    { 1, 15m, "Камаз-65115 КО-440В1", "B546OP10", 85500m },
                    { 2, 15m, "Камаз-65115 КО-440-5", "M182AK10", 49500m },
                    { 3, 13m, "Камаз-5325 КО-440В2", "O334XT10", 80750m },
                    { 4, 10m, "Маз-4380 КО-440-4М", "K937ET10", 30250m }
                });

            migrationBuilder.UpdateData(
                table: "WasteCollectionAreas",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Latitude", "Longitude" },
                values: new object[] { 61.79087f, 34.36776f });

            migrationBuilder.UpdateData(
                table: "WasteCollectionAreas",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Latitude", "Longitude" },
                values: new object[] { 61.78953f, 34.37f });

            migrationBuilder.UpdateData(
                table: "WasteCollectionAreas",
                keyColumn: "Id",
                keyValue: 3,
                column: "Longitude",
                value: 34.3732f);

            migrationBuilder.UpdateData(
                table: "WasteCollectionAreas",
                keyColumn: "Id",
                keyValue: 4,
                column: "Latitude",
                value: 61.8019f);

            migrationBuilder.UpdateData(
                table: "WasteCollectionAreas",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "Latitude", "Longitude" },
                values: new object[] { 61.80639f, 34.33181f });

            migrationBuilder.UpdateData(
                table: "WasteCollectionAreas",
                keyColumn: "Id",
                keyValue: 6,
                column: "Latitude",
                value: 61.80109f);

            migrationBuilder.UpdateData(
                table: "WasteCollectionAreas",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "Latitude", "Longitude" },
                values: new object[] { 61.79863f, 34.32402f });

            migrationBuilder.UpdateData(
                table: "WasteCollectionAreas",
                keyColumn: "Id",
                keyValue: 9,
                column: "Latitude",
                value: 61.7935f);

            migrationBuilder.UpdateData(
                table: "WasteCollectionAreas",
                keyColumn: "Id",
                keyValue: 10,
                column: "Latitude",
                value: 61.79022f);

            migrationBuilder.UpdateData(
                table: "WasteCollectionAreas",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "Latitude", "Longitude" },
                values: new object[] { 61.78534f, 34.34936f });

            migrationBuilder.UpdateData(
                table: "WasteCollectionAreas",
                keyColumn: "Id",
                keyValue: 14,
                columns: new[] { "Latitude", "Longitude" },
                values: new object[] { 61.78695f, 34.36066f });

            migrationBuilder.UpdateData(
                table: "WasteCollectionAreas",
                keyColumn: "Id",
                keyValue: 15,
                column: "Longitude",
                value: 34.36686f);

            migrationBuilder.UpdateData(
                table: "WasteCollectionAreas",
                keyColumn: "Id",
                keyValue: 16,
                columns: new[] { "Latitude", "Longitude" },
                values: new object[] { 61.78819f, 34.37271f });

            migrationBuilder.UpdateData(
                table: "WasteCollectionAreas",
                keyColumn: "Id",
                keyValue: 17,
                columns: new[] { "Latitude", "Longitude" },
                values: new object[] { 61.78965f, 34.37432f });

            migrationBuilder.UpdateData(
                table: "WasteCollectionAreas",
                keyColumn: "Id",
                keyValue: 18,
                column: "Longitude",
                value: 34.37862f);

            migrationBuilder.UpdateData(
                table: "WasteCollectionAreas",
                keyColumn: "Id",
                keyValue: 19,
                column: "Longitude",
                value: 34.37489f);

            migrationBuilder.UpdateData(
                table: "WasteCollectionAreas",
                keyColumn: "Id",
                keyValue: 20,
                column: "Latitude",
                value: 61.80373f);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GarbageTrucks");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "WasteCollectionAreas",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 35);

            migrationBuilder.UpdateData(
                table: "WasteCollectionAreas",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Latitude", "Longitude" },
                values: new object[] { 61.79087f, 34.36776f });

            migrationBuilder.UpdateData(
                table: "WasteCollectionAreas",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Latitude", "Longitude" },
                values: new object[] { 61.78953f, 34.37f });

            migrationBuilder.UpdateData(
                table: "WasteCollectionAreas",
                keyColumn: "Id",
                keyValue: 3,
                column: "Longitude",
                value: 34.3732f);

            migrationBuilder.UpdateData(
                table: "WasteCollectionAreas",
                keyColumn: "Id",
                keyValue: 4,
                column: "Latitude",
                value: 61.8019f);

            migrationBuilder.UpdateData(
                table: "WasteCollectionAreas",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "Latitude", "Longitude" },
                values: new object[] { 61.80639f, 34.33181f });

            migrationBuilder.UpdateData(
                table: "WasteCollectionAreas",
                keyColumn: "Id",
                keyValue: 6,
                column: "Latitude",
                value: 61.80109f);

            migrationBuilder.UpdateData(
                table: "WasteCollectionAreas",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "Latitude", "Longitude" },
                values: new object[] { 61.79863f, 34.32402f });

            migrationBuilder.UpdateData(
                table: "WasteCollectionAreas",
                keyColumn: "Id",
                keyValue: 9,
                column: "Latitude",
                value: 61.7935f);

            migrationBuilder.UpdateData(
                table: "WasteCollectionAreas",
                keyColumn: "Id",
                keyValue: 10,
                column: "Latitude",
                value: 61.79022f);

            migrationBuilder.UpdateData(
                table: "WasteCollectionAreas",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "Latitude", "Longitude" },
                values: new object[] { 61.78534f, 34.34936f });

            migrationBuilder.UpdateData(
                table: "WasteCollectionAreas",
                keyColumn: "Id",
                keyValue: 14,
                columns: new[] { "Latitude", "Longitude" },
                values: new object[] { 61.78695f, 34.36066f });

            migrationBuilder.UpdateData(
                table: "WasteCollectionAreas",
                keyColumn: "Id",
                keyValue: 15,
                column: "Longitude",
                value: 34.36686f);

            migrationBuilder.UpdateData(
                table: "WasteCollectionAreas",
                keyColumn: "Id",
                keyValue: 16,
                columns: new[] { "Latitude", "Longitude" },
                values: new object[] { 61.78819f, 34.37271f });

            migrationBuilder.UpdateData(
                table: "WasteCollectionAreas",
                keyColumn: "Id",
                keyValue: 17,
                columns: new[] { "Latitude", "Longitude" },
                values: new object[] { 61.78965f, 34.37432f });

            migrationBuilder.UpdateData(
                table: "WasteCollectionAreas",
                keyColumn: "Id",
                keyValue: 18,
                column: "Longitude",
                value: 34.37862f);

            migrationBuilder.UpdateData(
                table: "WasteCollectionAreas",
                keyColumn: "Id",
                keyValue: 19,
                column: "Longitude",
                value: 34.37489f);

            migrationBuilder.UpdateData(
                table: "WasteCollectionAreas",
                keyColumn: "Id",
                keyValue: 20,
                column: "Latitude",
                value: 61.80373f);
        }
    }
}
