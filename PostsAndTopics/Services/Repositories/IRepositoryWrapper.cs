namespace PostsAndTopics.Services.Repositories
{
    public interface IRepositoryWrapper
    {
        IUserRepository User { get; }
        void Save();
    }
}
