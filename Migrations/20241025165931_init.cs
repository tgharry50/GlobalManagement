using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace GlobalManagement.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Application",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UUID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ApplicationName = table.Column<string>(name: "Application Name", type: "nvarchar(max)", nullable: false),
                    ApplicationDescription = table.Column<string>(name: "Application Description", type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Application", x => x.Id);
                    table.UniqueConstraint("AK_Application_UUID", x => x.UUID);
                });

            migrationBuilder.CreateTable(
                name: "ApplicationOptions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UUID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    App_UUID = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApplicationOptions", x => x.Id);
                    table.UniqueConstraint("AK_ApplicationOptions_UUID", x => x.UUID);
                });

            migrationBuilder.CreateTable(
                name: "ApplicationOwner",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UUID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    App_UUID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    User_UUID = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApplicationOwner", x => x.Id);
                    table.UniqueConstraint("AK_ApplicationOwner_UUID", x => x.UUID);
                });

            migrationBuilder.CreateTable(
                name: "ApplicationPermissions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UUID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    User_UUID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    App_Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    App_UUID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Role = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Role_UUID = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApplicationPermissions", x => x.Id);
                    table.UniqueConstraint("AK_ApplicationPermissions_UUID", x => x.UUID);
                });

            migrationBuilder.CreateTable(
                name: "ControlReportPermissions",
                columns: table => new
                {
                    UUID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Role_Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    App_Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    App_UUID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CanBeEdited = table.Column<bool>(type: "bit", nullable: false),
                    HasAllPrivelage = table.Column<bool>(type: "bit", nullable: false),
                    CanUseApp = table.Column<bool>(type: "bit", nullable: false),
                    CanCreateReference = table.Column<bool>(type: "bit", nullable: false),
                    CanDeleteReference = table.Column<bool>(type: "bit", nullable: false),
                    CanUpdateReference = table.Column<bool>(type: "bit", nullable: false),
                    CanReadReference = table.Column<bool>(type: "bit", nullable: false),
                    CanCreateIntervention = table.Column<bool>(type: "bit", nullable: false),
                    CanDeleteIntervention = table.Column<bool>(type: "bit", nullable: false),
                    CanUpdateIntervention = table.Column<bool>(type: "bit", nullable: false),
                    CanReadIntervention = table.Column<bool>(type: "bit", nullable: false),
                    CanCreateTask = table.Column<bool>(type: "bit", nullable: false),
                    CanDeleteTask = table.Column<bool>(type: "bit", nullable: false),
                    CanUpdateTask = table.Column<bool>(type: "bit", nullable: false),
                    CanReadTask = table.Column<bool>(type: "bit", nullable: false),
                    CanCreateECR = table.Column<bool>(type: "bit", nullable: false),
                    CanDeleteECR = table.Column<bool>(type: "bit", nullable: false),
                    CanUpdateECR = table.Column<bool>(type: "bit", nullable: false),
                    CanReadECR = table.Column<bool>(type: "bit", nullable: false),
                    CanCreateDeviation = table.Column<bool>(type: "bit", nullable: false),
                    CanDeleteDeviation = table.Column<bool>(type: "bit", nullable: false),
                    CanUpdateDeviation = table.Column<bool>(type: "bit", nullable: false),
                    CanReadDeviation = table.Column<bool>(type: "bit", nullable: false),
                    CanCreateGroup = table.Column<bool>(type: "bit", nullable: false),
                    CanDeleteGroup = table.Column<bool>(type: "bit", nullable: false),
                    CanUpdateGroup = table.Column<bool>(type: "bit", nullable: false),
                    CanReadGroup = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ControlReportPermissions", x => x.UUID);
                });

            migrationBuilder.CreateTable(
                name: "GlobalPermissions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UUID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Role_Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    App_Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    App_UUID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CanAccessGlobal = table.Column<bool>(type: "bit", nullable: false),
                    CanBeEdited = table.Column<bool>(type: "bit", nullable: false),
                    CreateUser = table.Column<bool>(type: "bit", nullable: false),
                    UpdateUser = table.Column<bool>(type: "bit", nullable: false),
                    DeleteUser = table.Column<bool>(type: "bit", nullable: false),
                    CreateCustomRole = table.Column<bool>(type: "bit", nullable: false),
                    UpdateCustomRole = table.Column<bool>(type: "bit", nullable: false),
                    DeleteCustomRole = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GlobalPermissions", x => x.Id);
                    table.UniqueConstraint("AK_GlobalPermissions_UUID", x => x.UUID);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UUID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(32)", maxLength: 32, nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(48)", maxLength: 48, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(48)", maxLength: 48, nullable: false),
                    FullName = table.Column<string>(type: "nvarchar(48)", maxLength: 48, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: false),
                    Card = table.Column<string>(type: "nvarchar(28)", maxLength: 28, nullable: false),
                    Pin = table.Column<int>(type: "int", maxLength: 16, nullable: false),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                    table.UniqueConstraint("AK_Users_UUID", x => x.UUID);
                });

            migrationBuilder.InsertData(
                table: "Application",
                columns: new[] { "Id", "Application Description", "Application Name", "UUID" },
                values: new object[,]
                {
                    { 1, "Application used to manage other applications and permission", "GlobalApp", new Guid("e1460990-542d-4142-8904-3c10d6a9d6e8") },
                    { 2, "Application used to manage reference, ecr, deviation", "ControlReport", new Guid("71c1b86a-9a7b-49c3-811d-1663f52ef980") }
                });

            migrationBuilder.InsertData(
                table: "ApplicationOptions",
                columns: new[] { "Id", "App_UUID", "UUID" },
                values: new object[,]
                {
                    { 1, new Guid("e1460990-542d-4142-8904-3c10d6a9d6e8"), new Guid("33da1720-c465-4da2-8fa7-36705e495402") },
                    { 2, new Guid("71c1b86a-9a7b-49c3-811d-1663f52ef980"), new Guid("fd2093b0-4123-4778-932b-4d2599c32a1c") }
                });

            migrationBuilder.InsertData(
                table: "ApplicationOwner",
                columns: new[] { "Id", "App_UUID", "UUID", "User_UUID" },
                values: new object[,]
                {
                    { 1, new Guid("e1460990-542d-4142-8904-3c10d6a9d6e8"), new Guid("337c6fbe-5e02-4a53-847a-37c0cb9bf298"), new Guid("fc1d498c-746d-4407-b004-394e03756c04") },
                    { 2, new Guid("71c1b86a-9a7b-49c3-811d-1663f52ef980"), new Guid("30eb0af9-9724-477c-beb3-43e5d236484a"), new Guid("71c1b86a-9a7b-49c3-811d-1663f52ef980") }
                });

            migrationBuilder.InsertData(
                table: "ApplicationPermissions",
                columns: new[] { "Id", "App_Name", "App_UUID", "Role", "Role_UUID", "UUID", "User_UUID" },
                values: new object[,]
                {
                    { 1, "GlobalApp", new Guid("e1460990-542d-4142-8904-3c10d6a9d6e8"), "Administrator", new Guid("13865aae-9987-43f9-96d7-0f5b92c67ba9"), new Guid("6532f398-fcf2-4c2e-8004-7d25a86161c4"), new Guid("fc1d498c-746d-4407-b004-394e03756c04") },
                    { 2, "ControlReport", new Guid("71c1b86a-9a7b-49c3-811d-1663f52ef980"), "Administrator", new Guid("f57c5777-e6b3-417d-8358-f38d062a3054"), new Guid("3a059cc5-2fa7-45e7-a8de-d1bde11b21bf"), new Guid("fc1d498c-746d-4407-b004-394e03756c04") }
                });

            migrationBuilder.InsertData(
                table: "ControlReportPermissions",
                columns: new[] { "UUID", "App_Name", "App_UUID", "CanBeEdited", "CanCreateDeviation", "CanCreateECR", "CanCreateGroup", "CanCreateIntervention", "CanCreateReference", "CanCreateTask", "CanDeleteDeviation", "CanDeleteECR", "CanDeleteGroup", "CanDeleteIntervention", "CanDeleteReference", "CanDeleteTask", "CanReadDeviation", "CanReadECR", "CanReadGroup", "CanReadIntervention", "CanReadReference", "CanReadTask", "CanUpdateDeviation", "CanUpdateECR", "CanUpdateGroup", "CanUpdateIntervention", "CanUpdateReference", "CanUpdateTask", "CanUseApp", "HasAllPrivelage", "Id", "Role_Name" },
                values: new object[,]
                {
                    { new Guid("397ede05-aaf9-4cfc-93ed-4a098fd8ae53"), "ControlReport", new Guid("71c1b86a-9a7b-49c3-811d-1663f52ef980"), false, false, false, false, false, false, false, false, false, false, false, false, false, true, true, true, true, true, true, false, false, false, false, false, false, true, false, 2, "User" },
                    { new Guid("f57c5777-e6b3-417d-8358-f38d062a3054"), "ControlReport", new Guid("71c1b86a-9a7b-49c3-811d-1663f52ef980"), false, true, true, true, true, true, true, false, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, 1, "Administrator" }
                });

            migrationBuilder.InsertData(
                table: "GlobalPermissions",
                columns: new[] { "Id", "App_Name", "App_UUID", "CanAccessGlobal", "CanBeEdited", "CreateCustomRole", "CreateUser", "DeleteCustomRole", "DeleteUser", "Role_Name", "UUID", "UpdateCustomRole", "UpdateUser" },
                values: new object[,]
                {
                    { 1, "GlobalApp", new Guid("e1460990-542d-4142-8904-3c10d6a9d6e8"), true, false, true, true, false, true, "Administrator", new Guid("13865aae-9987-43f9-96d7-0f5b92c67ba9"), false, true },
                    { 2, "GlobalApp", new Guid("e1460990-542d-4142-8904-3c10d6a9d6e8"), false, false, false, false, false, false, "User", new Guid("84b38df9-0e89-4301-bd01-70b5bb8bf52e"), false, false }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Card", "CreatedDate", "Email", "FirstName", "FullName", "Image", "IsActive", "LastName", "LastUpdatedDate", "Password", "Pin", "UUID", "UserName" },
                values: new object[] { 1, "1234", new DateTime(2024, 10, 25, 18, 59, 30, 928, DateTimeKind.Local).AddTicks(5934), "zyw2.automatyzacja@gmail.com", "admin", "admin admin", null, true, "admin", null, "$2a$11$1nRlsCp3dHz2zrGOl4kcDeGMJTUQ/Ei2ea65C/TUIm8IXvPUoBZWG", 1234, new Guid("fc1d498c-746d-4407-b004-394e03756c04"), "admin" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Application");

            migrationBuilder.DropTable(
                name: "ApplicationOptions");

            migrationBuilder.DropTable(
                name: "ApplicationOwner");

            migrationBuilder.DropTable(
                name: "ApplicationPermissions");

            migrationBuilder.DropTable(
                name: "ControlReportPermissions");

            migrationBuilder.DropTable(
                name: "GlobalPermissions");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
