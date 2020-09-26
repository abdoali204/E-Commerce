using Microsoft.EntityFrameworkCore.Migrations;

namespace E_Commerce.Migrations
{
    public partial class Seed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("Insert Into ProductCategory Values ('Cat1')");
            migrationBuilder.Sql("Insert Into ProductCategory Values ('Cat2')");
            migrationBuilder.Sql("Insert Into ProductCategory Values ('Cat3')");


            migrationBuilder.Sql("Insert Into Products Values ('Product1',50,'Description',(SELECT ID From ProductCategory Where Name = 'Cat1'))");
            migrationBuilder.Sql("Insert Into Products Values ('Product2',60,'Description',(SELECT ID From ProductCategory Where Name = 'Cat1'))");
            migrationBuilder.Sql("Insert Into Products Values ('Product3',70,'Description',(SELECT ID From ProductCategory Where Name = 'Cat1'))");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("Delete From ProductCategory Where Name IN ('Cat1','Cat2','Cat3')");
        }
    }
}
