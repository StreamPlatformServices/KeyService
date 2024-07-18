using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KeyService.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Keys",
                columns: table => new
                {
                    Uuid = table.Column<Guid>(type: "TEXT", nullable: false),
                    FileId = table.Column<Guid>(type: "TEXT", nullable: false),
                    Key = table.Column<byte[]>(type: "BLOB", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Keys", x => x.Uuid);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Keys_FileId",
                table: "Keys",
                column: "FileId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Keys_Key",
                table: "Keys",
                column: "Key",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Keys");
        }
    }
}
