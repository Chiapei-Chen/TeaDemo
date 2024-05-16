using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TeaProject.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class Toppings : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Toppings",
                table: "ShoppingCart",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Toppings",
                table: "ShoppingCart");
        }
    }
}
