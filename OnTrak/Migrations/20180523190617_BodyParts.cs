using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace OnTrak.Migrations
{
    public partial class BodyParts : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NumberOfMuscles",
                table: "BodyParts");

            migrationBuilder.DropColumn(
                name: "NumberOfParts",
                table: "BodyAreas");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "NumberOfMuscles",
                table: "BodyParts",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "NumberOfParts",
                table: "BodyAreas",
                nullable: false,
                defaultValue: 0);
        }
    }
}
