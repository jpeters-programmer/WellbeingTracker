using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Model.Postgres.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TrackingEntries",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TrackingEntries", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Password = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TrackingSetups",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    UserGuid = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TrackingSetups", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TrackingSetups_Users_UserGuid",
                        column: x => x.UserGuid,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Trackables",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    FieldType = table.Column<int>(type: "integer", nullable: false),
                    Inactive = table.Column<bool>(type: "boolean", nullable: false),
                    TrackingSetupId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Trackables", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Trackables_TrackingSetups_TrackingSetupId",
                        column: x => x.TrackingSetupId,
                        principalTable: "TrackingSetups",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TrackedItems",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    TrackableId = table.Column<Guid>(type: "uuid", nullable: true),
                    FieldValueJson = table.Column<string>(type: "text", nullable: false),
                    TrackingEntryId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TrackedItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TrackedItems_Trackables_TrackableId",
                        column: x => x.TrackableId,
                        principalTable: "Trackables",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TrackedItems_TrackingEntries_TrackingEntryId",
                        column: x => x.TrackingEntryId,
                        principalTable: "TrackingEntries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Trackables_TrackingSetupId",
                table: "Trackables",
                column: "TrackingSetupId");

            migrationBuilder.CreateIndex(
                name: "IX_TrackedItems_TrackableId",
                table: "TrackedItems",
                column: "TrackableId");

            migrationBuilder.CreateIndex(
                name: "IX_TrackedItems_TrackingEntryId",
                table: "TrackedItems",
                column: "TrackingEntryId");

            migrationBuilder.CreateIndex(
                name: "IX_TrackingSetups_UserGuid",
                table: "TrackingSetups",
                column: "UserGuid",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TrackedItems");

            migrationBuilder.DropTable(
                name: "Trackables");

            migrationBuilder.DropTable(
                name: "TrackingEntries");

            migrationBuilder.DropTable(
                name: "TrackingSetups");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
