using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Africuisine.Infrastructure.Migrations.AfricuisineDb
{
    /// <inheritdoc />
    public partial class InitializeAfricuisineBaseData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "IngredientCategories",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Creation = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LUserUpdate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SeqNo = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IngredientCategories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Measurements",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Abbreviation = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Creation = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LUserUpdate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SeqNo = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Measurements", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "IngredientCategories",
                columns: new[] { "Id", "Creation", "LUserUpdate", "LastUpdate", "Name", "SeqNo" },
                values: new object[,]
                {
                    { "04558d85-00a8-46de-944e-2bb946eb2143", new DateTime(2024, 3, 3, 22, 2, 37, 164, DateTimeKind.Local).AddTicks(7328), "", new DateTime(2024, 3, 3, 22, 2, 37, 164, DateTimeKind.Local).AddTicks(7328), "Nuts And Seeds", 0 },
                    { "1348d5a0-4df4-4365-bcb2-ffb3c5177e9b", new DateTime(2024, 3, 3, 22, 2, 37, 164, DateTimeKind.Local).AddTicks(7316), "", new DateTime(2024, 3, 3, 22, 2, 37, 164, DateTimeKind.Local).AddTicks(7317), "Baking Ingredients", 0 },
                    { "2d8724e4-8726-4df9-9239-23d71502ad99", new DateTime(2024, 3, 3, 22, 2, 37, 164, DateTimeKind.Local).AddTicks(7295), "", new DateTime(2024, 3, 3, 22, 2, 37, 164, DateTimeKind.Local).AddTicks(7295), "Condiments And Sauces", 0 },
                    { "3a844963-34ed-4300-9589-00ef2be7e093", new DateTime(2024, 3, 3, 22, 2, 37, 164, DateTimeKind.Local).AddTicks(7153), "", new DateTime(2024, 3, 3, 22, 2, 37, 164, DateTimeKind.Local).AddTicks(7163), "Proteins", 0 },
                    { "60371825-a9f4-47dc-ad65-0de474a70960", new DateTime(2024, 3, 3, 22, 2, 37, 164, DateTimeKind.Local).AddTicks(7234), "", new DateTime(2024, 3, 3, 22, 2, 37, 164, DateTimeKind.Local).AddTicks(7235), "Vegetables And Herbs", 0 },
                    { "7b7e46e8-98fa-47eb-8818-32f240c02eb4", new DateTime(2024, 3, 3, 22, 2, 37, 164, DateTimeKind.Local).AddTicks(7307), "", new DateTime(2024, 3, 3, 22, 2, 37, 164, DateTimeKind.Local).AddTicks(7307), "Spices And Seasonings", 0 },
                    { "a215675e-3079-497f-8fb2-fd4cf6931f30", new DateTime(2024, 3, 3, 22, 2, 37, 164, DateTimeKind.Local).AddTicks(7242), "", new DateTime(2024, 3, 3, 22, 2, 37, 164, DateTimeKind.Local).AddTicks(7242), "Fruits", 0 },
                    { "d01312db-1c6f-4b7a-9a89-9304fe246229", new DateTime(2024, 3, 3, 22, 2, 37, 164, DateTimeKind.Local).AddTicks(7335), "", new DateTime(2024, 3, 3, 22, 2, 37, 164, DateTimeKind.Local).AddTicks(7335), "Beverages", 0 },
                    { "d9bd0148-c913-451a-ba2d-eb017807e5c8", new DateTime(2024, 3, 3, 22, 2, 37, 164, DateTimeKind.Local).AddTicks(7281), "", new DateTime(2024, 3, 3, 22, 2, 37, 164, DateTimeKind.Local).AddTicks(7281), "Dairy And Dairy Alternatives", 0 },
                    { "e5db590a-17b3-45dd-b38d-12d7aa7464bd", new DateTime(2024, 3, 3, 22, 2, 37, 164, DateTimeKind.Local).AddTicks(7255), "", new DateTime(2024, 3, 3, 22, 2, 37, 164, DateTimeKind.Local).AddTicks(7256), "Grains And Starches", 0 }
                });

            migrationBuilder.InsertData(
                table: "Measurements",
                columns: new[] { "Id", "Abbreviation", "Creation", "Description", "LUserUpdate", "LastUpdate", "Name", "SeqNo" },
                values: new object[,]
                {
                    { "041d3619-4e2c-470d-ac2c-d0ba3634a838", "tsp.", new DateTime(2024, 3, 3, 22, 2, 37, 164, DateTimeKind.Local).AddTicks(8353), "Approximately 5 ml.", "", new DateTime(2024, 3, 3, 22, 2, 37, 164, DateTimeKind.Local).AddTicks(8354), "Teaspoon", 0 },
                    { "215be7ce-6ba5-4eb7-bba0-1c975033ac3a", "ml", new DateTime(2024, 3, 3, 22, 2, 37, 164, DateTimeKind.Local).AddTicks(8224), "Used for liquids, such as water, milk, and oil", "", new DateTime(2024, 3, 3, 22, 2, 37, 164, DateTimeKind.Local).AddTicks(8226), "Milliliter", 0 },
                    { "3815cd54-0663-4540-8da4-3426a204f838", "Tbsp", new DateTime(2024, 3, 3, 22, 2, 37, 164, DateTimeKind.Local).AddTicks(8360), "Approximately 15 ml.", "", new DateTime(2024, 3, 3, 22, 2, 37, 164, DateTimeKind.Local).AddTicks(8360), "Tablespoon", 0 },
                    { "613d3d95-a33a-4a70-b42f-17961d26184b", "kg", new DateTime(2024, 3, 3, 22, 2, 37, 164, DateTimeKind.Local).AddTicks(8348), "Larger mass measurements, especially for bulk ingredients.", "", new DateTime(2024, 3, 3, 22, 2, 37, 164, DateTimeKind.Local).AddTicks(8348), "Kilograms", 0 },
                    { "a07300ca-e32f-4581-a836-02a6d088c52e", "l", new DateTime(2024, 3, 3, 22, 2, 37, 164, DateTimeKind.Local).AddTicks(8233), "Larger volume measurements, often used for bulk liquids.", "", new DateTime(2024, 3, 3, 22, 2, 37, 164, DateTimeKind.Local).AddTicks(8234), "Liters", 0 },
                    { "ac1f0eee-80f9-4503-a821-ef1d1b5ab726", "250 ml", new DateTime(2024, 3, 3, 22, 2, 37, 164, DateTimeKind.Local).AddTicks(8364), "Used for both liquid and dry ingredients.", "", new DateTime(2024, 3, 3, 22, 2, 37, 164, DateTimeKind.Local).AddTicks(8364), "Cup", 0 },
                    { "ea3afeb6-8bf0-4f8f-9624-4f63883fcd27", "g", new DateTime(2024, 3, 3, 22, 2, 37, 164, DateTimeKind.Local).AddTicks(8242), "Common unit for measuring dry ingredients like flour, sugar, and spices.", "", new DateTime(2024, 3, 3, 22, 2, 37, 164, DateTimeKind.Local).AddTicks(8243), "Grams", 0 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_IngredientCategories_Name",
                table: "IngredientCategories",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Measurements_Name",
                table: "Measurements",
                column: "Name",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "IngredientCategories");

            migrationBuilder.DropTable(
                name: "Measurements");
        }
    }
}
