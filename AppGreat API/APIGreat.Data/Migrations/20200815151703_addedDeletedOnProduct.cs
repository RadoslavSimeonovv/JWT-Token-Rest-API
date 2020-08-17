using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AppGreat.Data.Migrations
{
    public partial class addedDeletedOnProduct : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedOn",
                table: "Products",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DeletedOn",
                table: "Products");
        }
    }
}
