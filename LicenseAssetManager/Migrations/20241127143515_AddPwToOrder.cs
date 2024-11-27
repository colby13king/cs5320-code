using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LicenseAssetManager.Migrations
{
    /// <inheritdoc />
    public partial class AddPwToOrder : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "PassWord",
                table: "Orders",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PassWord",
                table: "Orders");
        }
    }
}
