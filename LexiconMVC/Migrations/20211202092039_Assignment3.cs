using Microsoft.EntityFrameworkCore.Migrations;

namespace LexiconMVCData.Migrations
{
    public partial class Assignment3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Countries",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Countries", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Languages",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Languages", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Cities",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    CountryId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cities", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Cities_Countries_CountryId",
                        column: x => x.CountryId,
                        principalTable: "Countries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "People",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    CityId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_People", x => x.Id);
                    table.ForeignKey(
                        name: "FK_People_Cities_CityId",
                        column: x => x.CityId,
                        principalTable: "Cities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PersonLanguages",
                columns: table => new
                {
                    PersonId = table.Column<int>(nullable: false),
                    LanguageId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersonLanguages", x => new { x.PersonId, x.LanguageId });
                    table.ForeignKey(
                        name: "FK_PersonLanguages_Languages_LanguageId",
                        column: x => x.LanguageId,
                        principalTable: "Languages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PersonLanguages_People_PersonId",
                        column: x => x.PersonId,
                        principalTable: "People",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Sverige" },
                    { 2, "Norge" },
                    { 3, "Danmark" }
                });

            migrationBuilder.InsertData(
                table: "Languages",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Svenska" },
                    { 2, "Norska" },
                    { 3, "Danska" }
                });

            migrationBuilder.InsertData(
                table: "Cities",
                columns: new[] { "Id", "CountryId", "Name" },
                values: new object[,]
                {
                    { 1, 1, "Göteborg" },
                    { 2, 1, "Malmö" },
                    { 3, 1, "Stockholm" },
                    { 4, 2, "Oslo" },
                    { 5, 2, "Bergen" },
                    { 6, 2, "Trondheim" },
                    { 7, 3, "Köpenhamn" },
                    { 8, 3, "Ålborg" },
                    { 9, 3, "Helsingör" }
                });

            migrationBuilder.InsertData(
                table: "People",
                columns: new[] { "Id", "CityId", "Name", "PhoneNumber" },
                values: new object[,]
                {
                    { 1, 1, "Adam Adamsson", "031-123456" },
                    { 23, 8, "Kim Larsen", "031-123456" },
                    { 20, 8, "Iben Hjejle", "031-123456" },
                    { 22, 7, "Kristian Tyrann", "031-123456" },
                    { 19, 7, "Nikolaj Coster-Waldau", "031-123456" },
                    { 18, 6, "Max manus", "031-123456" },
                    { 15, 6, "Theres Johaug", "031-123456" },
                    { 17, 5, "Fleksnes", "031-123456" },
                    { 14, 5, "Petter Northug", "031-123456" },
                    { 16, 4, "Gunn-Rita Dahle Flesjå", "031-123456" },
                    { 13, 4, "Ole Bramserud", "031-123456" },
                    { 12, 3, "Lars Larsson", "031-123456" },
                    { 9, 3, "Ivar Ivarsson", "031-123456" },
                    { 6, 3, "Frans Fransson", "031-123456" },
                    { 3, 3, "Carl Carlsson", "031-123456" },
                    { 11, 2, "Karl Karlsson", "031-123456" },
                    { 8, 2, "Henrik Henriksson", "031-123456" },
                    { 5, 2, "Erik Eriksson", "031-123456" },
                    { 2, 2, "Bertil Bertilsson", "031-123456" },
                    { 10, 1, "Jan Jansson", "031-123456" },
                    { 7, 1, "Gustav Gustavsson", "031-123456" },
                    { 4, 1, "Dan Danielsson", "031-123456" },
                    { 21, 9, "Mads Mikkelsen", "031-123456" },
                    { 24, 9, "Tycho Brahe", "031-123456" }
                });

            migrationBuilder.InsertData(
                table: "PersonLanguages",
                columns: new[] { "PersonId", "LanguageId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 21, 3 },
                    { 23, 2 },
                    { 23, 3 },
                    { 20, 3 },
                    { 22, 3 },
                    { 19, 3 },
                    { 18, 2 },
                    { 15, 2 },
                    { 17, 3 },
                    { 17, 2 },
                    { 14, 1 },
                    { 14, 2 },
                    { 16, 2 },
                    { 13, 2 },
                    { 12, 1 },
                    { 9, 1 },
                    { 6, 1 },
                    { 3, 3 },
                    { 3, 1 },
                    { 11, 1 },
                    { 8, 1 },
                    { 5, 1 },
                    { 2, 1 },
                    { 10, 3 },
                    { 10, 1 },
                    { 7, 2 },
                    { 7, 1 },
                    { 4, 1 },
                    { 1, 2 },
                    { 21, 1 },
                    { 24, 3 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cities_CountryId",
                table: "Cities",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_People_CityId",
                table: "People",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_PersonLanguages_LanguageId",
                table: "PersonLanguages",
                column: "LanguageId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PersonLanguages");

            migrationBuilder.DropTable(
                name: "Languages");

            migrationBuilder.DropTable(
                name: "People");

            migrationBuilder.DropTable(
                name: "Cities");

            migrationBuilder.DropTable(
                name: "Countries");
        }
    }
}
