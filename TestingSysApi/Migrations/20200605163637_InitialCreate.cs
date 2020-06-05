using Microsoft.EntityFrameworkCore.Migrations;

namespace TestingSysApi.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Question",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    question = table.Column<string>(nullable: true),
                    answer1 = table.Column<string>(nullable: true),
                    answer2 = table.Column<string>(nullable: true),
                    answer3 = table.Column<string>(nullable: true),
                    answer4 = table.Column<string>(nullable: true),
                    true_answer = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Question", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Question",
                columns: new[] { "Id", "answer1", "answer2", "answer3", "answer4", "question", "true_answer" },
                values: new object[] { 1L, "Paris", "Rome", "London", "Berlin", "What's the capital of France?", 1 });

            migrationBuilder.InsertData(
                table: "Question",
                columns: new[] { "Id", "answer1", "answer2", "answer3", "answer4", "question", "true_answer" },
                values: new object[] { 2L, "Paris", "Rome", "London", "Berlin", "What's the capital of Italy?", 2 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Question");
        }
    }
}
