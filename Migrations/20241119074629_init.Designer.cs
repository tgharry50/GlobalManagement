﻿// <auto-generated />
using System;
using GlobalManagement.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace GlobalManagement.Migrations
{
    [DbContext(typeof(GlobalDatabase))]
    [Migration("20241119074629_init")]
    partial class init
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("GlobalManagement.Logging._Log_Model", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Class")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<TimeSpan>("End")
                        .HasColumnType("time");

                    b.Property<string>("Message")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("Uuid")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasAlternateKey("Uuid");

                    b.ToTable("Logs");
                });

            modelBuilder.Entity("GlobalManagement.Models.AppModel.App", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Application Description");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Application Name");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("Uuid")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasAlternateKey("Uuid");

                    b.ToTable("Application");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Address = "10.35.92.163:3001",
                            CreatedAt = new DateTime(2024, 11, 19, 8, 46, 28, 479, DateTimeKind.Local).AddTicks(4118),
                            Description = "Application used to manage other applications and permission",
                            IsActive = true,
                            Name = "GlobalApp",
                            UpdatedAt = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Uuid = new Guid("e347b87d-f522-43b4-8d5d-6daee67ff31a")
                        },
                        new
                        {
                            Id = 2,
                            Address = "10.35.92.163:2999",
                            CreatedAt = new DateTime(2024, 11, 19, 8, 46, 28, 479, DateTimeKind.Local).AddTicks(4179),
                            Description = "Application used to manage reference, ecr, deviation",
                            IsActive = true,
                            Name = "ControlReport",
                            UpdatedAt = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Uuid = new Guid("45168948-edf8-441e-9e41-02c568774edc")
                        });
                });

            modelBuilder.Entity("GlobalManagement.Models.AppModel._App.AppOptions", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<Guid>("AppUuid")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("Uuid")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasAlternateKey("Uuid");

                    b.ToTable("ApplicationOptions");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            AppUuid = new Guid("e347b87d-f522-43b4-8d5d-6daee67ff31a"),
                            Uuid = new Guid("50e4211b-be4c-469a-afe6-897ea64d06d9")
                        },
                        new
                        {
                            Id = 2,
                            AppUuid = new Guid("45168948-edf8-441e-9e41-02c568774edc"),
                            Uuid = new Guid("0020daac-5de9-4436-8cf4-4f16cda9fae6")
                        });
                });

            modelBuilder.Entity("GlobalManagement.Models.AppModel._App.AppOwners", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<Guid>("AppUuid")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("UserUuid")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("Uuid")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasAlternateKey("Uuid");

                    b.ToTable("ApplicationOwner");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            AppUuid = new Guid("e347b87d-f522-43b4-8d5d-6daee67ff31a"),
                            UserUuid = new Guid("96572ac8-0edf-476d-a3a4-944bd4cc2d4c"),
                            Uuid = new Guid("c6704fb7-d3d7-4b49-b50f-122d33dca062")
                        },
                        new
                        {
                            Id = 2,
                            AppUuid = new Guid("45168948-edf8-441e-9e41-02c568774edc"),
                            UserUuid = new Guid("45168948-edf8-441e-9e41-02c568774edc"),
                            Uuid = new Guid("0e765498-b807-4550-98ee-d39f4274bf83")
                        });
                });

            modelBuilder.Entity("GlobalManagement.Models.Groups.GroupModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Hala")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Section")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("UpdateAt")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("Uuid")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasAlternateKey("Uuid");

                    b.ToTable("Groups");
                });

            modelBuilder.Entity("GlobalManagement.Models.Groups.Members.GroupMember", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("GroupName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("GroupUUID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<string>("Role")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("RoleGuid")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("UserGuid")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("Uuid")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasAlternateKey("Uuid");

                    b.ToTable("GroupMembers");
                });

            modelBuilder.Entity("GlobalManagement.Models.Groups.Permissions.GroupPermissions", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("GroupName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("GroupUuid")
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("UsersCanAccessGlobalApp")
                        .HasColumnType("bit");

                    b.Property<bool>("UsersCanAccessReferenceHub")
                        .HasColumnType("bit");

                    b.Property<Guid>("Uuid")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasAlternateKey("Uuid");

                    b.ToTable("GroupPermissions");
                });

            modelBuilder.Entity("GlobalManagement.Models.Groups._Default.GroupRoleModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<bool>("CanAddRoles")
                        .HasColumnType("bit");

                    b.Property<bool>("CanAddUser")
                        .HasColumnType("bit");

                    b.Property<bool>("CanModifyGroup")
                        .HasColumnType("bit");

                    b.Property<bool>("CanModifyRoles")
                        .HasColumnType("bit");

                    b.Property<bool>("CanModifyUser")
                        .HasColumnType("bit");

                    b.Property<bool>("CanRemoveGroup")
                        .HasColumnType("bit");

                    b.Property<bool>("CanRemoveRoles")
                        .HasColumnType("bit");

                    b.Property<bool>("CanRemoveUser")
                        .HasColumnType("bit");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("GroupName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("GroupUuid")
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("IsAdmin")
                        .HasColumnType("bit");

                    b.Property<bool>("IsRoleRemovable")
                        .HasColumnType("bit");

                    b.Property<string>("RoleName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("Uuid")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasAlternateKey("Uuid");

                    b.ToTable("GroupRole");
                });

            modelBuilder.Entity("GlobalManagement.Models.Permissions.PermissionModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("AppName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("AppUuid")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Role")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("RoleUuid")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("UUID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("UserUuid")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasAlternateKey("UUID");

                    b.ToTable("ApplicationPermissions");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            AppName = "GlobalApp",
                            AppUuid = new Guid("e347b87d-f522-43b4-8d5d-6daee67ff31a"),
                            CreatedAt = new DateTime(2024, 11, 19, 8, 46, 28, 618, DateTimeKind.Local).AddTicks(811),
                            Role = "Administrator",
                            RoleUuid = new Guid("6be1dc71-52e3-427e-8b03-e6326f968841"),
                            UUID = new Guid("d5b2beb6-5947-4cc5-9ae6-7d68511b22b9"),
                            UpdatedAt = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            UserUuid = new Guid("96572ac8-0edf-476d-a3a4-944bd4cc2d4c")
                        },
                        new
                        {
                            Id = 2,
                            AppName = "ControlReport",
                            AppUuid = new Guid("45168948-edf8-441e-9e41-02c568774edc"),
                            CreatedAt = new DateTime(2024, 11, 19, 8, 46, 28, 618, DateTimeKind.Local).AddTicks(891),
                            Role = "Administrator",
                            RoleUuid = new Guid("505cf2c9-696d-4ac0-8524-a9f9551d4638"),
                            UUID = new Guid("1b7d33ea-8357-42c0-8edb-284750860f02"),
                            UpdatedAt = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            UserUuid = new Guid("96572ac8-0edf-476d-a3a4-944bd4cc2d4c")
                        });
                });

            modelBuilder.Entity("GlobalManagement.Models._DefaultModels._Roles._ControlReportRoles.DefaultControlReportRole", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("AppName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("AppUuid")
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("CanBeEdited")
                        .HasColumnType("bit");

                    b.Property<bool>("CanCreateDeviation")
                        .HasColumnType("bit");

                    b.Property<bool>("CanCreateEcr")
                        .HasColumnType("bit");

                    b.Property<bool>("CanCreateGroup")
                        .HasColumnType("bit");

                    b.Property<bool>("CanCreateIntervention")
                        .HasColumnType("bit");

                    b.Property<bool>("CanCreateReference")
                        .HasColumnType("bit");

                    b.Property<bool>("CanCreateTask")
                        .HasColumnType("bit");

                    b.Property<bool>("CanDeleteDeviation")
                        .HasColumnType("bit");

                    b.Property<bool>("CanDeleteEcr")
                        .HasColumnType("bit");

                    b.Property<bool>("CanDeleteGroup")
                        .HasColumnType("bit");

                    b.Property<bool>("CanDeleteIntervention")
                        .HasColumnType("bit");

                    b.Property<bool>("CanDeleteReference")
                        .HasColumnType("bit");

                    b.Property<bool>("CanDeleteTask")
                        .HasColumnType("bit");

                    b.Property<bool>("CanReadDeviation")
                        .HasColumnType("bit");

                    b.Property<bool>("CanReadEcr")
                        .HasColumnType("bit");

                    b.Property<bool>("CanReadGroup")
                        .HasColumnType("bit");

                    b.Property<bool>("CanReadIntervention")
                        .HasColumnType("bit");

                    b.Property<bool>("CanReadReference")
                        .HasColumnType("bit");

                    b.Property<bool>("CanReadTask")
                        .HasColumnType("bit");

                    b.Property<bool>("CanUpdateDeviation")
                        .HasColumnType("bit");

                    b.Property<bool>("CanUpdateEcr")
                        .HasColumnType("bit");

                    b.Property<bool>("CanUpdateGroup")
                        .HasColumnType("bit");

                    b.Property<bool>("CanUpdateIntervention")
                        .HasColumnType("bit");

                    b.Property<bool>("CanUpdateReference")
                        .HasColumnType("bit");

                    b.Property<bool>("CanUpdateTask")
                        .HasColumnType("bit");

                    b.Property<bool>("CanUseApp")
                        .HasColumnType("bit");

                    b.Property<bool>("HasAllPrivelage")
                        .HasColumnType("bit");

                    b.Property<string>("RoleName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("UUID")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasAlternateKey("UUID");

                    b.ToTable("ControlReportPermissions");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            AppName = "ControlReport",
                            AppUuid = new Guid("45168948-edf8-441e-9e41-02c568774edc"),
                            CanBeEdited = false,
                            CanCreateDeviation = true,
                            CanCreateEcr = true,
                            CanCreateGroup = true,
                            CanCreateIntervention = true,
                            CanCreateReference = true,
                            CanCreateTask = true,
                            CanDeleteDeviation = false,
                            CanDeleteEcr = true,
                            CanDeleteGroup = true,
                            CanDeleteIntervention = true,
                            CanDeleteReference = true,
                            CanDeleteTask = true,
                            CanReadDeviation = true,
                            CanReadEcr = true,
                            CanReadGroup = true,
                            CanReadIntervention = true,
                            CanReadReference = true,
                            CanReadTask = true,
                            CanUpdateDeviation = true,
                            CanUpdateEcr = true,
                            CanUpdateGroup = true,
                            CanUpdateIntervention = true,
                            CanUpdateReference = true,
                            CanUpdateTask = true,
                            CanUseApp = true,
                            HasAllPrivelage = true,
                            RoleName = "Administrator",
                            UUID = new Guid("505cf2c9-696d-4ac0-8524-a9f9551d4638")
                        },
                        new
                        {
                            Id = 2,
                            AppName = "ControlReport",
                            AppUuid = new Guid("45168948-edf8-441e-9e41-02c568774edc"),
                            CanBeEdited = false,
                            CanCreateDeviation = false,
                            CanCreateEcr = false,
                            CanCreateGroup = false,
                            CanCreateIntervention = false,
                            CanCreateReference = false,
                            CanCreateTask = false,
                            CanDeleteDeviation = false,
                            CanDeleteEcr = false,
                            CanDeleteGroup = false,
                            CanDeleteIntervention = false,
                            CanDeleteReference = false,
                            CanDeleteTask = false,
                            CanReadDeviation = true,
                            CanReadEcr = true,
                            CanReadGroup = true,
                            CanReadIntervention = true,
                            CanReadReference = true,
                            CanReadTask = true,
                            CanUpdateDeviation = false,
                            CanUpdateEcr = false,
                            CanUpdateGroup = false,
                            CanUpdateIntervention = false,
                            CanUpdateReference = false,
                            CanUpdateTask = false,
                            CanUseApp = true,
                            HasAllPrivelage = false,
                            RoleName = "User",
                            UUID = new Guid("0d4316c0-c198-4809-90e3-4953aa4f81d2")
                        });
                });

            modelBuilder.Entity("GlobalManagement.Models._DefaultModels._Roles._GlobalRoles.DefaultGlobalRole", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("AppName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("AppUuid")
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("CanAccessGlobal")
                        .HasColumnType("bit");

                    b.Property<bool>("CanBeEdited")
                        .HasColumnType("bit");

                    b.Property<bool>("CreateCustomRole")
                        .HasColumnType("bit");

                    b.Property<bool>("CreateUser")
                        .HasColumnType("bit");

                    b.Property<bool>("DeleteCustomRole")
                        .HasColumnType("bit");

                    b.Property<bool>("DeleteUser")
                        .HasColumnType("bit");

                    b.Property<string>("RoleName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("UpdateCustomRole")
                        .HasColumnType("bit");

                    b.Property<bool>("UpdateUser")
                        .HasColumnType("bit");

                    b.Property<Guid>("Uuid")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasAlternateKey("Uuid");

                    b.ToTable("GlobalPermissions");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            AppName = "GlobalApp",
                            AppUuid = new Guid("e347b87d-f522-43b4-8d5d-6daee67ff31a"),
                            CanAccessGlobal = true,
                            CanBeEdited = false,
                            CreateCustomRole = true,
                            CreateUser = true,
                            DeleteCustomRole = false,
                            DeleteUser = true,
                            RoleName = "Administrator",
                            UpdateCustomRole = false,
                            UpdateUser = true,
                            Uuid = new Guid("6be1dc71-52e3-427e-8b03-e6326f968841")
                        },
                        new
                        {
                            Id = 2,
                            AppName = "GlobalApp",
                            AppUuid = new Guid("e347b87d-f522-43b4-8d5d-6daee67ff31a"),
                            CanAccessGlobal = false,
                            CanBeEdited = false,
                            CreateCustomRole = false,
                            CreateUser = false,
                            DeleteCustomRole = false,
                            DeleteUser = false,
                            RoleName = "User",
                            UpdateCustomRole = false,
                            UpdateUser = false,
                            Uuid = new Guid("02114cb7-5245-42e7-bf83-d24654dce948")
                        });
                });

            modelBuilder.Entity("GlobalManagement.Models._DefaultModels._User.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Card")
                        .IsRequired()
                        .HasMaxLength(28)
                        .HasColumnType("nvarchar(28)");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(64)
                        .HasColumnType("nvarchar(64)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(48)
                        .HasColumnType("nvarchar(48)");

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasMaxLength(48)
                        .HasColumnType("nvarchar(48)");

                    b.Property<string>("Image")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(48)
                        .HasColumnType("nvarchar(48)");

                    b.Property<DateTime?>("LastUpdatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Pin")
                        .HasMaxLength(16)
                        .HasColumnType("int");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasMaxLength(32)
                        .HasColumnType("nvarchar(32)");

                    b.Property<Guid>("Uuid")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasAlternateKey("Uuid");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Card = "1234",
                            CreatedDate = new DateTime(2024, 11, 19, 8, 46, 28, 479, DateTimeKind.Local).AddTicks(6803),
                            Email = "zyw2.automatyzacja@gmail.com",
                            FirstName = "admin",
                            FullName = "admin admin",
                            IsActive = true,
                            LastName = "admin",
                            Password = "$2a$11$2d6r3nQ2qGO.IdUXi87LHe3FhuOC5kzj0r.dkke7HERCQkEGVduHS",
                            Pin = 1234,
                            UserName = "admin",
                            Uuid = new Guid("96572ac8-0edf-476d-a3a4-944bd4cc2d4c")
                        });
                });
#pragma warning restore 612, 618
        }
    }
}