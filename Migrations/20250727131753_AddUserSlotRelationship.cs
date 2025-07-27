using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BackendAPI.Migrations
{
    /// <inheritdoc />
    public partial class AddUserSlotRelationship : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "Slots");

            migrationBuilder.AddColumn<int>(
                name: "CreatedByUserId",
                table: "Slots",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedByUserId",
                table: "Slots");

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "Slots",
                type: "text",
                nullable: false,
                defaultValue: "");
        }
    }
}
