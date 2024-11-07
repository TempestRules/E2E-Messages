using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DatabaseMigrations.Migrations
{
    /// <inheritdoc />
    public partial class UpdateAppUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "04df313a-8386-41fd-864a-9b60fd4c78ab");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c286153f-4e6a-4571-ba3b-3723aeb9eda5");

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "AspNetUsers",
                type: "character varying(256)",
                maxLength: 256,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "character varying(256)",
                oldMaxLength: 256);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "023ba7e2-849c-49b2-a227-af347433b30b", null, "Admin", "ADMIN" },
                    { "1dc07574-b226-4a0c-93f3-4b7ce09be776", null, "User", "USER" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "023ba7e2-849c-49b2-a227-af347433b30b");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1dc07574-b226-4a0c-93f3-4b7ce09be776");

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "AspNetUsers",
                type: "character varying(256)",
                maxLength: 256,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "character varying(256)",
                oldMaxLength: 256,
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "04df313a-8386-41fd-864a-9b60fd4c78ab", null, "Admin", "ADMIN" },
                    { "c286153f-4e6a-4571-ba3b-3723aeb9eda5", null, "User", "USER" }
                });
        }
    }
}
