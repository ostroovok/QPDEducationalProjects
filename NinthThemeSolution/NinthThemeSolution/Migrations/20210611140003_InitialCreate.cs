using Microsoft.EntityFrameworkCore.Migrations;

namespace NinthThemeSolution.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AnecdotesRequests",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Message = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AnecdotesRequests", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Aphorisms",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Message = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Aphorisms", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ByePhrasesRequests",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Message = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ByePhrasesRequests", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "HelloPhrasesRequests",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Message = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HelloPhrasesRequests", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Anecdotes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Message = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AnecdoteRequestId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Anecdotes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Anecdotes_AnecdotesRequests_AnecdoteRequestId",
                        column: x => x.AnecdoteRequestId,
                        principalTable: "AnecdotesRequests",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ByePhrases",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Message = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ByePhraseRequestId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ByePhrases", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ByePhrases_ByePhrasesRequests_ByePhraseRequestId",
                        column: x => x.ByePhraseRequestId,
                        principalTable: "ByePhrasesRequests",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "HelloPhrases",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Message = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HelloPhraseRequestId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HelloPhrases", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HelloPhrases_HelloPhrasesRequests_HelloPhraseRequestId",
                        column: x => x.HelloPhraseRequestId,
                        principalTable: "HelloPhrasesRequests",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Anecdotes_AnecdoteRequestId",
                table: "Anecdotes",
                column: "AnecdoteRequestId");

            migrationBuilder.CreateIndex(
                name: "IX_ByePhrases_ByePhraseRequestId",
                table: "ByePhrases",
                column: "ByePhraseRequestId");

            migrationBuilder.CreateIndex(
                name: "IX_HelloPhrases_HelloPhraseRequestId",
                table: "HelloPhrases",
                column: "HelloPhraseRequestId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Anecdotes");

            migrationBuilder.DropTable(
                name: "Aphorisms");

            migrationBuilder.DropTable(
                name: "ByePhrases");

            migrationBuilder.DropTable(
                name: "HelloPhrases");

            migrationBuilder.DropTable(
                name: "AnecdotesRequests");

            migrationBuilder.DropTable(
                name: "ByePhrasesRequests");

            migrationBuilder.DropTable(
                name: "HelloPhrasesRequests");
        }
    }
}
