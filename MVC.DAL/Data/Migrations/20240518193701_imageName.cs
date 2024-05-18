using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MVC.DAL.Data.Migrations
{
    /// <inheritdoc />
    public partial class imageName : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ImgName",
                table: "Employees",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImgName",
                table: "Employees");
        }
    }
}
