using GlobalManagement.AddinationalFunctions;
using GlobalManagement.Logging;
using GlobalManagement.Models._DefaultModels._Roles._ControlReportRoles;
using GlobalManagement.Models._DefaultModels._Roles._GlobalRoles;
using GlobalManagement.Models._DefaultModels._User;
using GlobalManagement.Models.AppModel;
using GlobalManagement.Models.AppModel._App;
using GlobalManagement.Models.Groups;
using GlobalManagement.Models.Groups._Default;
using GlobalManagement.Models.Groups.Members;
using GlobalManagement.Models.Groups.Permissions;
using GlobalManagement.Models.Permissions;
using Microsoft.EntityFrameworkCore;

namespace GlobalManagement.Database
{
    public class GlobalDatabase : DbContext
    {
        public GlobalDatabase(DbContextOptions<GlobalDatabase> options) : base(options)
        {
            try
            {
                bool status = Database.CanConnect();
                if (status)
                    Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"Database name: {Database.GetDbConnection().Database} STATUS 200");
                Console.ForegroundColor = ConsoleColor.White;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Failure to connect to DB\nSTATUS 400");
            }
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Application
            App globalPregen = new App { Id = 1, Uuid = Guid.NewGuid(), Name = "GlobalApp", Description = "Application used to manage other applications and permission", IsActive = true, Address = "10.35.92.163:3001", CreatedAt = DateTime.Now };
            App controlPregen = new App() { Id = 2, Uuid = Guid.NewGuid(), Name = "ControlReport", Description = "Application used to manage reference, ecr, deviation", IsActive = true, Address = "10.35.92.163:2999", CreatedAt = DateTime.Now };

            modelBuilder.Entity<App>(entity =>
            {
                entity.HasKey(entity => entity.Id);
                entity.HasAlternateKey(entity => entity.Uuid);
                entity.Property(entity => entity.Name)
                .IsRequired()
                .HasColumnName("Application Name");
                entity.Property(entity => entity.Description)
                .IsRequired()
                .HasColumnName("Application Description");
                entity.HasData(globalPregen);
                entity.HasData(controlPregen);
            });
            // Basic Admin, startup user
            Hashing hashing = new Hashing();
            User admin = new()
            {
                Id = 1,
                Uuid = Guid.NewGuid(),
                UserName = "admin",
                Password = hashing.Hash("1234QWERasdf"),
                FullName = "admin admin",
                FirstName = "admin",
                LastName = "admin",
                Email = "zyw2.automatyzacja@gmail.com",
                Card = "1234",
                Pin = 1234,
                IsActive = true,
            };
            // Users
            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(entity => entity.Id);
                entity.HasAlternateKey(entity => entity.Uuid);
                entity.Property(entity => entity.UserName).IsRequired().HasMaxLength(32);
                entity.Property(entity => entity.Password).IsRequired();
                entity.Property(e => e.FirstName).IsRequired().HasMaxLength(48);
                entity.Property(e => e.LastName).IsRequired().HasMaxLength(48);
                entity.Property(e => e.FirstName).IsRequired().HasMaxLength(48);
                entity.Property(e => e.FullName).IsRequired().HasMaxLength(48);
                entity.Property(e => e.Email).IsRequired().HasMaxLength(64);
                entity.Property(e => e.Card).IsRequired().HasMaxLength(28);
                entity.Property(e => e.Pin).IsRequired().HasMaxLength(16);
                entity.Property(e => e.IsActive).IsRequired();
                entity.HasData(admin);
            });
            // App Owners
            modelBuilder.Entity<AppOwners>(e =>
            {
                e.HasKey(e => e.Id);
                e.HasAlternateKey(e => e.Uuid);
                e.Property(e => e.AppUuid).IsRequired();
                e.Property(e => e.UserUuid).IsRequired();
                e.HasData(new AppOwners() { Id = 1, Uuid = Guid.NewGuid(), UserUuid = admin.Uuid, AppUuid = globalPregen.Uuid });
                e.HasData(new AppOwners() { Id = 2, Uuid = Guid.NewGuid(), UserUuid = controlPregen.Uuid, AppUuid = controlPregen.Uuid });

            });
            // App options
            modelBuilder.Entity<AppOptions>(e =>
            {
                e.HasKey(e => e.Id);
                e.HasAlternateKey(e => e.Uuid);
                e.Property(e => e.AppUuid).IsRequired();
                e.HasData(new AppOptions() { Id = 1, Uuid = Guid.NewGuid(), AppUuid = globalPregen.Uuid });
                e.HasData(new AppOptions() { Id = 2, Uuid = Guid.NewGuid(), AppUuid = controlPregen.Uuid });
            });
            Guid gl = Guid.NewGuid();
            // First run global app
            modelBuilder.Entity<DefaultGlobalRole>(e =>
            {
                e.HasKey(e => e.Id);
                e.HasAlternateKey(e => e.Uuid);
                e.Property(e => e.AppName).IsRequired();
                e.Property(e => e.AppUuid).IsRequired();
                e.Property(e => e.RoleName).IsRequired();
                e.Property(e => e.CanBeEdited).IsRequired();
                e.Property(e => e.CreateUser).IsRequired();
                e.Property(e => e.UpdateUser).IsRequired();
                e.Property(e => e.DeleteUser).IsRequired();
                e.Property(e => e.CreateCustomRole).IsRequired();
                e.Property(e => e.CanAccessGlobal).IsRequired();
                e.HasData(new DefaultGlobalRole()
                {
                    Id = 1,
                    Uuid = gl,
                    AppName = globalPregen.Name,
                    AppUuid = globalPregen.Uuid,
                    RoleName = "Administrator",
                    CanAccessGlobal = true,
                    CanBeEdited = false,
                    CreateUser = true,
                    UpdateUser = true,
                    DeleteUser = true,
                    CreateCustomRole = true,
                    CanCreateGroup = true,
                    CanDeleteGroup = true,
                    CanUpdateGroup = true,
                    DeleteCustomRole = true,
                    UpdateCustomRole = true
                });
                e.HasData(new DefaultGlobalRole()
                {
                    Id = 2,
                    Uuid = Guid.NewGuid(),
                    AppName = globalPregen.Name,
                    AppUuid = globalPregen.Uuid,
                    RoleName = "User",
                    CanAccessGlobal = false,
                    CanBeEdited = false,
                    CreateUser = false,
                    UpdateUser = false,
                    DeleteUser = false,
                    CreateCustomRole = false,
                    CanCreateGroup = false,
                    CanDeleteGroup = false,
                    CanUpdateGroup = false,
                    DeleteCustomRole = false,
                    UpdateCustomRole = false
                });
            });
            Guid cr = Guid.NewGuid();
            // Control Report 
            modelBuilder.Entity<DefaultControlReportRole>(e =>
            {
                e.HasKey(e => e.Id);
                e.HasAlternateKey(e => e.UUID);
                e.Property(e => e.RoleName).IsRequired();
                e.Property(e => e.CanBeEdited).IsRequired();
                e.Property(e => e.HasAllPrivelage).IsRequired();
                e.Property(e => e.CanUseApp).IsRequired();
                e.Property(e => e.CanBeEdited).IsRequired();
                // ref
                e.Property(e => e.CanCreateReference).IsRequired();
                e.Property(e => e.CanUpdateReference).IsRequired();
                e.Property(e => e.CanDeleteReference).IsRequired();
                e.Property(e => e.CanReadReference).IsRequired();
                // intervention
                e.Property(e => e.CanCreateIntervention).IsRequired();
                e.Property(e => e.CanDeleteIntervention).IsRequired();
                e.Property(e => e.CanReadIntervention).IsRequired();
                e.Property(e => e.CanUpdateIntervention).IsRequired();
                // tasks
                e.Property(e => e.CanCreateTask).IsRequired();
                e.Property(e => e.CanReadTask).IsRequired();
                e.Property(e => e.CanDeleteTask).IsRequired();
                e.Property(e => e.CanUpdateTask).IsRequired();
                // ecr
                e.Property(e => e.CanCreateEcr).IsRequired();
                e.Property(e => e.CanReadEcr).IsRequired();
                e.Property(e => e.CanDeleteEcr).IsRequired();
                e.Property(e => e.CanUpdateEcr).IsRequired();
                // deviation
                e.HasData(new DefaultControlReportRole()
                {
                    Id = 1,
                    UUID = cr,
                    AppName = controlPregen.Name,
                    AppUuid = controlPregen.Uuid,
                    RoleName = "Administrator",
                    CanBeEdited = false,
                    HasAllPrivelage = true,
                    CanUseApp = true,
                    CanCreateReference = true,
                    CanReadReference = true,
                    CanUpdateReference = true,
                    CanDeleteReference = true,
                    CanCreateIntervention = true,
                    CanUpdateIntervention = true,
                    CanDeleteIntervention = true,
                    CanReadIntervention = true,
                    CanCreateTask = true,
                    CanReadTask = true,
                    CanUpdateTask = true,
                    CanDeleteTask = true,
                    CanCreateEcr = true,
                    CanReadEcr = true,
                    CanUpdateEcr = true,
                    CanDeleteEcr = true,
                    CanCreateDeviation = true,
                    CanReadDeviation = true,
                    CanUpdateDeviation = true,
                });
                e.HasData(new DefaultControlReportRole()
                {
                    Id = 2,
                    UUID = Guid.NewGuid(),
                    RoleName = "User",
                    AppName = controlPregen.Name,
                    AppUuid = controlPregen.Uuid,
                    CanBeEdited = false,
                    HasAllPrivelage = false,
                    CanUseApp = true,
                    CanCreateReference = false,
                    CanReadReference = true,
                    CanUpdateReference = false,
                    CanDeleteReference = false,
                    CanCreateIntervention = false,
                    CanReadIntervention = true,
                    CanUpdateIntervention = false,
                    CanDeleteIntervention = false,
                    CanCreateTask = false,
                    CanReadTask = true,
                    CanUpdateTask = false,
                    CanDeleteTask = false,
                    CanCreateEcr = false,
                    CanReadEcr = true,
                    CanUpdateEcr = false,
                    CanDeleteEcr = false,
                    CanCreateDeviation = false,
                    CanReadDeviation = true,
                    CanUpdateDeviation = false,
                });
            });
            // First Creation
            modelBuilder.Entity<PermissionModel>(e =>
            {
                e.HasKey(e => e.Id);
                e.HasAlternateKey(e => e.UUID);
                e.Property(e => e.UserUuid).IsRequired();
                e.Property(e => e.AppName).IsRequired();
                e.Property(e => e.AppUuid).IsRequired();
                e.Property(e => e.Role).IsRequired();
                e.Property(e => e.RoleUuid).IsRequired();
                e.HasData(new PermissionModel()
                {
                    Id = 1,
                    UUID = Guid.NewGuid(),
                    UserUuid = admin.Uuid,
                    AppName = globalPregen.Name,
                    AppUuid = globalPregen.Uuid,
                    Role = "Administrator",
                    RoleUuid = gl,
                    CreatedAt = DateTime.Now
                });
                e.HasData(new PermissionModel()
                {
                    Id = 2,
                    UUID = Guid.NewGuid(),
                    UserUuid = admin.Uuid,
                    AppName = controlPregen.Name,
                    AppUuid = controlPregen.Uuid,
                    Role = "Administrator",
                    RoleUuid = cr,
                    CreatedAt = DateTime.Now
                });
            });
            modelBuilder.Entity<_Log_Model>(e =>
            {
                e.HasKey(e => e.Id);
                e.HasAlternateKey(e => e.Uuid);
                e.Property(e => e.Class).IsRequired();
                e.Property(e => e.Message).IsRequired();
                e.Property(e => e.End).IsRequired();
            });
            modelBuilder.Entity<GroupModel>(e =>
            {
                e.HasKey(e => e.Id);
                e.HasAlternateKey(e => e.Uuid);
                e.Property(e => e.Name).IsRequired();
                e.Property(e => e.Description).IsRequired();
                e.Property(e => e.Hala).IsRequired();
                e.Property(e => e.Section).IsRequired();
                e.Property(e => e.IsActive).IsRequired();
                e.Property(e => e.CreatedAt).IsRequired();
            });
            modelBuilder.Entity<GroupMember>(e =>
            {
                e.HasKey(e => e.Id);
                e.HasAlternateKey(e => e.Uuid);
                e.Property(e => e.GroupName);
                e.Property(e => e.GroupUUID);
                e.Property(e => e.Username);
                e.Property(e => e.UserGuid);
                e.Property(e => e.Role);
                e.Property(e => e.RoleGuid);
                e.Property(e => e.IsActive);
                e.Property(e => e.CreatedAt);
            });
            modelBuilder.Entity<GroupPermissions>(e =>
            {
                e.HasKey(e => e.Id);
                e.HasAlternateKey(e => e.Uuid);
                e.Property(e => e.GroupName);
                e.Property(e => e.GroupUuid);
                e.Property(e => e.UsersCanAccessGlobalApp);
                e.Property(e => e.UsersCanAccessReferenceHub);
            });
            modelBuilder.Entity<GroupRoleModel>(e =>
            {
                e.HasKey(e => e.Id);
                e.HasAlternateKey(e => e.Uuid);
                e.Property(e => e.GroupName);
                e.Property(e => e.GroupUuid);
                e.Property(e => e.RoleName);
                e.Property(e => e.IsAdmin);
                e.Property(e => e.CanModifyGroup);
                e.Property(e => e.CanRemoveGroup);
                e.Property(e => e.CanAddRoles);
                e.Property(e => e.CanModifyRoles);
                e.Property(e => e.CanRemoveRoles);
                e.Property(e => e.IsRoleRemovable);
                e.Property(e => e.CanAddUser);
                e.Property(e => e.CanRemoveUser);
                e.Property(e => e.CanModifyUser);
                e.Property(e => e.CreatedAt);
            });
        }
        // Applications
        public DbSet<App> Application { get; set; } // Application
        public DbSet<AppOptions> ApplicationOptions { get; set; }
        public DbSet<AppOwners> ApplicationOwner { get; set; }
        // Users
        public DbSet<User> Users { get; set; }
        public DbSet<PermissionModel> ApplicationPermissions { get; set; }
        // Permission Models
        public DbSet<DefaultGlobalRole> GlobalPermissions { get; set; }
        public DbSet<DefaultControlReportRole> ControlReportPermissions { get; set; }
        // Groups
        public DbSet<GroupModel> Groups { get; set; }
        public DbSet<GroupMember> GroupMembers { get; set; }
        public DbSet<GroupPermissions> GroupPermissions { get; set; }
        public DbSet<GroupRoleModel> GroupRole { get; set; }
        // Logger
        public DbSet<_Log_Model> Logs { get; set; }
    }
}
;