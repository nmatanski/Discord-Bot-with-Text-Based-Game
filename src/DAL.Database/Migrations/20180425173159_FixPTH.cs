using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace DAL.Database.Migrations
{
    public partial class FixPTH : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Enemies",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CurrentHP = table.Column<int>(nullable: false),
                    MaxDamage = table.Column<int>(nullable: false),
                    MaxHP = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    RewardGold = table.Column<int>(nullable: false),
                    RewardXP = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Enemies", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Items",
                columns: table => new
                {
                    AmountToHeal = table.Column<int>(nullable: true),
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Discriminator = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    NamePlural = table.Column<string>(nullable: true),
                    Price = table.Column<int>(nullable: false),
                    MaxDamage = table.Column<int>(nullable: true),
                    MinDamage = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Items", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "LootItems",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DropPercentage = table.Column<int>(nullable: false),
                    EnemyID = table.Column<int>(nullable: false),
                    IsDefaultItem = table.Column<bool>(nullable: false),
                    ItemID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LootItems", x => x.ID);
                    table.ForeignKey(
                        name: "FK_LootItems_Enemies_EnemyID",
                        column: x => x.EnemyID,
                        principalTable: "Enemies",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LootItems_Items_ItemID",
                        column: x => x.ItemID,
                        principalTable: "Items",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Quests",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Description = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    RewardGold = table.Column<int>(nullable: false),
                    RewardItemID = table.Column<int>(nullable: true),
                    RewardXP = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Quests", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Quests_Items_RewardItemID",
                        column: x => x.RewardItemID,
                        principalTable: "Items",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Locations",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Description = table.Column<string>(nullable: true),
                    EnemyLivingHereID = table.Column<int>(nullable: true),
                    ItemRequiredToEnterID = table.Column<int>(nullable: true),
                    LocationToEastID = table.Column<int>(nullable: true),
                    LocationToNorthID = table.Column<int>(nullable: true),
                    LocationToSouthID = table.Column<int>(nullable: true),
                    LocationToWestID = table.Column<int>(nullable: true),
                    Map = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    QuestAvailableHereID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Locations", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Locations_Enemies_EnemyLivingHereID",
                        column: x => x.EnemyLivingHereID,
                        principalTable: "Enemies",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Locations_Items_ItemRequiredToEnterID",
                        column: x => x.ItemRequiredToEnterID,
                        principalTable: "Items",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Locations_Quests_QuestAvailableHereID",
                        column: x => x.QuestAvailableHereID,
                        principalTable: "Quests",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "QuestCompletionItem",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ItemID = table.Column<int>(nullable: true),
                    Quantity = table.Column<int>(nullable: false),
                    QuestID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QuestCompletionItem", x => x.ID);
                    table.ForeignKey(
                        name: "FK_QuestCompletionItem_Items_ItemID",
                        column: x => x.ItemID,
                        principalTable: "Items",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_QuestCompletionItem_Quests_QuestID",
                        column: x => x.QuestID,
                        principalTable: "Quests",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Players",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CurrentHP = table.Column<int>(nullable: false),
                    CurrentLocationID = table.Column<int>(nullable: true),
                    CurrentWeaponID = table.Column<int>(nullable: true),
                    Gold = table.Column<int>(nullable: false),
                    MaxHP = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    XP = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Players", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Players_Locations_CurrentLocationID",
                        column: x => x.CurrentLocationID,
                        principalTable: "Locations",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Players_Items_CurrentWeaponID",
                        column: x => x.CurrentWeaponID,
                        principalTable: "Items",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "InventoryItem",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ItemID = table.Column<int>(nullable: true),
                    PlayerID = table.Column<int>(nullable: false),
                    Quantity = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InventoryItem", x => x.ID);
                    table.ForeignKey(
                        name: "FK_InventoryItem_Items_ItemID",
                        column: x => x.ItemID,
                        principalTable: "Items",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_InventoryItem_Players_PlayerID",
                        column: x => x.PlayerID,
                        principalTable: "Players",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PlayerQuest",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    IsCompleted = table.Column<bool>(nullable: false),
                    PlayerID = table.Column<int>(nullable: false),
                    QuestID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlayerQuest", x => x.ID);
                    table.ForeignKey(
                        name: "FK_PlayerQuest_Players_PlayerID",
                        column: x => x.PlayerID,
                        principalTable: "Players",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PlayerQuest_Quests_QuestID",
                        column: x => x.QuestID,
                        principalTable: "Quests",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    DateChanged = table.Column<DateTime>(nullable: true),
                    DateCreated = table.Column<DateTime>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    ImgUrl = table.Column<string>(nullable: true),
                    IsEmailConfirmed = table.Column<bool>(nullable: false),
                    Password = table.Column<string>(nullable: true),
                    PlayerID = table.Column<int>(nullable: false),
                    UserRole = table.Column<int>(nullable: false),
                    Username = table.Column<string>(nullable: true),
                    ValidationCode = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Users_Players_PlayerID",
                        column: x => x.PlayerID,
                        principalTable: "Players",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_InventoryItem_ItemID",
                table: "InventoryItem",
                column: "ItemID");

            migrationBuilder.CreateIndex(
                name: "IX_InventoryItem_PlayerID",
                table: "InventoryItem",
                column: "PlayerID");

            migrationBuilder.CreateIndex(
                name: "IX_Locations_EnemyLivingHereID",
                table: "Locations",
                column: "EnemyLivingHereID");

            migrationBuilder.CreateIndex(
                name: "IX_Locations_ItemRequiredToEnterID",
                table: "Locations",
                column: "ItemRequiredToEnterID");

            migrationBuilder.CreateIndex(
                name: "IX_Locations_QuestAvailableHereID",
                table: "Locations",
                column: "QuestAvailableHereID");

            migrationBuilder.CreateIndex(
                name: "IX_LootItems_EnemyID",
                table: "LootItems",
                column: "EnemyID");

            migrationBuilder.CreateIndex(
                name: "IX_LootItems_ItemID",
                table: "LootItems",
                column: "ItemID");

            migrationBuilder.CreateIndex(
                name: "IX_PlayerQuest_PlayerID",
                table: "PlayerQuest",
                column: "PlayerID");

            migrationBuilder.CreateIndex(
                name: "IX_PlayerQuest_QuestID",
                table: "PlayerQuest",
                column: "QuestID");

            migrationBuilder.CreateIndex(
                name: "IX_Players_CurrentLocationID",
                table: "Players",
                column: "CurrentLocationID");

            migrationBuilder.CreateIndex(
                name: "IX_Players_CurrentWeaponID",
                table: "Players",
                column: "CurrentWeaponID");

            migrationBuilder.CreateIndex(
                name: "IX_QuestCompletionItem_ItemID",
                table: "QuestCompletionItem",
                column: "ItemID");

            migrationBuilder.CreateIndex(
                name: "IX_QuestCompletionItem_QuestID",
                table: "QuestCompletionItem",
                column: "QuestID");

            migrationBuilder.CreateIndex(
                name: "IX_Quests_RewardItemID",
                table: "Quests",
                column: "RewardItemID");

            migrationBuilder.CreateIndex(
                name: "IX_Users_PlayerID",
                table: "Users",
                column: "PlayerID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "InventoryItem");

            migrationBuilder.DropTable(
                name: "LootItems");

            migrationBuilder.DropTable(
                name: "PlayerQuest");

            migrationBuilder.DropTable(
                name: "QuestCompletionItem");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Players");

            migrationBuilder.DropTable(
                name: "Locations");

            migrationBuilder.DropTable(
                name: "Enemies");

            migrationBuilder.DropTable(
                name: "Quests");

            migrationBuilder.DropTable(
                name: "Items");
        }
    }
}
