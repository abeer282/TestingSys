using Microsoft.EntityFrameworkCore.Migrations;

namespace TestingSysApi.Migrations.Test
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Test",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    number_of_questions = table.Column<int>(nullable: false),
                    is_choice_random = table.Column<bool>(nullable: false),
                    questions = table.Column<string>(nullable: true),
                    pass_questions_number = table.Column<int>(nullable: false),
                    has_time = table.Column<bool>(nullable: false),
                    time_in_seconds = table.Column<int>(nullable: false),
                    can_review = table.Column<bool>(nullable: false),
                    time_of_review = table.Column<int>(nullable: false),
                    can_move_back = table.Column<bool>(nullable: false),
                    answers = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Test", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Test",
                columns: new[] { "Id", "answers", "can_move_back", "can_review", "has_time", "is_choice_random", "number_of_questions", "pass_questions_number", "questions", "time_in_seconds", "time_of_review" },
                values: new object[] { 1L, "", true, false, true, true, 3, 2, "1#2#3#", 600, 0 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Test");
        }
    }
}
