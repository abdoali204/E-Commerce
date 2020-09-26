using Microsoft.EntityFrameworkCore.Migrations;

namespace E_Commerce.Migrations
{
    public partial class SeedStores : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO stores values('Store1','Cairo')");
            migrationBuilder.Sql("INSERT INTO stores values('Store2','Giza')");
            migrationBuilder.Sql("INSERT INTO stores values('Store3','Alex')");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
