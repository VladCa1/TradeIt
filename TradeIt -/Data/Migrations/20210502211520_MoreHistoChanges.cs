using Microsoft.EntityFrameworkCore.Migrations;

namespace TradeIt__.Data.Migrations
{
    public partial class MoreHistoChanges : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ReceiverUserName",
                table: "TransactionsHistory",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SenderUserName",
                table: "TransactionsHistory",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ReceiverUserName",
                table: "TransactionsHistory");

            migrationBuilder.DropColumn(
                name: "SenderUserName",
                table: "TransactionsHistory");
        }
    }
}
