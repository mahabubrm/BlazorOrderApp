using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OrderApp.DAL.Migrations
{
    /// <inheritdoc />
    public partial class initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    OrderId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrderName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OrderState = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.OrderId);
                });

            migrationBuilder.CreateTable(
                name: "OrderWindows",
                columns: table => new
                {
                    WindowId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrderId = table.Column<int>(type: "int", nullable: false),
                    WindowName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    QuantityOfWindow = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderWindows", x => x.WindowId);
                    table.ForeignKey(
                        name: "FK_OrderWindows_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "OrderId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OrderWindowDetails",
                columns: table => new
                {
                    WindowDetailsId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrderWindowId = table.Column<int>(type: "int", nullable: false),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Width = table.Column<int>(type: "int", nullable: false),
                    Height = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderWindowDetails", x => x.WindowDetailsId);
                    table.ForeignKey(
                        name: "FK_OrderWindowDetails_OrderWindows_OrderWindowId",
                        column: x => x.OrderWindowId,
                        principalTable: "OrderWindows",
                        principalColumn: "WindowId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_OrderWindowDetails_OrderWindowId",
                table: "OrderWindowDetails",
                column: "OrderWindowId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderWindows_OrderId",
                table: "OrderWindows",
                column: "OrderId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OrderWindowDetails");

            migrationBuilder.DropTable(
                name: "OrderWindows");

            migrationBuilder.DropTable(
                name: "Orders");
        }
    }
}
