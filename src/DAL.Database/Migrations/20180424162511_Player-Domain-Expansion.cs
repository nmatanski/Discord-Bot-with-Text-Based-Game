using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace DAL.Database.Migrations
{
    public partial class PlayerDomainExpansion : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_InventoryItem_Players_PlayerID",
                table: "InventoryItem");

            migrationBuilder.DropForeignKey(
                name: "FK_PlayerQuest_Players_PlayerID",
                table: "PlayerQuest");

            migrationBuilder.AlterColumn<int>(
                name: "PlayerID",
                table: "PlayerQuest",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "PlayerID",
                table: "InventoryItem",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_InventoryItem_Players_PlayerID",
                table: "InventoryItem",
                column: "PlayerID",
                principalTable: "Players",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PlayerQuest_Players_PlayerID",
                table: "PlayerQuest",
                column: "PlayerID",
                principalTable: "Players",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_InventoryItem_Players_PlayerID",
                table: "InventoryItem");

            migrationBuilder.DropForeignKey(
                name: "FK_PlayerQuest_Players_PlayerID",
                table: "PlayerQuest");

            migrationBuilder.AlterColumn<int>(
                name: "PlayerID",
                table: "PlayerQuest",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "PlayerID",
                table: "InventoryItem",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_InventoryItem_Players_PlayerID",
                table: "InventoryItem",
                column: "PlayerID",
                principalTable: "Players",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PlayerQuest_Players_PlayerID",
                table: "PlayerQuest",
                column: "PlayerID",
                principalTable: "Players",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
