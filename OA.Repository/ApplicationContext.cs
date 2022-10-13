//using Microsoft.Azure.Documents;
using Microsoft.EntityFrameworkCore;
using OA.Data;

namespace OA.Repository
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            new UserMap(modelBuilder.Entity<User>());
            new UserInfoMap(modelBuilder.Entity<UserInfo>());
            //modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationContext).Assembly);
        }

        public DbSet<User> Users { get; set; }
        
        public DbSet<UserInfo> UserInfos { get; set; }
    }
}