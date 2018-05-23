using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace OnTrak.Migrations
{
    public partial class BodyArea : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_BodyParts",
                table: "BodyParts");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "BodyParts");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "BodyAreas",
                newName: "BodyAreaId");

            migrationBuilder.AlterColumn<int>(
                name: "NumberOfMuscles",
                table: "BodyParts",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "BodyAreaId",
                table: "BodyParts",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "BodyPartId",
                table: "BodyParts",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AddPrimaryKey(
                name: "PK_BodyParts",
                table: "BodyParts",
                column: "BodyPartId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_BodyParts",
                table: "BodyParts");

            migrationBuilder.DropColumn(
                name: "BodyPartId",
                table: "BodyParts");

            migrationBuilder.RenameColumn(
                name: "BodyAreaId",
                table: "BodyAreas",
                newName: "Id");

            migrationBuilder.AlterColumn<int>(
                name: "NumberOfMuscles",
                table: "BodyParts",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "BodyAreaId",
                table: "BodyParts",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "BodyParts",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AddPrimaryKey(
                name: "PK_BodyParts",
                table: "BodyParts",
                column: "Id");
        }
    }
}
