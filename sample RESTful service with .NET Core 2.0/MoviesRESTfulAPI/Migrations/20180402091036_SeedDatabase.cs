using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace MoviesRESTfulAPI.Migrations
{
    public partial class SeedDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO GENRES (Id,Name) VALUES (1,'Action')");
            migrationBuilder.Sql("INSERT INTO GENRES (Id,Name) VALUES (2,'Comedy')");
            migrationBuilder.Sql("INSERT INTO GENRES (Id,Name) VALUES (3,'Animation')");
            migrationBuilder.Sql("INSERT INTO GENRES (Id,Name) VALUES (4,'Thriller')");
            migrationBuilder.Sql("INSERT INTO GENRES (Id,Name) VALUES (5,'Drama')");
            migrationBuilder.Sql("INSERT INTO GENRES (Id,Name) VALUES (6,'Musical')");
            migrationBuilder.Sql("INSERT INTO GENRES (Id,Name) VALUES (7,'Horror')");
            migrationBuilder.Sql("INSERT INTO GENRES (Id,Name) VALUES (8,'Biography')");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE * FROM GENRES");
        }
    }
}
