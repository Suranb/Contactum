using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Contactum.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class ChangeModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Companies_Person_ContactPersonPersonId",
                table: "Companies");

            migrationBuilder.DropForeignKey(
                name: "FK_Companies_Person_OwnerPersonId",
                table: "Companies");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Companies",
                table: "Companies");

            migrationBuilder.RenameTable(
                name: "Companies",
                newName: "companies");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "companies",
                newName: "name");

            migrationBuilder.RenameColumn(
                name: "Description",
                table: "companies",
                newName: "description");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "companies",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "UpdatedAt",
                table: "companies",
                newName: "updated_at");

            migrationBuilder.RenameColumn(
                name: "OrganizationNumber",
                table: "companies",
                newName: "organization_number");

            migrationBuilder.RenameColumn(
                name: "CreatedAt",
                table: "companies",
                newName: "created_at");

            migrationBuilder.RenameColumn(
                name: "OwnerPersonId",
                table: "companies",
                newName: "person_id");

            migrationBuilder.RenameColumn(
                name: "ContactPersonPersonId",
                table: "companies",
                newName: "owner_id");

            migrationBuilder.RenameIndex(
                name: "IX_Companies_OwnerPersonId",
                table: "companies",
                newName: "IX_companies_person_id");

            migrationBuilder.RenameIndex(
                name: "IX_Companies_ContactPersonPersonId",
                table: "companies",
                newName: "IX_companies_owner_id");

            migrationBuilder.AlterColumn<string>(
                name: "name",
                table: "companies",
                type: "character varying(200)",
                maxLength: 200,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "description",
                table: "companies",
                type: "character varying(1000)",
                maxLength: 1000,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_companies",
                table: "companies",
                column: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_companies_Person_owner_id",
                table: "companies",
                column: "owner_id",
                principalTable: "Person",
                principalColumn: "PersonId");

            migrationBuilder.AddForeignKey(
                name: "FK_companies_Person_person_id",
                table: "companies",
                column: "person_id",
                principalTable: "Person",
                principalColumn: "PersonId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_companies_Person_owner_id",
                table: "companies");

            migrationBuilder.DropForeignKey(
                name: "FK_companies_Person_person_id",
                table: "companies");

            migrationBuilder.DropPrimaryKey(
                name: "PK_companies",
                table: "companies");

            migrationBuilder.RenameTable(
                name: "companies",
                newName: "Companies");

            migrationBuilder.RenameColumn(
                name: "name",
                table: "Companies",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "description",
                table: "Companies",
                newName: "Description");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "Companies",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "updated_at",
                table: "Companies",
                newName: "UpdatedAt");

            migrationBuilder.RenameColumn(
                name: "organization_number",
                table: "Companies",
                newName: "OrganizationNumber");

            migrationBuilder.RenameColumn(
                name: "created_at",
                table: "Companies",
                newName: "CreatedAt");

            migrationBuilder.RenameColumn(
                name: "person_id",
                table: "Companies",
                newName: "OwnerPersonId");

            migrationBuilder.RenameColumn(
                name: "owner_id",
                table: "Companies",
                newName: "ContactPersonPersonId");

            migrationBuilder.RenameIndex(
                name: "IX_companies_person_id",
                table: "Companies",
                newName: "IX_Companies_OwnerPersonId");

            migrationBuilder.RenameIndex(
                name: "IX_companies_owner_id",
                table: "Companies",
                newName: "IX_Companies_ContactPersonPersonId");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Companies",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(200)",
                oldMaxLength: 200);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Companies",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "character varying(1000)",
                oldMaxLength: 1000,
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Companies",
                table: "Companies",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Companies_Person_ContactPersonPersonId",
                table: "Companies",
                column: "ContactPersonPersonId",
                principalTable: "Person",
                principalColumn: "PersonId");

            migrationBuilder.AddForeignKey(
                name: "FK_Companies_Person_OwnerPersonId",
                table: "Companies",
                column: "OwnerPersonId",
                principalTable: "Person",
                principalColumn: "PersonId");
        }
    }
}
