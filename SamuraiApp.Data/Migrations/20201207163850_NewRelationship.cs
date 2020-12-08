using Microsoft.EntityFrameworkCore.Migrations;

namespace SamuraiApp.Data.Migrations
{
    public partial class NewRelationship : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SamuraiBattle_Battle_BattleId",
                table: "SamuraiBattle");


            migrationBuilder.DropPrimaryKey(
                name: "PK_Battle",
                table: "Battle");

            migrationBuilder.RenameTable(
                name: "Battle",
                newName: "Battles");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Battles",
                table: "Battles",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Horses",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    SamuraiId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Horses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Horses_Samurais_SamuraiId",
                        column: x => x.SamuraiId,
                        principalTable: "Samurais",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Horses_SamuraiId",
                table: "Horses",
                column: "SamuraiId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_SamuraiBattle_Battles_BattleId",
                table: "SamuraiBattle",
                column: "BattleId",
                principalTable: "Battles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SamuraiBattle_Battles_BattleId",
                table: "SamuraiBattle");

            migrationBuilder.DropTable(
                name: "Horses");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Battles",
                table: "Battles");

            migrationBuilder.RenameTable(
                name: "Battles",
                newName: "Battle");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Battle",
                table: "Battle",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_SamuraiBattle_Battle_BattleId",
                table: "SamuraiBattle",
                column: "BattleId",
                principalTable: "Battle",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
