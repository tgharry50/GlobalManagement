using GlobalManagement.AddinationalFunctions;
using GlobalManagement.Models._DefaultModels._Roles._ControlReportRoles;
using GlobalManagement.Models._DefaultModels._Roles._GlobalRoles;
using GlobalManagement.Models._DefaultModels._User;
using GlobalManagement.Models.AppModel;
using GlobalManagement.Models.AppModel._App;
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
            App global_pregen = new App() { Id = 1, UUID = Guid.NewGuid(), Name = "GlobalApp", Description = "Application used to manage other applications and permission" };
            App Control_pregen = new App() { Id = 2, UUID = Guid.NewGuid(), Name = "ControlReport", Description = "Application used to manage reference, ecr, deviation" };

            modelBuilder.Entity<App>(entity =>
            {
                entity.HasKey(entity => entity.Id);
                entity.HasAlternateKey(entity => entity.UUID);
                entity.Property(entity => entity.Name)
                .IsRequired()
                .HasColumnName("Application Name");
                entity.Property(entity => entity.Description)
                .IsRequired()
                .HasColumnName("Application Description");
                entity.HasData(global_pregen);
                entity.HasData(Control_pregen);
            });
            // Basic Admin, startup user
            Hashing hashing = new Hashing();
            User admin = new User()
            {
                Id = 1,
                UUID = Guid.NewGuid(),
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
                entity.HasAlternateKey(entity => entity.UUID);
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
            modelBuilder.Entity<App_Owners>(e =>
            {
                e.HasKey(e => e.Id);
                e.HasAlternateKey(e => e.UUID);
                e.Property(e => e.App_UUID).IsRequired();
                e.Property(e => e.User_UUID).IsRequired();
                e.HasData(new App_Owners() { Id = 1, UUID = Guid.NewGuid(), User_UUID = admin.UUID, App_UUID = global_pregen.UUID});
                e.HasData(new App_Owners() { Id = 2, UUID = Guid.NewGuid(), User_UUID = Control_pregen.UUID, App_UUID = Control_pregen.UUID });

            });
            // App options
            modelBuilder.Entity<App_Options>(e =>
            {
                e.HasKey(e => e.Id);
                e.HasAlternateKey(e => e.UUID);
                e.Property(e => e.App_UUID).IsRequired();
                e.HasData(new App_Options() { Id = 1, UUID = Guid.NewGuid(), App_UUID = global_pregen.UUID });
                e.HasData(new App_Options() { Id = 2, UUID = Guid.NewGuid(), App_UUID = Control_pregen.UUID });
            });
            Guid gl = Guid.NewGuid();
            // First run global app
            modelBuilder.Entity<_DefaultGlobalRole>(e =>
            {
                e.HasKey(e => e.Id);
                e.HasAlternateKey(e => e.UUID);
                e.Property(e => e.App_Name).IsRequired();
                e.Property(e => e.App_UUID).IsRequired();
                e.Property(e => e.Role_Name).IsRequired();
                e.Property(e => e.CanBeEdited).IsRequired();
                e.Property(e => e.CreateUser).IsRequired();
                e.Property(e => e.UpdateUser).IsRequired();
                e.Property(e => e.DeleteUser).IsRequired();
                e.Property(e => e.CreateCustomRole).IsRequired();
                e.Property(e => e.CanAccessGlobal).IsRequired();
                e.HasData(new _DefaultGlobalRole()
                {
                    Id = 1,
                    UUID = gl,
                    App_Name = global_pregen.Name,
                    App_UUID = global_pregen.UUID,
                    Role_Name = "Administrator",
                    CanAccessGlobal = true,
                    CanBeEdited = false,
                    CreateUser = true,
                    UpdateUser = true,
                    DeleteUser = true,
                    CreateCustomRole = true,
                });
                e.HasData(new _DefaultGlobalRole()
                {
                    Id = 2,
                    UUID = Guid.NewGuid(),
                    App_Name = global_pregen.Name,
                    App_UUID = global_pregen.UUID,
                    Role_Name = "User",
                    CanAccessGlobal = false,
                    CanBeEdited = false,
                    CreateUser = false,
                    UpdateUser = false,
                    DeleteUser = false,
                    CreateCustomRole = false,
                });
            });
            Guid cr = Guid.NewGuid();
            // Control Report 
            modelBuilder.Entity<_DefaultControlReportRole>(e =>
            {
                e.HasKey(e => e.Id);
                e.HasKey(e => e.UUID);
                e.Property(e=>e.Role_Name).IsRequired();
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
                e.Property(e => e.CanCreateECR).IsRequired();
                e.Property(e => e.CanReadECR).IsRequired();
                e.Property(e => e.CanDeleteECR).IsRequired();
                e.Property(e => e.CanUpdateECR).IsRequired();
                // deviation
                e.Property(e => e.CanCreateGroup).IsRequired();
                e.Property(e => e.CanReadGroup).IsRequired();
                e.Property(e => e.CanUpdateGroup).IsRequired();
                e.Property(e => e.CanDeleteGroup).IsRequired();
                e.HasData(new _DefaultControlReportRole()
                {
                    Id = 1,
                    UUID = cr,
                    App_Name = Control_pregen.Name,
                    App_UUID = Control_pregen.UUID,
                    Role_Name = "Administrator",
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
                    CanCreateECR = true,
                    CanReadECR = true,
                    CanUpdateECR = true,
                    CanDeleteECR = true,
                    CanCreateDeviation = true,
                    CanReadDeviation = true,
                    CanUpdateDeviation = true,
                    CanCreateGroup = true,
                    CanReadGroup = true,
                    CanUpdateGroup = true,
                    CanDeleteGroup = true,
                }); 
                e.HasData(new _DefaultControlReportRole()
                {
                    Id = 2,
                    UUID = Guid.NewGuid(),
                    Role_Name = "User",
                    App_Name = Control_pregen.Name,
                    App_UUID = Control_pregen.UUID,
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
                    CanCreateECR = false,
                    CanReadECR = true,
                    CanUpdateECR = false,
                    CanDeleteECR = false,
                    CanCreateDeviation = false,
                    CanReadDeviation = true,
                    CanUpdateDeviation = false,
                    CanCreateGroup = false,
                    CanReadGroup = true,
                    CanUpdateGroup = false,
                    CanDeleteGroup = false,
                });
            });
            // First Creation
            modelBuilder.Entity<PermissionModel>(e =>
            {
                e.HasKey(e => e.Id);
                e.HasAlternateKey(e => e.UUID);
                e.Property(e => e.User_UUID).IsRequired();
                e.Property(e => e.App_Name).IsRequired();
                e.Property(e => e.App_UUID).IsRequired();
                e.Property(e => e.Role).IsRequired();
                e.Property(e => e.Role_UUID).IsRequired();
                e.HasData(new PermissionModel()
                {
                    Id = 1,
                    UUID = Guid.NewGuid(),
                    User_UUID = admin.UUID,
                    App_Name = global_pregen.Name,
                    App_UUID = global_pregen.UUID,
                    Role = "Administrator",
                    Role_UUID = gl
                });
                e.HasData(new PermissionModel()
                {
                    Id = 2,
                    UUID = Guid.NewGuid(),
                    User_UUID = admin.UUID,
                    App_Name = Control_pregen.Name,
                    App_UUID = Control_pregen.UUID,
                    Role = "Administrator",
                    Role_UUID = cr
                });
            });
        }
        // Applications
        public DbSet<App> Application { get; set; } // Application
        public DbSet<App_Options> ApplicationOptions { get; set; }
        public DbSet<App_Owners> ApplicationOwner { get; set; }
        // Users
        public DbSet<User> Users { get; set; }
        public DbSet<PermissionModel> ApplicationPermissions { get; set; }
        // Permission Models
        public DbSet<_DefaultGlobalRole> GlobalPermissions { get; set; }
        public DbSet<_DefaultControlReportRole> ControlReportPermissions { get; set; }
    }
}
