using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DKTech.Migrations
{
    /// <inheritdoc />
    public partial class OrderDate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Order_date",
                table: "Customer",
                newName: "OrderDate");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "OrderDate",
                table: "Customer",
                newName: "Order_date");
        }
    }
}
