using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FortisGroup.DATABASE.Migrations
{
    /// <inheritdoc />
    public partial class D1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CategoryTB",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CategoryTB", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "ItemTB",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CategoryID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItemTB", x => x.ID);
                    table.ForeignKey(
                        name: "FK_ItemTB_CategoryTB_CategoryID",
                        column: x => x.CategoryID,
                        principalTable: "CategoryTB",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_ItemTB_CategoryID",
                table: "ItemTB",
                column: "CategoryID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ItemTB");

            migrationBuilder.DropTable(
                name: "CategoryTB");
        }
    }
}
