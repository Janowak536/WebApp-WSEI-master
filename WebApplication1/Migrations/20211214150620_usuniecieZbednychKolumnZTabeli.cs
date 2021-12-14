using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApplication1.Migrations
{
    public partial class usuniecieZbednychKolumnZTabeli : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Nazwisko2",
                table: "Student",
                newName: "DrugieImie");

            migrationBuilder.AddColumn<string>(
                name: "AdresZamieszkania",
                table: "Student",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AdresZamieszkania",
                table: "Student");

            migrationBuilder.RenameColumn(
                name: "DrugieImie",
                table: "Student",
                newName: "Nazwisko2");
        }
    }
}
