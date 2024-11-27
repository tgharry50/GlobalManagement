using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace GlobalManagement.Migrations
{
    /// <inheritdoc />
    public partial class INIT : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Application",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Application",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "ApplicationOptions",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "ApplicationOptions",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "ApplicationOwner",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "ApplicationOwner",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "ApplicationPermissions",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "ApplicationPermissions",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "ControlReportPermissions",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "ControlReportPermissions",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "GlobalPermissions",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "GlobalPermissions",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.InsertData(
                table: "Application",
                columns: new[] { "Id", "Address", "CreatedAt", "Application Description", "IsActive", "Application Name", "UpdatedAt", "Uuid" },
                values: new object[,]
                {
                    { 1, "10.35.92.163:3001", new DateTime(2024, 11, 26, 7, 46, 56, 395, DateTimeKind.Local).AddTicks(8409), "Application used to manage other applications and permission", true, "GlobalApp", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("ca82567c-d6aa-4678-8e8b-301d4ef1b893") },
                    { 2, "10.35.92.163:2999", new DateTime(2024, 11, 26, 7, 46, 56, 395, DateTimeKind.Local).AddTicks(8462), "Application used to manage reference, ecr, deviation", true, "ControlReport", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("f1025250-9701-4c08-9dfc-e364d01e7b45") }
                });

            migrationBuilder.InsertData(
                table: "ApplicationOptions",
                columns: new[] { "Id", "AppUuid", "Uuid" },
                values: new object[,]
                {
                    { 1, new Guid("ca82567c-d6aa-4678-8e8b-301d4ef1b893"), new Guid("909a2815-7d1b-48ac-b989-14074d62df3f") },
                    { 2, new Guid("f1025250-9701-4c08-9dfc-e364d01e7b45"), new Guid("fffe499e-eeb6-4d8b-8d00-ce4582f01091") }
                });

            migrationBuilder.InsertData(
                table: "ApplicationOwner",
                columns: new[] { "Id", "AppUuid", "UserUuid", "Uuid" },
                values: new object[,]
                {
                    { 1, new Guid("ca82567c-d6aa-4678-8e8b-301d4ef1b893"), new Guid("c0d78f8d-dbbd-4efa-b41c-f9b6336d4d20"), new Guid("4da557af-e9c7-407f-a45f-d9c32eb2b6b5") },
                    { 2, new Guid("f1025250-9701-4c08-9dfc-e364d01e7b45"), new Guid("f1025250-9701-4c08-9dfc-e364d01e7b45"), new Guid("a6a6dc2a-9951-4cee-ac54-e01ab0c72801") }
                });

            migrationBuilder.InsertData(
                table: "ApplicationPermissions",
                columns: new[] { "Id", "AppName", "AppUuid", "CreatedAt", "Role", "RoleUuid", "UUID", "UpdatedAt", "UserUuid" },
                values: new object[,]
                {
                    { 1, "GlobalApp", new Guid("ca82567c-d6aa-4678-8e8b-301d4ef1b893"), new DateTime(2024, 11, 26, 7, 46, 56, 519, DateTimeKind.Local).AddTicks(8038), "Administrator", new Guid("8db74fb7-6815-49dc-859c-a1a68e64da73"), new Guid("e8a6d4fe-67ef-4493-a44a-7800884cae1b"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("c0d78f8d-dbbd-4efa-b41c-f9b6336d4d20") },
                    { 2, "ControlReport", new Guid("f1025250-9701-4c08-9dfc-e364d01e7b45"), new DateTime(2024, 11, 26, 7, 46, 56, 519, DateTimeKind.Local).AddTicks(8116), "Administrator", new Guid("e2afd6ba-80f3-4d47-9104-03417888e36f"), new Guid("31e37bd3-6ba3-4365-9d69-291dac0e5d69"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("c0d78f8d-dbbd-4efa-b41c-f9b6336d4d20") }
                });

            migrationBuilder.InsertData(
                table: "ControlReportPermissions",
                columns: new[] { "Id", "AppName", "AppUuid", "CanBeEdited", "CanCreateDeviation", "CanCreateEcr", "CanCreateIntervention", "CanCreateReference", "CanCreateTask", "CanDeleteDeviation", "CanDeleteEcr", "CanDeleteIntervention", "CanDeleteReference", "CanDeleteTask", "CanReadDeviation", "CanReadEcr", "CanReadIntervention", "CanReadReference", "CanReadTask", "CanUpdateDeviation", "CanUpdateEcr", "CanUpdateIntervention", "CanUpdateReference", "CanUpdateTask", "CanUseApp", "HasAllPrivelage", "RoleName", "UUID" },
                values: new object[,]
                {
                    { 1, "ControlReport", new Guid("f1025250-9701-4c08-9dfc-e364d01e7b45"), false, true, true, true, true, true, false, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, "Administrator", new Guid("e2afd6ba-80f3-4d47-9104-03417888e36f") },
                    { 2, "ControlReport", new Guid("f1025250-9701-4c08-9dfc-e364d01e7b45"), false, false, false, false, false, false, false, false, false, false, false, true, true, true, true, true, false, false, false, false, false, true, false, "User", new Guid("d0025065-9475-4092-8498-d7cee1b590b3") }
                });

            migrationBuilder.InsertData(
                table: "GlobalPermissions",
                columns: new[] { "Id", "AppName", "AppUuid", "CanAccessGlobal", "CanBeEdited", "CanCreateGroup", "CanDeleteGroup", "CanUpdateGroup", "CreateCustomRole", "CreateUser", "DeleteCustomRole", "DeleteUser", "RoleName", "UpdateCustomRole", "UpdateUser", "Uuid" },
                values: new object[,]
                {
                    { 1, "GlobalApp", new Guid("ca82567c-d6aa-4678-8e8b-301d4ef1b893"), true, false, true, true, true, true, true, true, true, "Administrator", true, true, new Guid("8db74fb7-6815-49dc-859c-a1a68e64da73") },
                    { 2, "GlobalApp", new Guid("ca82567c-d6aa-4678-8e8b-301d4ef1b893"), false, false, false, false, false, false, false, false, false, "User", false, false, new Guid("01dffe79-3343-4528-a4c4-b5d099c4494d") }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Card", "CreatedDate", "Email", "FirstName", "FullName", "Image", "IsActive", "LastName", "LastUpdatedDate", "Password", "Pin", "UserName", "Uuid" },
                values: new object[] { 1, "1234", new DateTime(2024, 11, 26, 7, 46, 56, 396, DateTimeKind.Local).AddTicks(531), "zyw2.automatyzacja@gmail.com", "admin", "admin admin", null, true, "admin", null, "$2a$11$Z1e56PdYFs5PBiWMWmu/yOiObuFz2TlRKHOG9REndVvkNinh6HYD.", 1234, "admin", new Guid("c0d78f8d-dbbd-4efa-b41c-f9b6336d4d20") });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Application",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Application",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "ApplicationOptions",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "ApplicationOptions",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "ApplicationOwner",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "ApplicationOwner",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "ApplicationPermissions",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "ApplicationPermissions",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "ControlReportPermissions",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "ControlReportPermissions",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "GlobalPermissions",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "GlobalPermissions",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1);

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
    }
}
