using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace PostsAndTopics.Models.Database
{
    public static class DbInitializer
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            var post1 = new Post { Id = 1, Thought = "We need to start by sorting the trash!", UserId = 2, TopicId = 1 };
            var post2 = new Post { Id = 2, Thought = "also do not use natural animal hair", UserId = 1, TopicId = 1 };
            var topic = new Topic { Id = 1, Theme = "Environment", UserId = 1 };

            modelBuilder.Entity<User>().HasData(
                 new User { Id = 1, UserName = "Alex", Password = "123456"},
                 new User { Id = 2, UserName = "Masha", Password = "123456" }
            );

            modelBuilder.Entity<Post>().HasData(post1);
            modelBuilder.Entity<Post>().HasData(post2);

            modelBuilder.Entity<Topic>().HasData(topic);
        }
    }
}
