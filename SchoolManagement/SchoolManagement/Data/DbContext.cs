// File: SchoolManagement/SchoolDbContext.cs
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Reflection.Emit;

namespace SchoolManagement
{
    public class SchoolDbContext : DbContext
    {
        public SchoolDbContext(DbContextOptions<SchoolDbContext> options)
            : base(options)
        {
        }

        public DbSet<School> Schools { get; set; } = default!;
        public DbSet<Student> Students { get; set; } = default!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Đặt tên bảng đúng yêu cầu
            modelBuilder.Entity<School>().ToTable("schools");
            modelBuilder.Entity<Student>().ToTable("students");

            // UNIQUE constraints
            modelBuilder.Entity<School>()
                .HasIndex(s => s.Name)
                .IsUnique();

            modelBuilder.Entity<Student>()
                .HasIndex(s => s.StudentId)
                .IsUnique();

            modelBuilder.Entity<Student>()
                .HasIndex(s => s.Email)
                .IsUnique();

            // 1 – n: School (1) – Students (n)
            modelBuilder.Entity<Student>()
                .HasOne(s => s.School)
                .WithMany(s => s.Students)
                .HasForeignKey(s => s.SchoolId)
                .OnDelete(DeleteBehavior.Restrict);

            // SEED 10 schools
            modelBuilder.Entity<School>().HasData(
                new School { Id = 1, Name = "Ha Dong High School", Principal = "Nguyen Van A", Address = "Ha Dong, Ha Noi" },
                new School { Id = 2, Name = "Thang Long High School", Principal = "Tran Thi B", Address = "Ha Dong, Ha Noi" },
                new School { Id = 3, Name = "FPT High School", Principal = "Le Van C", Address = "Ha Dong, Ha Noi" },
                new School { Id = 4, Name = "Green Star School", Principal = "Pham Thi D", Address = "Ha Dong, Ha Noi" },
                new School { Id = 5, Name = "Blue Sky School", Principal = "Hoang Van E", Address = "Ha Dong, Ha Noi" },
                new School { Id = 6, Name = "Sunshine High School", Principal = "Ngo Thi F", Address = "Ha Dong, Ha Noi" },
                new School { Id = 7, Name = "Star International School", Principal = "Do Van G", Address = "Ha Dong, Ha Noi" },
                new School { Id = 8, Name = "Future Leaders Academy", Principal = "Vu Thi H", Address = "Ha Dong, Ha Noi" },
                new School { Id = 9, Name = "Elite Hanoi School", Principal = "Bui Van I", Address = "Ha Dong, Ha Noi" },
                new School { Id = 10, Name = "Vietnam National HS", Principal = "Ly Thi K", Address = "Ha Dong, Ha Noi" }
            );

            // SEED 20 students
            modelBuilder.Entity<Student>().HasData(
                new Student { Id = 1, SchoolId = 1, FullName = "Nguyen Van An", StudentId = "SV001", Email = "an.nguyen@school.vn" },
                new Student { Id = 2, SchoolId = 1, FullName = "Tran Thi Be", StudentId = "SV002", Email = "be.tran@school.vn" },
                new Student { Id = 3, SchoolId = 2, FullName = "Le Van Cuong", StudentId = "SV003", Email = "cuong.le@school.vn" },
                new Student { Id = 4, SchoolId = 2, FullName = "Pham Thi Dung", StudentId = "SV004", Email = "dung.pham@school.vn" },
                new Student { Id = 5, SchoolId = 3, FullName = "Hoang Van Em", StudentId = "SV005", Email = "em.hoang@school.vn" },
                new Student { Id = 6, SchoolId = 3, FullName = "Ngo Thi Phuong", StudentId = "SV006", Email = "phuong.ngo@school.vn" },
                new Student { Id = 7, SchoolId = 4, FullName = "Do Van Giang", StudentId = "SV007", Email = "giang.do@school.vn" },
                new Student { Id = 8, SchoolId = 4, FullName = "Vu Thi Hoa", StudentId = "SV008", Email = "hoa.vu@school.vn" },
                new Student { Id = 9, SchoolId = 5, FullName = "Bui Van Hung", StudentId = "SV009", Email = "hung.bui@school.vn" },
                new Student { Id = 10, SchoolId = 5, FullName = "Ly Thi Lan", StudentId = "SV010", Email = "lan.ly@school.vn" },
                new Student { Id = 11, SchoolId = 6, FullName = "Nguyen Van Minh", StudentId = "SV011", Email = "minh.nguyen@school.vn" },
                new Student { Id = 12, SchoolId = 6, FullName = "Tran Van Nam", StudentId = "SV012", Email = "nam.tran@school.vn" },
                new Student { Id = 13, SchoolId = 7, FullName = "Le Thi Oanh", StudentId = "SV013", Email = "oanh.le@school.vn" },
                new Student { Id = 14, SchoolId = 7, FullName = "Pham Van Quy", StudentId = "SV014", Email = "quy.pham@school.vn" },
                new Student { Id = 15, SchoolId = 8, FullName = "Hoang Thi Rong", StudentId = "SV015", Email = "rong.hoang@school.vn" },
                new Student { Id = 16, SchoolId = 8, FullName = "Ngo Van Son", StudentId = "SV016", Email = "son.ngo@school.vn" },
                new Student { Id = 17, SchoolId = 9, FullName = "Do Thi Tam", StudentId = "SV017", Email = "tam.do@school.vn" },
                new Student { Id = 18, SchoolId = 9, FullName = "Vu Van Uyen", StudentId = "SV018", Email = "uyen.vu@school.vn" },
                new Student { Id = 19, SchoolId = 10, FullName = "Bui Thi Van", StudentId = "SV019", Email = "van.bui@school.vn" },
                new Student { Id = 20, SchoolId = 10, FullName = "Ly Van Xuan", StudentId = "SV020", Email = "xuan.ly@school.vn" }
            );
        }
    }
}
