using Microsoft.EntityFrameworkCore.Migrations;

namespace E_Commerce.Migrations
{
    public partial class SeedPaymentShipping : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("Insert Into Payment Values(50,'05-05-2020')");
            migrationBuilder.Sql("Insert Into Payment Values(70,'05-05-2020')");

            migrationBuilder.Sql("Insert Into Address Values('helwan','helwan','helwan','caio','helwan','13256')");

            migrationBuilder.Sql("Insert into Shipping Values('car',50,(Select id FROM Address WHERE line1 = 'helwan'))");


        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
