﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Sagdeev_kt4220.Migrations
{
    /// <inheritdoc />
    public partial class CreateDatabase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "cd_doljnost",
                columns: table => new
                {
                    doljnost_id = table.Column<int>(type: "int", nullable: false, comment: "Идентификатор записи должности")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    c_doljnost_name = table.Column<string>(type: "nvarchar(Max)", maxLength: 100, nullable: false, comment: "Название должности")
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_cd_doljnost_doljnost_id", x => x.doljnost_id);
                });

            migrationBuilder.CreateTable(
                name: "cd_kafedra",
                columns: table => new
                {
                    kafedra_id = table.Column<int>(type: "int", nullable: false, comment: "Идентификатор записи кафедры")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    c_kafedra_name = table.Column<string>(type: "nvarchar(Max)", maxLength: 100, nullable: false, comment: "Название кафедры")
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_cd_kafedra_kafedra_id", x => x.kafedra_id);
                });

            migrationBuilder.CreateTable(
                name: "cd_stepen",
                columns: table => new
                {
                    stepen_id = table.Column<int>(type: "int", nullable: false, comment: "Идентификатор записи степени")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    c_stepen_name = table.Column<string>(type: "nvarchar(Max)", maxLength: 100, nullable: false, comment: "Название степени")
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_cd_stepen_stepen_id", x => x.stepen_id);
                });

            migrationBuilder.CreateTable(
                name: "cd_prepod",
                columns: table => new
                {
                    prepod_id = table.Column<int>(type: "int", nullable: false, comment: "Индетификатор записи преподавателя")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    c_prepod_firstname = table.Column<string>(type: "nvarchar(Max)", maxLength: 100, nullable: false, comment: "Имя преподавателя"),
                    c_prepod_lastname = table.Column<string>(type: "nvarchar(Max)", maxLength: 100, nullable: false, comment: "Фамилия преподавателя"),
                    c_prepod_middlename = table.Column<string>(type: "nvarchar(Max)", maxLength: 100, nullable: false, comment: "Отчество преподавателя"),
                    kafedra_id = table.Column<int>(type: "int", nullable: false, comment: "Индетификатор кафедры"),
                    stepen_id = table.Column<int>(type: "int", nullable: false, comment: "Индетификатор степени"),
                    doljnost_id = table.Column<int>(type: "int", nullable: false, comment: "Индетификатор кафедры")
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_cd_prepod_prepod_id", x => x.prepod_id);
                    table.ForeignKey(
                        name: "fk_f_doljnost_id",
                        column: x => x.doljnost_id,
                        principalTable: "cd_doljnost",
                        principalColumn: "doljnost_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_f_kafedra_id",
                        column: x => x.kafedra_id,
                        principalTable: "cd_kafedra",
                        principalColumn: "kafedra_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_f_stepen_id",
                        column: x => x.stepen_id,
                        principalTable: "cd_stepen",
                        principalColumn: "stepen_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "idx_cd_prepod_fk_f_stepen_id",
                table: "cd_prepod",
                column: "stepen_id");

            migrationBuilder.CreateIndex(
                name: "IX_cd_prepod_doljnost_id",
                table: "cd_prepod",
                column: "doljnost_id");

            migrationBuilder.CreateIndex(
                name: "IX_cd_prepod_kafedra_id",
                table: "cd_prepod",
                column: "kafedra_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "cd_prepod");

            migrationBuilder.DropTable(
                name: "cd_doljnost");

            migrationBuilder.DropTable(
                name: "cd_kafedra");

            migrationBuilder.DropTable(
                name: "cd_stepen");
        }
    }
}
