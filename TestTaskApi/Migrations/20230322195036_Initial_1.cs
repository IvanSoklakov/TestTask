using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TestTaskApi.Migrations
{
    /// <inheritdoc />
    public partial class Initial_1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bets_Players_PlayerId",
                table: "Bets");

            migrationBuilder.DropForeignKey(
                name: "FK_Transactions_Players_PlayerId",
                table: "Transactions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Transactions",
                table: "Transactions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Players",
                table: "Players");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Bets",
                table: "Bets");

            migrationBuilder.RenameTable(
                name: "Transactions",
                newName: "Transaction");

            migrationBuilder.RenameTable(
                name: "Players",
                newName: "Player");

            migrationBuilder.RenameTable(
                name: "Bets",
                newName: "Bet");

            migrationBuilder.RenameIndex(
                name: "IX_Transactions_PlayerId",
                table: "Transaction",
                newName: "IX_Transaction_PlayerId");

            migrationBuilder.RenameIndex(
                name: "IX_Bets_PlayerId",
                table: "Bet",
                newName: "IX_Bet_PlayerId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Transaction",
                table: "Transaction",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Player",
                table: "Player",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Bet",
                table: "Bet",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Bet_Player_PlayerId",
                table: "Bet",
                column: "PlayerId",
                principalTable: "Player",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Transaction_Player_PlayerId",
                table: "Transaction",
                column: "PlayerId",
                principalTable: "Player",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bet_Player_PlayerId",
                table: "Bet");

            migrationBuilder.DropForeignKey(
                name: "FK_Transaction_Player_PlayerId",
                table: "Transaction");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Transaction",
                table: "Transaction");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Player",
                table: "Player");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Bet",
                table: "Bet");

            migrationBuilder.RenameTable(
                name: "Transaction",
                newName: "Transactions");

            migrationBuilder.RenameTable(
                name: "Player",
                newName: "Players");

            migrationBuilder.RenameTable(
                name: "Bet",
                newName: "Bets");

            migrationBuilder.RenameIndex(
                name: "IX_Transaction_PlayerId",
                table: "Transactions",
                newName: "IX_Transactions_PlayerId");

            migrationBuilder.RenameIndex(
                name: "IX_Bet_PlayerId",
                table: "Bets",
                newName: "IX_Bets_PlayerId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Transactions",
                table: "Transactions",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Players",
                table: "Players",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Bets",
                table: "Bets",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Bets_Players_PlayerId",
                table: "Bets",
                column: "PlayerId",
                principalTable: "Players",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Transactions_Players_PlayerId",
                table: "Transactions",
                column: "PlayerId",
                principalTable: "Players",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
