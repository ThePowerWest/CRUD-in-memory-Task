using ApplicationCore.Entities.Main;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data
{
    /// <summary>
    /// Main database context
    /// </summary>
    public class MainContext : DbContext
    {
        /// <summary>
        /// ctor
        /// </summary>
        public MainContext(DbContextOptions<MainContext> options) : base(options) { }

        public DbSet<Profile> Profiles { get; set; }
        public DbSet<Worker> Workers { get; set; }

        /// <inheritdoc />
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLazyLoadingProxies();
        }

        /// <inheritdoc />
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Worker>().HasKey(bc => new { bc.Id });
            builder.Entity<Profile>().HasKey(bc => new { bc.Id });

            builder.Entity<Worker>().HasOne(u => u.Profile).WithOne(p => p.Worker).HasForeignKey<Worker>(c => c.Id);
        }
    }
}