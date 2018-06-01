using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace OnTrak.Migrations
{
    public partial class ExercisesToMuscles : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BodyAreaId",
                table: "Exercises");

            migrationBuilder.DropColumn(
                name: "BodyPartId",
                table: "Exercises");

            migrationBuilder.DropColumn(
                name: "MuscleId",
                table: "Exercises");

            migrationBuilder.CreateTable(
                name: "ExercisesToMuscles",
                columns: table => new
                {
                    ExerciseId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    MuscleIdS = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExercisesToMuscles", x => x.ExerciseId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ExercisesToMuscles");

            migrationBuilder.AddColumn<int>(
                name: "BodyAreaId",
                table: "Exercises",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "BodyPartId",
                table: "Exercises",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "MuscleId",
                table: "Exercises",
                nullable: false,
                defaultValue: 0);
        }
    }
}
