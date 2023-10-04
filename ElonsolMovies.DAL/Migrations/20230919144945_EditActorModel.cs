using Microsoft.EntityFrameworkCore.Migrations;

namespace ElonsolMovies.DAL.Migrations
{
    public partial class EditActorModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ActorImage",
                table: "Actors",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Biography",
                table: "Actors",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ActorImage",
                table: "Actors");

            migrationBuilder.DropColumn(
                name: "Biography",
                table: "Actors");
        }
    }
}
