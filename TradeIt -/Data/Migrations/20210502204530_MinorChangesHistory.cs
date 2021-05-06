using Microsoft.EntityFrameworkCore.Migrations;

namespace TradeIt__.Data.Migrations
{
    public partial class MinorChangesHistory : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CurrencyName",
                table: "TransactionsHistory",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CurrencyName",
                table: "TransactionsHistory");
        }
    }
}
