using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Journal.Models;

namespace Journal.DataBaseFiles
{
    public class DbContextApp : DbContext
    {
        public DbSet<Student> Students { get; set; }
        public DbSet<Group> Groups { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<Subject> Subjects { get; set; }
        public DbSet<Schedule> Schedules { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            

            
            optionsBuilder.UseSqlite("Data Source=../../../data.db");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Group>()
                .HasMany(g => g.Students)
                .WithOne(s => s.Group)
                .HasForeignKey(s => s.GroupId);

            modelBuilder.Entity<Group>()
                .HasMany(g => g.Schedules)
                .WithOne(s => s.Group)
                .HasForeignKey(s => s.GroupId);

            modelBuilder.Entity<Group>()
                .HasMany(g => g.Subjects)
                .WithMany(s => s.Groups);

            modelBuilder.Entity<Teacher>()
                .HasMany(t => t.Subjects)
                .WithMany(s => s.Teachers);

            modelBuilder.Entity<Subject>()
                .HasMany(s => s.Schedules)
                .WithOne(sc => sc.Subject)
                .HasForeignKey(sc => sc.SubjectId);
        }
    }
}