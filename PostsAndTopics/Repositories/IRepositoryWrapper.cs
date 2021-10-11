using PostsAndTopics.Repositories;

namespace PostsAndTopics.Services.Repositories
{
    public interface IRepositoryWrapper
    {
        IUserRepository User { get; }
        ITopicRepository Topic { get; }
        IPostRepository Post { get; }
        void Save();
    }
}
