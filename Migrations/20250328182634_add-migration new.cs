using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace mvcproj.Migrations
{
    /// <inheritdoc />
    public partial class addmigrationnew : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "price",
                table: "Rooms",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "price",
                table: "Rooms");
        }
    }
}
