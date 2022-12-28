using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace today.Migrations.DbFactoriesToCustomer
{
    /// <inheritdoc />
    public partial class MyMigration3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "GroupCustomers",
                columns: table => new
                {
                    groupCode = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    groupName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    customerId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GroupCustomers", x => x.groupCode);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GroupCustomers");
        }
    }
}
