using Microsoft.EntityFrameworkCore.Migrations;

namespace DAL.Database.Migrations
{
    public partial class LootTablerefinements : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Locations_NPC_EnemyLivingHereID",
                table: "Locations");

            migrationBuilder.DropForeignKey(
                name: "FK_LootItem_NPC_EnemyID",
                table: "LootItem");

            migrationBuilder.DropForeignKey(
                name: "FK_LootItem_NPC_NPCID",
                table: "LootItem");

            migrationBuilder.DropPrimaryKey(
                name: "PK_NPC",
                table: "NPC");

            migrationBuilder.DropIndex(
                name: "IX_LootItem_NPCID",
                table: "LootItem");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "NPC");

            migrationBuilder.DropColumn(
                name: "NPCID",
                table: "LootItem");

            migrationBuilder.RenameTable(
                name: "NPC",
                newName: "Enemies");

            migrationBuilder.AlterColumn<int>(
                name: "RewardXP",
                table: "Enemies",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "RewardGold",
                table: "Enemies",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "EnemyID",
                table: "LootItem",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Enemies",
                table: "Enemies",
                column: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Locations_Enemies_EnemyLivingHereID",
                table: "Locations",
                column: "EnemyLivingHereID",
                principalTable: "Enemies",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_LootItem_Enemies_EnemyID",
                table: "LootItem",
                column: "EnemyID",
                principalTable: "Enemies",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Locations_Enemies_EnemyLivingHereID",
                table: "Locations");

            migrationBuilder.DropForeignKey(
                name: "FK_LootItem_Enemies_EnemyID",
                table: "LootItem");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Enemies",
                table: "Enemies");

            migrationBuilder.RenameTable(
                name: "Enemies",
                newName: "NPC");

            migrationBuilder.AlterColumn<int>(
                name: "EnemyID",
                table: "LootItem",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<int>(
                name: "NPCID",
                table: "LootItem",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "RewardXP",
                table: "NPC",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "RewardGold",
                table: "NPC",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "NPC",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_NPC",
                table: "NPC",
                column: "ID");

            migrationBuilder.CreateIndex(
                name: "IX_LootItem_NPCID",
                table: "LootItem",
                column: "NPCID");

            migrationBuilder.AddForeignKey(
                name: "FK_Locations_NPC_EnemyLivingHereID",
                table: "Locations",
                column: "EnemyLivingHereID",
                principalTable: "NPC",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_LootItem_NPC_EnemyID",
                table: "LootItem",
                column: "EnemyID",
                principalTable: "NPC",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_LootItem_NPC_NPCID",
                table: "LootItem",
                column: "NPCID",
                principalTable: "NPC",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
