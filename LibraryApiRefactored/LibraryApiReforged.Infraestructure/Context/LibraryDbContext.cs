using LibraryApiReforged.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace LibraryApiReforged.Infraestructure.Context
{
    public class LibraryDbContext : DbContext
    {


        public LibraryDbContext(DbContextOptions<LibraryDbContext> options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Skill> Skills { get; set; }
        public DbSet<Lesson> Lessons { get; set; }
        public DbSet<Goal> Goals { get; set; }
        public DbSet<UserSkill> UserSkills { get; set; }
        public DbSet<UserLesson> UserLessons { get; set; }
        public DbSet<LessonSkill> LessonSkills { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<LessonSkill>()
               .HasKey(ls => new { ls.LessonID, ls.SkillID });

            modelBuilder.Entity<UserLesson>()
                .HasKey(ul => new { ul.UserId, ul.LessonID });

            modelBuilder.Entity<UserSkill>()
                .HasKey(uk => new { uk.UserId, uk.SkillID });

        }
    }
}
