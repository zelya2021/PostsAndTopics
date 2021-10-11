using Microsoft.EntityFrameworkCore;

namespace PostsAndTopics.Models.Database
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<Topic> Topics { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().ToTable("User");
            modelBuilder.Entity<Topic>().ToTable("Topic");
            modelBuilder.Entity<Post>().ToTable("Post");
            modelBuilder.Seed();
        }
    }
}
