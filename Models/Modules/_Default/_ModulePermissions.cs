using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace GlobalManagement.Models.Modules._Default
{
    public class ModulePermissions
    {
        [Required, Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required, Key]
        public Guid Uuid { get; set; }
        [Required]
        public required string ModuleName { get; set; }
        [Required]
        public required string ModuleUuid { get; set; }
        [Required]
        public required string UserName { get; set; }
        [Required]
        public required string UserUuid { get; set; }
        [Required]
        public required bool CanLeaveModule { get; set; }
        [Required]
        public required bool CanJoinModule { get; set; }
        [Required]
        public required bool CanModifyModule { get; set; }
        [Required]
        public required bool CanKickFromModule { get; set; }
        [Required]
        public required bool CanInviteToModule { get; set; }
        [Required]
        public required bool CanRemoveModule { get; set; }
        [Required]
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public DateTime? LastUpdatedDate { get; set; }
    }
}
