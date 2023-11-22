using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HealHub.Migrations
{
    /// <inheritdoc />
    public partial class segundoBanco : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Forms",
                columns: table => new
                {
                    id = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    userId = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    age = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    weight = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    height = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    symptoms = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    duration = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    diseaseHistory = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Forms", x => x.id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Forms");
        }
    }
}
