using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication1.Migrations.NZWalksAuthDb
{
    /// <inheritdoc />
    public partial class CreatingAuthDatabaseFix : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3d2009c7-4919-4839-a954-af6bb009f6e8",
                column: "NormalizedName",
                value: "WRITER");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3d2009c7-4919-4839-a954-af6bb009f6e8",
                column: "NormalizedName",
                value: "WRİTER");
        }
    }
}
