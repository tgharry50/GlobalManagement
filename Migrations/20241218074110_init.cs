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
                    Uuid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ApplicationName = table.Column<string>(name: "Application Name", type: "nvarchar(max)", nullable: false),
                    ApplicationDescription = table.Column<string>(name: "Application Description", type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Application", x => x.Id);
                    table.UniqueConstraint("AK_Application_Uuid", x => x.Uuid);
                });

            migrationBuilder.CreateTable(
                name: "ApplicationOptions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Uuid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AppUuid = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApplicationOptions", x => x.Id);
                    table.UniqueConstraint("AK_ApplicationOptions_Uuid", x => x.Uuid);
                });

            migrationBuilder.CreateTable(
                name: "ApplicationOwner",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Uuid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AppUuid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserUuid = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApplicationOwner", x => x.Id);
                    table.UniqueConstraint("AK_ApplicationOwner_Uuid", x => x.Uuid);
                });

            migrationBuilder.CreateTable(
                name: "ApplicationPermissions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UUID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserUuid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AppName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AppUuid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Role = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RoleUuid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
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
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UUID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RoleName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AppName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AppUuid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
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
                    CanCreateEcr = table.Column<bool>(type: "bit", nullable: false),
                    CanDeleteEcr = table.Column<bool>(type: "bit", nullable: false),
                    CanUpdateEcr = table.Column<bool>(type: "bit", nullable: false),
                    CanReadEcr = table.Column<bool>(type: "bit", nullable: false),
                    CanCreateDeviation = table.Column<bool>(type: "bit", nullable: false),
                    CanDeleteDeviation = table.Column<bool>(type: "bit", nullable: false),
                    CanUpdateDeviation = table.Column<bool>(type: "bit", nullable: false),
                    CanReadDeviation = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ControlReportPermissions", x => x.Id);
                    table.UniqueConstraint("AK_ControlReportPermissions_UUID", x => x.UUID);
                });

            migrationBuilder.CreateTable(
                name: "GlobalPermissions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Uuid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RoleName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AppName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AppUuid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CanAccessGlobal = table.Column<bool>(type: "bit", nullable: false),
                    CanBeEdited = table.Column<bool>(type: "bit", nullable: false),
                    CreateUser = table.Column<bool>(type: "bit", nullable: false),
                    UpdateUser = table.Column<bool>(type: "bit", nullable: false),
                    DeleteUser = table.Column<bool>(type: "bit", nullable: false),
                    CreateCustomRole = table.Column<bool>(type: "bit", nullable: false),
                    UpdateCustomRole = table.Column<bool>(type: "bit", nullable: false),
                    DeleteCustomRole = table.Column<bool>(type: "bit", nullable: false),
                    CanCreateGroup = table.Column<bool>(type: "bit", nullable: false),
                    CanDeleteGroup = table.Column<bool>(type: "bit", nullable: false),
                    CanUpdateGroup = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GlobalPermissions", x => x.Id);
                    table.UniqueConstraint("AK_GlobalPermissions_Uuid", x => x.Uuid);
                });

            migrationBuilder.CreateTable(
                name: "GroupMembers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Uuid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    GroupName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GroupUUID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Username = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserGuid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Role = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RoleGuid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GroupMembers", x => x.Id);
                    table.UniqueConstraint("AK_GroupMembers_Uuid", x => x.Uuid);
                });

            migrationBuilder.CreateTable(
                name: "GroupPermissions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Uuid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    GroupName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GroupUuid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UsersCanAccessGlobalApp = table.Column<bool>(type: "bit", nullable: false),
                    UsersCanAccessReferenceHub = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GroupPermissions", x => x.Id);
                    table.UniqueConstraint("AK_GroupPermissions_Uuid", x => x.Uuid);
                });

            migrationBuilder.CreateTable(
                name: "GroupRole",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Uuid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    GroupName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GroupUuid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RoleName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsAdmin = table.Column<bool>(type: "bit", nullable: false),
                    CanModifyGroup = table.Column<bool>(type: "bit", nullable: false),
                    CanRemoveGroup = table.Column<bool>(type: "bit", nullable: false),
                    CanAddRoles = table.Column<bool>(type: "bit", nullable: false),
                    CanModifyRoles = table.Column<bool>(type: "bit", nullable: false),
                    CanRemoveRoles = table.Column<bool>(type: "bit", nullable: false),
                    IsRoleRemovable = table.Column<bool>(type: "bit", nullable: false),
                    CanAddUser = table.Column<bool>(type: "bit", nullable: false),
                    CanRemoveUser = table.Column<bool>(type: "bit", nullable: false),
                    CanModifyUser = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GroupRole", x => x.Id);
                    table.UniqueConstraint("AK_GroupRole_Uuid", x => x.Uuid);
                });

            migrationBuilder.CreateTable(
                name: "Groups",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Uuid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Hala = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Section = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Groups", x => x.Id);
                    table.UniqueConstraint("AK_Groups_Uuid", x => x.Uuid);
                });

            migrationBuilder.CreateTable(
                name: "Logs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Uuid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Class = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Message = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    End = table.Column<TimeSpan>(type: "time", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Logs", x => x.Id);
                    table.UniqueConstraint("AK_Logs_Uuid", x => x.Uuid);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Uuid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
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
                    table.UniqueConstraint("AK_Users_Uuid", x => x.Uuid);
                });

            migrationBuilder.InsertData(
                table: "Application",
                columns: new[] { "Id", "Address", "CreatedAt", "Application Description", "IsActive", "Application Name", "UpdatedAt", "Uuid" },
                values: new object[,]
                {
                    { 1, "10.35.92.163:3001", new DateTime(2024, 12, 18, 8, 41, 10, 206, DateTimeKind.Local).AddTicks(8820), "Application used to manage other applications and permission", true, "GlobalApp", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("899960d1-f610-4c7d-878e-b505b5fe7209") },
                    { 2, "10.35.92.163:2999", new DateTime(2024, 12, 18, 8, 41, 10, 206, DateTimeKind.Local).AddTicks(8883), "Application used to manage reference, ecr, deviation", true, "ControlReport", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("37f9aec4-3090-473d-a771-159a4bee8c47") }
                });

            migrationBuilder.InsertData(
                table: "ApplicationOptions",
                columns: new[] { "Id", "AppUuid", "Uuid" },
                values: new object[,]
                {
                    { 1, new Guid("899960d1-f610-4c7d-878e-b505b5fe7209"), new Guid("77847e48-76c5-498f-8b96-615323e5b66b") },
                    { 2, new Guid("37f9aec4-3090-473d-a771-159a4bee8c47"), new Guid("b43613ac-688a-4daf-b00a-b7a832a24d85") }
                });

            migrationBuilder.InsertData(
                table: "ApplicationOwner",
                columns: new[] { "Id", "AppUuid", "UserUuid", "Uuid" },
                values: new object[,]
                {
                    { 1, new Guid("899960d1-f610-4c7d-878e-b505b5fe7209"), new Guid("231811de-77b8-4637-9118-c6544126b68b"), new Guid("9daa8368-c34d-491f-bca9-9e8171013f74") },
                    { 2, new Guid("37f9aec4-3090-473d-a771-159a4bee8c47"), new Guid("37f9aec4-3090-473d-a771-159a4bee8c47"), new Guid("3be46db9-8644-4007-addb-b92f66743b98") }
                });

            migrationBuilder.InsertData(
                table: "ApplicationPermissions",
                columns: new[] { "Id", "AppName", "AppUuid", "CreatedAt", "Role", "RoleUuid", "UUID", "UpdatedAt", "UserUuid" },
                values: new object[,]
                {
                    { 1, "GlobalApp", new Guid("899960d1-f610-4c7d-878e-b505b5fe7209"), new DateTime(2024, 12, 18, 8, 41, 10, 379, DateTimeKind.Local).AddTicks(2704), "Administrator", new Guid("02cc50eb-c871-41e0-87b0-b44c8d4a00d5"), new Guid("f0d6b5ef-b86a-4ddf-ae05-fe20fbf23577"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("231811de-77b8-4637-9118-c6544126b68b") },
                    { 2, "ControlReport", new Guid("37f9aec4-3090-473d-a771-159a4bee8c47"), new DateTime(2024, 12, 18, 8, 41, 10, 379, DateTimeKind.Local).AddTicks(2784), "Administrator", new Guid("e12d1ec2-9904-40aa-be78-748198ba8a79"), new Guid("91e1a274-4c7c-4cb8-b0f3-7eb3e7cb8035"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("231811de-77b8-4637-9118-c6544126b68b") }
                });

            migrationBuilder.InsertData(
                table: "ControlReportPermissions",
                columns: new[] { "Id", "AppName", "AppUuid", "CanBeEdited", "CanCreateDeviation", "CanCreateEcr", "CanCreateIntervention", "CanCreateReference", "CanCreateTask", "CanDeleteDeviation", "CanDeleteEcr", "CanDeleteIntervention", "CanDeleteReference", "CanDeleteTask", "CanReadDeviation", "CanReadEcr", "CanReadIntervention", "CanReadReference", "CanReadTask", "CanUpdateDeviation", "CanUpdateEcr", "CanUpdateIntervention", "CanUpdateReference", "CanUpdateTask", "CanUseApp", "HasAllPrivelage", "RoleName", "UUID" },
                values: new object[,]
                {
                    { 1, "ControlReport", new Guid("37f9aec4-3090-473d-a771-159a4bee8c47"), false, true, true, true, true, true, false, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, "Administrator", new Guid("e12d1ec2-9904-40aa-be78-748198ba8a79") },
                    { 2, "ControlReport", new Guid("37f9aec4-3090-473d-a771-159a4bee8c47"), false, false, false, false, false, false, false, false, false, false, false, true, true, true, true, true, false, false, false, false, false, true, false, "User", new Guid("896a0c71-e219-47aa-8b99-78090f1bcffa") }
                });

            migrationBuilder.InsertData(
                table: "GlobalPermissions",
                columns: new[] { "Id", "AppName", "AppUuid", "CanAccessGlobal", "CanBeEdited", "CanCreateGroup", "CanDeleteGroup", "CanUpdateGroup", "CreateCustomRole", "CreateUser", "DeleteCustomRole", "DeleteUser", "RoleName", "UpdateCustomRole", "UpdateUser", "Uuid" },
                values: new object[,]
                {
                    { 1, "GlobalApp", new Guid("899960d1-f610-4c7d-878e-b505b5fe7209"), true, false, true, true, true, true, true, true, true, "Administrator", true, true, new Guid("02cc50eb-c871-41e0-87b0-b44c8d4a00d5") },
                    { 2, "GlobalApp", new Guid("899960d1-f610-4c7d-878e-b505b5fe7209"), false, false, false, false, false, false, false, false, false, "User", false, false, new Guid("cddb4738-26c8-4792-9950-e250dcde45b7") }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Card", "CreatedDate", "Email", "FirstName", "FullName", "Image", "IsActive", "LastName", "LastUpdatedDate", "Password", "Pin", "UserName", "Uuid" },
                values: new object[] { 1, "1234", new DateTime(2024, 12, 18, 8, 41, 10, 207, DateTimeKind.Local).AddTicks(1389), "zyw2.automatyzacja@gmail.com", "admin", "admin admin", null, true, "admin", null, "$2a$11$vY11dmT920AhDeXUW.bLW.hlkHu3br/vwj.Ayu28GMouE9/XoFACu", 1234, "admin", new Guid("231811de-77b8-4637-9118-c6544126b68b") });
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
                name: "GroupMembers");

            migrationBuilder.DropTable(
                name: "GroupPermissions");

            migrationBuilder.DropTable(
                name: "GroupRole");

            migrationBuilder.DropTable(
                name: "Groups");

            migrationBuilder.DropTable(
                name: "Logs");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
