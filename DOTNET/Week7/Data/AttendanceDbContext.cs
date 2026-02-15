using StudentAttendanceAPI.Models;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
namespace StudentAttendanceAPI.Data
{
    public class AttendanceDbContext:DbContext
    {
        // Constructor (needed for Dependency Injection)
        public AttendanceDbContext(DbContextOptions<AttendanceDbContext> options): base(options)
        {
        }

        // Tables
        public DbSet<Student> Students { get; set; }

        public DbSet<Attendance> Attendances { get; set; }
    }
}
