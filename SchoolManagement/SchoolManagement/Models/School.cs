// File: School.cs (namespace trùng project)
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SchoolManagement
{
    public class School
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }                        // id (PK, auto)

        [Required]
        [StringLength(200)]
        public string Name { get; set; } = string.Empty;   // not null, unique

        [Required]
        [StringLength(100)]
        public string Principal { get; set; } = string.Empty;  // not null

        [Required]
        public string Address { get; set; } = string.Empty;    // not null

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;

        public ICollection<Student> Students { get; set; } = new List<Student>(); // 1 – n
    }
}
