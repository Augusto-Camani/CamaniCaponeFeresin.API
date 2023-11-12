using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CamaniCaponeFeresin.API.Migrations
{
    /// <inheritdoc />
    public partial class Third : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PurchaseId",
                table: "SaleLines");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PurchaseId",
                table: "SaleLines",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);
        }
    }
}
