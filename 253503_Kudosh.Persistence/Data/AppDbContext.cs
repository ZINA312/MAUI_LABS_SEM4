using Microsoft.EntityFrameworkCore;

namespace _253503_Kudosh.Persistence.Data
{
    public class AppDbContext : DbContext
    {
        private readonly DbContextOptions<AppDbContext> _options;

        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
            _options = options;

            Database.EnsureCreated();
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ProjectEntity>()
                        .HasMany(p => p.Tasks)
                        .WithOne(t => t.Project)
                        .HasForeignKey(t => t.ProjectId);
            modelBuilder.Entity<TaskEntity>()
                .HasOne(p => p.Project);

        }

    }
}
