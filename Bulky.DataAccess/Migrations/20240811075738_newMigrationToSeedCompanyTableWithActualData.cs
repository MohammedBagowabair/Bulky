using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Bulky.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class newMigrationToSeedCompanyTableWithActualData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Companies",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "City", "Name", "PhoneNumber", "PostalCode", "State", "StreetAddress" },
                values: new object[] { "Tech City", "Tech Solution", "6669990000", "12121", "IL", "123 Tech St" });

            migrationBuilder.UpdateData(
                table: "Companies",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "City", "Name", "PhoneNumber", "PostalCode", "State", "StreetAddress" },
                values: new object[] { "Vid City", "Vivid Books", "7779990000", "66666", "IL", "999 Vid St" });

            migrationBuilder.UpdateData(
                table: "Companies",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "City", "Name", "PhoneNumber", "PostalCode", "State", "StreetAddress" },
                values: new object[] { "Lala land", "Readers Club", "1113335555", "99999", "NY", "999 Main St" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Companies",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "City", "Name", "PhoneNumber", "PostalCode", "State", "StreetAddress" },
                values: new object[] { "", "Company 1", "", "", "", "" });

            migrationBuilder.UpdateData(
                table: "Companies",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "City", "Name", "PhoneNumber", "PostalCode", "State", "StreetAddress" },
                values: new object[] { "", "Company 2", "", "", "", "" });

            migrationBuilder.UpdateData(
                table: "Companies",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "City", "Name", "PhoneNumber", "PostalCode", "State", "StreetAddress" },
                values: new object[] { "", "Company 3", "", "", "", "" });
        }
    }
}
