using Microsoft.EntityFrameworkCore.Migrations;

namespace E_Commerce.Migrations
{
    public partial class clearDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("Delete From ProductCategory Where Name IN ('Cat1','Cat2','Cat3')");     
            migrationBuilder.Sql("Delete FROM materials");
            migrationBuilder.Sql("Delete FROM photos");
            migrationBuilder.Sql("DELETE From products");
        }
    }
}
