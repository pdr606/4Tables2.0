using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace _4Tables2._0.Infra.Migrations
{
    /// <inheritdoc />
    public partial class efmtolixo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Table",
                table: "ReceivedOrders",
                type: "integer",
                nullable: false,
                oldClrType: typeof(short),
                oldType: "smallint");

            migrationBuilder.AlterColumn<int>(
                name: "TableNumber",
                table: "Orders",
                type: "integer",
                nullable: false,
                oldClrType: typeof(short),
                oldType: "smallint");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<short>(
                name: "Table",
                table: "ReceivedOrders",
                type: "smallint",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<short>(
                name: "TableNumber",
                table: "Orders",
                type: "smallint",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer");
        }
    }
}
