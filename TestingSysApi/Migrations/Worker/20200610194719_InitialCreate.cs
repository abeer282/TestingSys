using Microsoft.EntityFrameworkCore.Migrations;

namespace TestingSysApi.Migrations.Worker
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Worker",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    fname = table.Column<string>(nullable: true),
                    lname = table.Column<string>(nullable: true),
                    email = table.Column<string>(nullable: true),
                    did_test = table.Column<bool>(nullable: false),
                    pass_test = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Worker", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Worker",
                columns: new[] { "Id", "did_test", "email", "fname", "lname", "pass_test" },
                values: new object[] { 6L, false, "bob@green.com", "Bob", "Green", false });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Worker");
        }
    }
}
