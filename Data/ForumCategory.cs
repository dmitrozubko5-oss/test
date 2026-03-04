using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace forum_test.Data
{
    public class ForumCategory
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Title { get; set; } = null!;

        public string? Description { get; set; }

        public int? ParentId { get; set; }
        [ForeignKey(nameof(ParentId))]
        public ForumCategory? Parent { get; set; }

        public ICollection<ForumCategory> Children { get; set; } = new List<ForumCategory>();

        public ICollection<ForumThread> Threads { get; set; } = new List<ForumThread>();
    }
}