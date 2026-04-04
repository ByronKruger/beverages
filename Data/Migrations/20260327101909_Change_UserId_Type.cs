using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Coffeeg.Data.Migrations
{
    /// <inheritdoc />
    public partial class Change_UserId_Type : Migration
    {
        /// <inheritdoc />
        //protected override void Up(MigrationBuilder migrationBuilder)
        //{
        //    migrationBuilder.DropForeignKey(
        //        name: "FK_BeverageCustomisation_User_UserId1",
        //        table: "BeverageCustomisation");

        //    migrationBuilder.DropIndex(
        //        name: "IX_BeverageCustomisation_UserId1",
        //        table: "BeverageCustomisation");

        //    migrationBuilder.DropColumn(
        //        name: "UserId1",
        //        table: "BeverageCustomisation");

        //    migrationBuilder.AlterColumn<string>(
        //        name: "UserId",
        //        table: "BeverageCustomisation",
        //        type: "nvarchar(450)",
        //        nullable: false,
        //        oldClrType: typeof(int),
        //        oldType: "int");

        //    migrationBuilder.CreateIndex(
        //        name: "IX_BeverageCustomisation_UserId",
        //        table: "BeverageCustomisation",
        //        column: "UserId");

        //    migrationBuilder.AddForeignKey(
        //        name: "FK_BeverageCustomisation_User_UserId",
        //        table: "BeverageCustomisation",
        //        column: "UserId",
        //        principalTable: "User",
        //        principalColumn: "Id",
        //        onDelete: ReferentialAction.Cascade);
        //}
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // Step 1: Drop the old FK and index (you already have this)
            migrationBuilder.DropForeignKey(
                name: "FK_BeverageCustomisation_User_UserId1",
                table: "BeverageCustomisation");

            migrationBuilder.DropIndex(
                name: "IX_BeverageCustomisation_UserId1",
                table: "BeverageCustomisation");

            // Step 2: Make the column nullable temporarily so we can update values without constraint issues
            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "BeverageCustomisation",
                type: "nvarchar(450)",
                nullable: true,   // <--- Change to true temporarily
                oldClrType: typeof(int),
                oldType: "int");

            // Step 3: Convert existing int values to string equivalents
            // This is the critical data migration step EF didn't add automatically
            migrationBuilder.Sql(@"
                UPDATE [BeverageCustomisation]
                SET [UserId] = CAST([UserId] AS nvarchar(450))
                WHERE [UserId] IS NOT NULL;
            ");

            // Step 4: Now make it non-nullable again (assuming no nulls should exist)
            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "BeverageCustomisation",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            // Step 5: Create new index and FK
            migrationBuilder.CreateIndex(
                name: "IX_BeverageCustomisation_UserId",
                table: "BeverageCustomisation",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_BeverageCustomisation_User_UserId",
                table: "BeverageCustomisation",
                column: "UserId",
                principalTable: "User",           // Note: Your table is named "User" (unconventional, usually AspNetUsers)
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        //protected override void Down(MigrationBuilder migrationBuilder)
        //{
        //    migrationBuilder.DropForeignKey(
        //        name: "FK_BeverageCustomisation_User_UserId",
        //        table: "BeverageCustomisation");

        //    migrationBuilder.DropIndex(
        //        name: "IX_BeverageCustomisation_UserId",
        //        table: "BeverageCustomisation");

        //    migrationBuilder.AlterColumn<int>(
        //        name: "UserId",
        //        table: "BeverageCustomisation",
        //        type: "int",
        //        nullable: false,
        //        oldClrType: typeof(string),
        //        oldType: "nvarchar(450)");

        //    migrationBuilder.AddColumn<string>(
        //        name: "UserId1",
        //        table: "BeverageCustomisation",
        //        type: "nvarchar(450)",
        //        nullable: true);

        //    migrationBuilder.CreateIndex(
        //        name: "IX_BeverageCustomisation_UserId1",
        //        table: "BeverageCustomisation",
        //        column: "UserId1");

        //    migrationBuilder.AddForeignKey(
        //        name: "FK_BeverageCustomisation_User_UserId1",
        //        table: "BeverageCustomisation",
        //        column: "UserId1",
        //        principalTable: "User",
        //        principalColumn: "Id");
        //}

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BeverageCustomisation_User_UserId",
                table: "BeverageCustomisation");

            migrationBuilder.DropIndex(
                name: "IX_BeverageCustomisation_UserId",
                table: "BeverageCustomisation");

            // Make nullable temporarily for conversion back
            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "BeverageCustomisation",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            // Convert string back to int (be careful with potential data loss if values aren't valid ints)
            migrationBuilder.Sql(@"
                UPDATE [BeverageCustomisation]
                SET [UserId] = CAST([UserId] AS int)
                WHERE [UserId] IS NOT NULL AND ISNUMERIC([UserId]) = 1;
            ");

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "BeverageCustomisation",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            // Restore old shadow column, index, and FK if needed (your original Down had this logic)
            migrationBuilder.AddColumn<string>(
                name: "UserId1",
                table: "BeverageCustomisation",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_BeverageCustomisation_UserId1",
                table: "BeverageCustomisation",
                column: "UserId1");

            migrationBuilder.AddForeignKey(
                name: "FK_BeverageCustomisation_User_UserId1",
                table: "BeverageCustomisation",
                column: "UserId1",
                principalTable: "User",
                principalColumn: "Id");
        }
    }
}
