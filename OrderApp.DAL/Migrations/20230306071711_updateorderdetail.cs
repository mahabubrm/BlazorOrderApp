using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OrderApp.DAL.Migrations
{
    /// <inheritdoc />
    public partial class updateorderdetail : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ElementNo",
                table: "OrderWindowDetails",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ElementNo",
                table: "OrderWindowDetails");
        }
    }
}
