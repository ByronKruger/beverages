using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Coffeeg.Data.Migrations
{
    /// <inheritdoc />
    public partial class Remove_Id : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Id",
                table: "IngredientAmount");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "IngredientAmount",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
