using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AppProject.Core.Infrastructure.Database.Migrations
{
    /// <inheritdoc />
    public partial class StockMovements : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_StockMovements_ProductId",
                table: "StockMovements");

            migrationBuilder.CreateIndex(
                name: "IX_StockMovements_ProductId_MovementDate",
                table: "StockMovements",
                columns: new[] { "ProductId", "MovementDate" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_StockMovements_ProductId_MovementDate",
                table: "StockMovements");

            migrationBuilder.CreateIndex(
                name: "IX_StockMovements_ProductId",
                table: "StockMovements",
                column: "ProductId");
        }
    }
}
