using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Africuisine.Infrastructure.Migrations.AfricuisineDb
{
    public partial class AddRecipePicturesTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "RecipePictures",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Uri = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RecipeId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ContentType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Format = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Creation = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LUserUpdate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SeqNo = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RecipePictures", x => x.Id);
                    table.UniqueConstraint(
                        name: "UC_RecipePictures_RecipeId_Name",
                        columns: x => new { x.RecipeId, x.Name} );
                });
            migrationBuilder.CreateIndex(
                name: "IX_RecipePictures_RecipeId",
                table: "RecipePictures",
                column: "RecipeId",
                unique: false);

        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex("IX_RecipePictures_RecipeId", table: "RecipePictures");
            migrationBuilder.DropUniqueConstraint("UC_RecipePictures_RecipeId_Name", table: "RecipePictures");
            migrationBuilder.DropTable(name: "RecipePictures");
        }
    }
}
