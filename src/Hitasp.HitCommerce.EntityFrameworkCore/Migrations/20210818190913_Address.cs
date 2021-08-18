using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Hitasp.HitCommerce.Migrations
{
    public partial class Address : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CoreAddresses",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ContactName = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: false),
                    AddressLine1 = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: false),
                    AddressLine2 = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: true),
                    ZipOrPostalCode = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: true),
                    CountryId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    StateOrProvinceId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CityId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DistrictId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifierId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CoreAddresses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CoreAddresses_CoreCities_CityId",
                        column: x => x.CityId,
                        principalTable: "CoreCities",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_CoreAddresses_CoreCountries_CountryId",
                        column: x => x.CountryId,
                        principalTable: "CoreCountries",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_CoreAddresses_CoreDistricts_DistrictId",
                        column: x => x.DistrictId,
                        principalTable: "CoreDistricts",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_CoreAddresses_CoreStateOrProvinces_StateOrProvinceId",
                        column: x => x.StateOrProvinceId,
                        principalTable: "CoreStateOrProvinces",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_CoreAddresses_CityId",
                table: "CoreAddresses",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_CoreAddresses_CountryId",
                table: "CoreAddresses",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_CoreAddresses_DistrictId",
                table: "CoreAddresses",
                column: "DistrictId");

            migrationBuilder.CreateIndex(
                name: "IX_CoreAddresses_StateOrProvinceId",
                table: "CoreAddresses",
                column: "StateOrProvinceId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CoreAddresses");
        }
    }
}
