using Microsoft.EntityFrameworkCore.Migrations;

namespace TradeIt__.Data.Migrations
{
    public partial class addLinkage : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "SenderId",
                table: "TransactionsHistory",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ReceiverId",
                table: "TransactionsHistory",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "CurrencyId",
                table: "TransactionsHistory",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_TransactionsHistory_CurrencyId",
                table: "TransactionsHistory",
                column: "CurrencyId");

            migrationBuilder.CreateIndex(
                name: "IX_TransactionsHistory_ReceiverId",
                table: "TransactionsHistory",
                column: "ReceiverId");

            migrationBuilder.CreateIndex(
                name: "IX_TransactionsHistory_SenderId",
                table: "TransactionsHistory",
                column: "SenderId");

            migrationBuilder.AddForeignKey(
                name: "FK_TransactionsHistory_Currencies_CurrencyId",
                table: "TransactionsHistory",
                column: "CurrencyId",
                principalTable: "Currencies",
                principalColumn: "CurrencyId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TransactionsHistory_AspNetUsers_ReceiverId",
                table: "TransactionsHistory",
                column: "ReceiverId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TransactionsHistory_AspNetUsers_SenderId",
                table: "TransactionsHistory",
                column: "SenderId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TransactionsHistory_Currencies_CurrencyId",
                table: "TransactionsHistory");

            migrationBuilder.DropForeignKey(
                name: "FK_TransactionsHistory_AspNetUsers_ReceiverId",
                table: "TransactionsHistory");

            migrationBuilder.DropForeignKey(
                name: "FK_TransactionsHistory_AspNetUsers_SenderId",
                table: "TransactionsHistory");

            migrationBuilder.DropIndex(
                name: "IX_TransactionsHistory_CurrencyId",
                table: "TransactionsHistory");

            migrationBuilder.DropIndex(
                name: "IX_TransactionsHistory_ReceiverId",
                table: "TransactionsHistory");

            migrationBuilder.DropIndex(
                name: "IX_TransactionsHistory_SenderId",
                table: "TransactionsHistory");

            migrationBuilder.AlterColumn<string>(
                name: "SenderId",
                table: "TransactionsHistory",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ReceiverId",
                table: "TransactionsHistory",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CurrencyId",
                table: "TransactionsHistory",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(int));
        }
    }
}
