using BitirmeProjesiPortal.Models;
using Microsoft.EntityFrameworkCore;

namespace BitirmeProjesiPortal.Entities
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<UserAccount>? UserAccounts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
        public DbSet<Class>? Classes { get; set; }
        public DbSet<ClassReference>? ClassReferences { get; set; }
        public DbSet<Announcement>? Announcements { get; set; }
        public DbSet<Assignment>? Assignments { get; set; }
    }
}
