using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace forum_test.Data
{
    public class ForumThread
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Title { get; set; } = null!;

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        public string CreatedById { get; set; } = null!;

        [ForeignKey(nameof(CreatedById))]
        public ApplicationUser? CreatedBy { get; set; }

        public int CategoryId { get; set; }
        [ForeignKey(nameof(CategoryId))]
        public ForumCategory? Category { get; set; }

        public ICollection<ForumPost> Posts { get; set; } = new List<ForumPost>();

        /// <summary>
        /// Дозволені ролі для писання в цій темі
        /// Якщо порожньо - дозволено всім
        /// </summary>
        public ICollection<ThreadRolePermission> RolePermissions { get; set; } = new List<ThreadRolePermission>();

        /// <summary>
        /// Чи тема обмежена деякими ролями
        /// </summary>
        public bool IsRestrictedByRole { get; set; } = false;

        /// <summary>
        /// Чи можуть звичайні користувачі писати в цій темі
        /// </summary>
        public bool AllowAnonymousWrite { get; set; } = true;
    }
}
