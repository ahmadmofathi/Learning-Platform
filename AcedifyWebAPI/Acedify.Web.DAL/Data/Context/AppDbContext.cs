using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection.Emit;
using Acedify.Web.DAL;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

namespace Acedify.Web.DAL
{
    public class AppDbContext : IdentityDbContext<User, IdentityRole<string>, string>
    {
        public AppDbContext()
        {

        }
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Category>(entity =>
            {
                entity.HasKey(c => c.CategoryId);
            });

            modelBuilder.Entity<Code>(entity =>
            {
                entity.HasKey(c => c.CodeId);
            });

            modelBuilder.Entity<Course>(entity =>
            {
                entity.HasKey(c => c.CourseId);
            });

            modelBuilder.Entity<Enrollment>(entity =>
            {
                entity.HasKey(e=>e.Enrollment_ID);
            });


            modelBuilder.Entity<Homework>(entity =>
            {
                entity.HasKey(h=>h.HW_ID);
            });

            modelBuilder.Entity<HwAnswer>(entity =>
            {
                entity.HasKey(h=>h.HwId);
            });

            modelBuilder.Entity<Material>(entity =>
            {
                entity.HasKey(m => m.Material_Id);
            });

            modelBuilder.Entity<Question>(entity =>
            {
                entity.HasKey(q => q.Question_ID);
            });

            modelBuilder.Entity<Quiz>(entity =>
            {
                entity.HasKey(q =>q.Quiz_ID);
            });

            modelBuilder.Entity<SubscriptionRequest>(entity =>
            {
                entity.HasKey(s=>s.SubscriptionRequestId);
            });

            modelBuilder.Entity<Video>(entity =>
            {
                entity.HasKey(v=>v.Video_ID);
            });

        }

        public DbSet<Admin> Admins { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Code> Codes { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Enrollment> Enrollments { get; set; }  
        public DbSet<Homework> Homeworks { get; set; }
        public DbSet <HwAnswer> HwAnswers { get; set; }
        public DbSet <Material> Materials { get; set; }
        public DbSet <Question> Questions { get; set; }
        public DbSet <Quiz> Quizzes { get; set; }
        public DbSet <Student> Students { get; set; }
        public DbSet <SubscriptionRequest> SubscriptionRequests { get; set; }
        public DbSet <SuperAdmin> SuperAdmins { get; set; }
        public DbSet <Teacher> Teachers { get; set; }
        public DbSet<TechnicalSupport> TechnicalSupport { get; set; }
        public DbSet <User> Users { get; set; } 
        public DbSet <Video> Videos { get; set; }
    }
}

