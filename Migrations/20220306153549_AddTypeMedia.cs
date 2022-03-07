using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace backend.Migrations
{
    public partial class AddTypeMedia : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CategoryId",
                table: "Medias",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TypeMediaId",
                table: "Medias",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "TypeMedias",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TypeMedias", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Medias_CategoryId",
                table: "Medias",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Medias_TypeMediaId",
                table: "Medias",
                column: "TypeMediaId");

            migrationBuilder.AddForeignKey(
                name: "fk_Media_Category",
                table: "Medias",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_Media_Type",
                table: "Medias",
                column: "TypeMediaId",
                principalTable: "TypeMedias",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_Media_Category",
                table: "Medias");

            migrationBuilder.DropForeignKey(
                name: "fk_Media_Type",
                table: "Medias");

            migrationBuilder.DropTable(
                name: "TypeMedias");

            migrationBuilder.DropIndex(
                name: "IX_Medias_CategoryId",
                table: "Medias");

            migrationBuilder.DropIndex(
                name: "IX_Medias_TypeMediaId",
                table: "Medias");

            migrationBuilder.DropColumn(
                name: "CategoryId",
                table: "Medias");

            migrationBuilder.DropColumn(
                name: "TypeMediaId",
                table: "Medias");
        }
    }
}
