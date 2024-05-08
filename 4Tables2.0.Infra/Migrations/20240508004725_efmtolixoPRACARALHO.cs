using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace _4Tables2._0.Infra.Migrations
{
    /// <inheritdoc />
    public partial class efmtolixoPRACARALHO : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Orders_TableNumber",
                table: "Orders",
                column: "TableNumber");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Tables_TableNumber",
                table: "Orders",
                column: "TableNumber",
                principalTable: "Tables",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Tables_TableNumber",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_Orders_TableNumber",
                table: "Orders");
        }
    }
}
