using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MarsThreeSite.Migrations
{
    public partial class MigratePage : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pages_PageIdentity_PageIdId",
                table: "Pages");

            migrationBuilder.DropTable(
                name: "PageIdentity");

            migrationBuilder.RenameColumn(
                name: "PageIdId",
                table: "Pages",
                newName: "ChapiterId");

            migrationBuilder.RenameColumn(
                name: "PageAdress",
                table: "Pages",
                newName: "Name");

            migrationBuilder.RenameIndex(
                name: "IX_Pages_PageIdId",
                table: "Pages",
                newName: "IX_Pages_ChapiterId");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "Pages",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int))
                .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn)
                .OldAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AlterColumn<int>(
                name: "ChapiterId",
                table: "Pages",
                nullable: true,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Address",
                table: "Pages",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "Number",
                table: "Pages",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "Published",
                table: "Pages",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "isDeleted",
                table: "Pages",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateTable(
                name: "Chapiters",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Number = table.Column<int>(type: "integer", nullable: false),
                    Name = table.Column<string>(nullable: true),
                    isDeleted = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Chapiters", x => x.Id);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Pages_Chapiters_ChapiterId",
                table: "Pages",
                column: "ChapiterId",
                principalTable: "Chapiters",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pages_Chapiters_ChapiterId",
                table: "Pages");

            migrationBuilder.DropTable(
                name: "Chapiters");

            migrationBuilder.DropColumn(
                name: "Address",
                table: "Pages");

            migrationBuilder.DropColumn(
                name: "Number",
                table: "Pages");

            migrationBuilder.DropColumn(
                name: "Published",
                table: "Pages");

            migrationBuilder.DropColumn(
                name: "isDeleted",
                table: "Pages");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Pages",
                newName: "PageAdress");

            migrationBuilder.RenameColumn(
                name: "ChapiterId",
                table: "Pages",
                newName: "PageIdId");

            migrationBuilder.RenameIndex(
                name: "IX_Pages_ChapiterId",
                table: "Pages",
                newName: "IX_Pages_PageIdId");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "Pages",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer")
                .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn)
                .OldAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AlterColumn<int>(
                name: "PageIdId",
                table: "Pages",
                nullable: true,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "PageIdentity",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    PageNumber = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PageIdentity", x => x.Id);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Pages_PageIdentity_PageIdId",
                table: "Pages",
                column: "PageIdId",
                principalTable: "PageIdentity",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
