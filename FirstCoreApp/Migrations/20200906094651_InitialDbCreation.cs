using Microsoft.EntityFrameworkCore.Migrations;

namespace FirstCoreApp.Migrations
{
    public partial class InitialDbCreation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Books",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(nullable: false),
                    Author = table.Column<string>(nullable: false),
                    Description = table.Column<string>(nullable: false),
                    Language = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Books", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "Id", "Author", "Description", "Language", "Title" },
                values: new object[] { 1, "JK Rowling", "Nonumy mazim magna eum duis id dolore tempor vero eirmod sed dolor at aliquyam ullamcorper justo duo duo takimata labore amet nihil eos eirmod elitr sed eu augue nonumy elitr eu ut lorem eos velit ea facilisi lorem justo autem eu stet consectetuer justo et ea invidunt vero amet lorem", 0, "Harry Potter 1" });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "Id", "Author", "Description", "Language", "Title" },
                values: new object[] { 2, "Stephen King", "Iriure doming gubergren exerci tempor quis justo in nobis exerci diam iusto dolor labore velit takimata dolor invidunt dolor vel aliquyam rebum rebum dolor ea lorem ea lorem consequat diam nonumy vel clita invidunt dolore eirmod at voluptua invidunt at erat aliquyam accusam erat tempor consetetur eos autem congue luptatum", 3, "IT" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Books");
        }
    }
}
