using Microsoft.EntityFrameworkCore;

namespace PostsAndTopics.Models.Database
{
    public static class DbInitializer
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasData(
                 new User { Id = 1, UserName = "Alex", Password = "123456" },
                 new User{Id=2, UserName="Masha", Password="123456" }
            );
        }
    }
}
