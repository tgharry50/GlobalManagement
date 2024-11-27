using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace GlobalManagement.Migrations
{
    /// <inheritdoc />
    public partial class init2 : Migration
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
                    { 1, "10.35.92.163:3001", new DateTime(2024, 11, 26, 7, 46, 24, 425, DateTimeKind.Local).AddTicks(6615), "Application used to manage other applications and permission", true, "GlobalApp", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("108ca102-9d1f-4942-828c-01f2ed7b012b") },
                    { 2, "10.35.92.163:2999", new DateTime(2024, 11, 26, 7, 46, 24, 425, DateTimeKind.Local).AddTicks(6675), "Application used to manage reference, ecr, deviation", true, "ControlReport", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("1b2112ae-a6e3-4dec-b0e0-d324a55e34e0") }
                });

            migrationBuilder.InsertData(
                table: "ApplicationOptions",
                columns: new[] { "Id", "AppUuid", "Uuid" },
                values: new object[,]
                {
                    { 1, new Guid("108ca102-9d1f-4942-828c-01f2ed7b012b"), new Guid("ed530d86-1120-41c4-9796-bbf251c2e3e1") },
                    { 2, new Guid("1b2112ae-a6e3-4dec-b0e0-d324a55e34e0"), new Guid("b160f091-6b47-40d8-8510-7e6ff34cc19c") }
                });

            migrationBuilder.InsertData(
                table: "ApplicationOwner",
                columns: new[] { "Id", "AppUuid", "UserUuid", "Uuid" },
                values: new object[,]
                {
                    { 1, new Guid("108ca102-9d1f-4942-828c-01f2ed7b012b"), new Guid("69fc3f24-f972-4946-aa96-564703986dbd"), new Guid("4f648db1-7ffc-4676-bedb-11ad3dbd8f34") },
                    { 2, new Guid("1b2112ae-a6e3-4dec-b0e0-d324a55e34e0"), new Guid("1b2112ae-a6e3-4dec-b0e0-d324a55e34e0"), new Guid("da8598e6-90ba-47bf-b57b-8ab78142afd4") }
                });

            migrationBuilder.InsertData(
                table: "ApplicationPermissions",
                columns: new[] { "Id", "AppName", "AppUuid", "CreatedAt", "Role", "RoleUuid", "UUID", "UpdatedAt", "UserUuid" },
                values: new object[,]
                {
                    { 1, "GlobalApp", new Guid("108ca102-9d1f-4942-828c-01f2ed7b012b"), new DateTime(2024, 11, 26, 7, 46, 24, 576, DateTimeKind.Local).AddTicks(7398), "Administrator", new Guid("abdb2443-a875-44c5-bc73-2413759a3e87"), new Guid("46f2ce50-01f6-41b7-9794-9d45297f33fd"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("69fc3f24-f972-4946-aa96-564703986dbd") },
                    { 2, "ControlReport", new Guid("1b2112ae-a6e3-4dec-b0e0-d324a55e34e0"), new DateTime(2024, 11, 26, 7, 46, 24, 576, DateTimeKind.Local).AddTicks(7482), "Administrator", new Guid("811e1a04-b01f-48eb-8ce0-8630617a126b"), new Guid("5126dfd3-c488-4460-a05f-4d4c83b18279"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("69fc3f24-f972-4946-aa96-564703986dbd") }
                });

            migrationBuilder.InsertData(
                table: "ControlReportPermissions",
                columns: new[] { "Id", "AppName", "AppUuid", "CanBeEdited", "CanCreateDeviation", "CanCreateEcr", "CanCreateIntervention", "CanCreateReference", "CanCreateTask", "CanDeleteDeviation", "CanDeleteEcr", "CanDeleteIntervention", "CanDeleteReference", "CanDeleteTask", "CanReadDeviation", "CanReadEcr", "CanReadIntervention", "CanReadReference", "CanReadTask", "CanUpdateDeviation", "CanUpdateEcr", "CanUpdateIntervention", "CanUpdateReference", "CanUpdateTask", "CanUseApp", "HasAllPrivelage", "RoleName", "UUID" },
                values: new object[,]
                {
                    { 1, "ControlReport", new Guid("1b2112ae-a6e3-4dec-b0e0-d324a55e34e0"), false, true, true, true, true, true, false, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, "Administrator", new Guid("811e1a04-b01f-48eb-8ce0-8630617a126b") },
                    { 2, "ControlReport", new Guid("1b2112ae-a6e3-4dec-b0e0-d324a55e34e0"), false, false, false, false, false, false, false, false, false, false, false, true, true, true, true, true, false, false, false, false, false, true, false, "User", new Guid("c0c99b90-02ab-48a2-ac3d-ea01428be702") }
                });

            migrationBuilder.InsertData(
                table: "GlobalPermissions",
                columns: new[] { "Id", "AppName", "AppUuid", "CanAccessGlobal", "CanBeEdited", "CanCreateGroup", "CanDeleteGroup", "CanUpdateGroup", "CreateCustomRole", "CreateUser", "DeleteCustomRole", "DeleteUser", "RoleName", "UpdateCustomRole", "UpdateUser", "Uuid" },
                values: new object[,]
                {
                    { 1, "GlobalApp", new Guid("108ca102-9d1f-4942-828c-01f2ed7b012b"), true, false, true, true, true, true, true, true, true, "Administrator", true, true, new Guid("abdb2443-a875-44c5-bc73-2413759a3e87") },
                    { 2, "GlobalApp", new Guid("108ca102-9d1f-4942-828c-01f2ed7b012b"), false, false, false, false, false, false, false, false, false, "User", false, false, new Guid("4d669212-33b0-47e0-ac0e-a842a83f59e0") }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Card", "CreatedDate", "Email", "FirstName", "FullName", "Image", "IsActive", "LastName", "LastUpdatedDate", "Password", "Pin", "UserName", "Uuid" },
                values: new object[] { 1, "1234", new DateTime(2024, 11, 26, 7, 46, 24, 425, DateTimeKind.Local).AddTicks(9126), "zyw2.automatyzacja@gmail.com", "admin", "admin admin", null, true, "admin", null, "$2a$11$Qhg/NvWoiT783KDklyLWh.1O6XV.CnzQG5yZOcqFdUzFVtxdNVQUq", 1234, "admin", new Guid("69fc3f24-f972-4946-aa96-564703986dbd") });
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
