using Microsoft.EntityFrameworkCore.Migrations;

namespace Solitude2.Migrations
{
    public partial class InitDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Monsters",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AttackName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Level = table.Column<int>(type: "int", nullable: false),
                    Alive = table.Column<bool>(type: "bit", nullable: false),
                    GoldDrop = table.Column<float>(type: "real", nullable: false),
                    ExpDrop = table.Column<float>(type: "real", nullable: false),
                    DropID = table.Column<int>(type: "int", nullable: true),
                    TalentDrop = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MaxHP = table.Column<float>(type: "real", nullable: false),
                    CurrentHP = table.Column<float>(type: "real", nullable: false),
                    Dmg = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Monsters", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Players",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Alive = table.Column<bool>(type: "bit", nullable: false),
                    Gold = table.Column<float>(type: "real", nullable: false),
                    CurrentLvl = table.Column<int>(type: "int", nullable: false),
                    MaxLvl = table.Column<int>(type: "int", nullable: false),
                    CurrentExp = table.Column<float>(type: "real", nullable: false),
                    ExpReqForLvl = table.Column<float>(type: "real", nullable: false),
                    CurrentHP = table.Column<float>(type: "real", nullable: false),
                    MaxHP = table.Column<float>(type: "real", nullable: false),
                    AttackPower = table.Column<float>(type: "real", nullable: false),
                    CritBonus = table.Column<float>(type: "real", nullable: false),
                    CritPercent = table.Column<float>(type: "real", nullable: false),
                    EquippedWeaponID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Players", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Items",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Value = table.Column<float>(type: "real", nullable: false),
                    Bonus = table.Column<float>(type: "real", nullable: false),
                    Discriminator = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PlayerID = table.Column<int>(type: "int", nullable: true),
                    PlayerID1 = table.Column<int>(type: "int", nullable: true),
                    Weapon_PlayerID1 = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Items", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Items_Players_PlayerID",
                        column: x => x.PlayerID,
                        principalTable: "Players",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Items_Players_PlayerID1",
                        column: x => x.PlayerID1,
                        principalTable: "Players",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Items_Players_Weapon_PlayerID1",
                        column: x => x.Weapon_PlayerID1,
                        principalTable: "Players",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Items_PlayerID",
                table: "Items",
                column: "PlayerID");

            migrationBuilder.CreateIndex(
                name: "IX_Items_PlayerID1",
                table: "Items",
                column: "PlayerID1");

            migrationBuilder.CreateIndex(
                name: "IX_Items_Weapon_PlayerID1",
                table: "Items",
                column: "Weapon_PlayerID1");

            migrationBuilder.CreateIndex(
                name: "IX_Monsters_DropID",
                table: "Monsters",
                column: "DropID");

            migrationBuilder.CreateIndex(
                name: "IX_Players_EquippedWeaponID",
                table: "Players",
                column: "EquippedWeaponID");

            migrationBuilder.AddForeignKey(
                name: "FK_Monsters_Items_DropID",
                table: "Monsters",
                column: "DropID",
                principalTable: "Items",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Players_Items_EquippedWeaponID",
                table: "Players",
                column: "EquippedWeaponID",
                principalTable: "Items",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Items_Players_PlayerID",
                table: "Items");

            migrationBuilder.DropForeignKey(
                name: "FK_Items_Players_PlayerID1",
                table: "Items");

            migrationBuilder.DropForeignKey(
                name: "FK_Items_Players_Weapon_PlayerID1",
                table: "Items");

            migrationBuilder.DropTable(
                name: "Monsters");

            migrationBuilder.DropTable(
                name: "Players");

            migrationBuilder.DropTable(
                name: "Items");
        }
    }
}
