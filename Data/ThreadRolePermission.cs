using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;

namespace forum_test.Data
{
    public class ThreadRolePermission
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey(nameof(Thread))]
        public int ThreadId { get; set; }
        public ForumThread Thread { get; set; } = null!;

        [ForeignKey(nameof(Role))]
        public string RoleId { get; set; } = null!;
        public IdentityRole Role { get; set; } = null!;

        /// <summary>
        /// Дозволяє користувачам з цією роллю писати в темі
        /// </summary>
        public bool CanWrite { get; set; } = true;

        /// <summary>
        /// Дозволяє користувачам з цією роллю редагувати свої повідомлення
        /// </summary>
        public bool CanEdit { get; set; } = true;

        /// <summary>
        /// Дозволяє користувачам з цією роллю видаляти свої повідомлення
        /// </summary>
        public bool CanDelete { get; set; } = false;

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }

    public class UserRole
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey(nameof(User))]
        public string UserId { get; set; } = null!;
        public ApplicationUser User { get; set; } = null!;

        [ForeignKey(nameof(Role))]
        public string RoleId { get; set; } = null!;
        public IdentityRole Role { get; set; } = null!;

        /// <summary>
        /// Роль видана адміністратором
        /// </summary>
        [ForeignKey(nameof(GrantedBy))]
        public string? GrantedById { get; set; }
        public ApplicationUser? GrantedBy { get; set; }

        public DateTime GrantedAt { get; set; } = DateTime.UtcNow;
        public string? Reason { get; set; }

        /// <summary>
        /// Коли роль закінчується (null = безстроково)
        /// </summary>
        public DateTime? ExpiresAt { get; set; }
    }
}
