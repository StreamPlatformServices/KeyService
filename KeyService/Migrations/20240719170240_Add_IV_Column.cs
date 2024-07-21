using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KeyService.Migrations
{
    /// <inheritdoc />
    public partial class Add_IV_Column : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<byte[]>(
                name: "IV",
                table: "Keys",
                type: "BLOB",
                nullable: false,
                defaultValue: new byte[0]);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IV",
                table: "Keys");
        }
    }
}
