using Microsoft.EntityFrameworkCore.Migrations;

namespace Et.Yhy.Migrations
{
    public partial class NEWmigration0001null : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AbpUsers_Complays_ComplaysId",
                table: "AbpUsers");

            migrationBuilder.AlterColumn<int>(
                name: "ComplaysId",
                table: "AbpUsers",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_AbpUsers_Complays_ComplaysId",
                table: "AbpUsers",
                column: "ComplaysId",
                principalSchema: "Yhy",
                principalTable: "Complays",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AbpUsers_Complays_ComplaysId",
                table: "AbpUsers");

            migrationBuilder.AlterColumn<int>(
                name: "ComplaysId",
                table: "AbpUsers",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_AbpUsers_Complays_ComplaysId",
                table: "AbpUsers",
                column: "ComplaysId",
                principalSchema: "Yhy",
                principalTable: "Complays",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
