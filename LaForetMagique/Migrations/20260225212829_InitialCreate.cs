using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LaForetMagique.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Entities",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    x = table.Column<int>(type: "int", nullable: false),
                    y = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EntityType = table.Column<string>(type: "nvarchar(13)", maxLength: 13, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Health = table.Column<int>(type: "int", nullable: true),
                    MaxHealth = table.Column<int>(type: "int", nullable: true),
                    AttackPower = table.Column<int>(type: "int", nullable: true),
                    IsHostile = table.Column<bool>(type: "bit", nullable: true),
                    FlightSpeed = table.Column<int>(type: "int", nullable: true),
                    WebStrength = table.Column<int>(type: "int", nullable: true),
                    Role = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ExperiencePoints = table.Column<int>(type: "int", nullable: true),
                    Item_Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsCollected = table.Column<bool>(type: "bit", nullable: true),
                    Berry_HealAmount = table.Column<int>(type: "int", nullable: true),
                    HealAmount = table.Column<int>(type: "int", nullable: true),
                    RedPotion_HealAmount = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Entities", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Entities_x_y",
                table: "Entities",
                columns: new[] { "x", "y" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Entities");
        }
    }
}
