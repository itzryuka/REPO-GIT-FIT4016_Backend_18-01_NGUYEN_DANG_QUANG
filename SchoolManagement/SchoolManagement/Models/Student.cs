// File: Student.cs
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SchoolManagement
{
    public class Student
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }                        // id (PK, auto)

        [Required(ErrorMessage = "School is required.")]
        public int SchoolId { get; set; }                  // FK

        [Required(ErrorMessage = "Full name is required.")]
        [StringLength(100, MinimumLength = 2, ErrorMessage = "Full name must be 2-100 characters.")]
        public string FullName { get; set; } = string.Empty;

        [Required(ErrorMessage = "Student ID is required.")]
        [StringLength(20, MinimumLength = 5, ErrorMessage = "Student ID must be 5-20 characters.")]
        public string StudentId { get; set; } = string.Empty;

        [Required(ErrorMessage = "Email is required.")]
        [EmailAddress(ErrorMessage = "Email format is not valid.")]
        public string Email { get; set; } = string.Empty;

        // Optional, nếu nhập thì 10-11 digits
        [RegularExpression(@"^\d{10,11}$", ErrorMessage = "Phone number must be 10-11 digits.")]
        public string? Phone { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;

        [ForeignKey(nameof(SchoolId))]
        public School? School { get; set; }                // navigation
    }
}
