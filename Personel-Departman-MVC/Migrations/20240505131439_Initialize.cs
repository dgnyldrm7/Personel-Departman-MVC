using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Personel_Departman_MVC.Migrations
{
    /// <inheritdoc />
    public partial class Initialize : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Departmans",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DepartmanName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DepartmanDescription = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Departmans", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Personels",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    lName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ConfirmPassword = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DepartmanId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Personels", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Personels_Departmans_DepartmanId",
                        column: x => x.DepartmanId,
                        principalTable: "Departmans",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Departmans",
                columns: new[] { "Id", "DepartmanDescription", "DepartmanName" },
                values: new object[,]
                {
                    { 1, "Marketing Departman", "Marketing" },
                    { 2, "Finance Departman", "Finance" }
                });

            migrationBuilder.InsertData(
                table: "Personels",
                columns: new[] { "Id", "ConfirmPassword", "DepartmanId", "Email", "Name", "Password", "lName" },
                values: new object[,]
                {
                    { 1, "123*", 1, "dgn@test.com", "Dogan", "123*", "Yildirim" },
                    { 2, "dgn@test.com", 1, "dgn@test.com", "Dogan", "123456", "Yildirim" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Personels_DepartmanId",
                table: "Personels",
                column: "DepartmanId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Personels");

            migrationBuilder.DropTable(
                name: "Departmans");
        }
    }
}
