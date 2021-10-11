using PostsAndTopics.Dto;
using PostsAndTopics.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PostsAndTopics.Services.Interfaces
{
    public interface ITopicService
    {
        Task<List<Topic>> GetAllTopicsAsync();
        void CreateTopicAsync(Topic topicModel);
        void DeleteTopicById(int id);
        Task<Topic> GetTopicByIdAsync(long id);
        void EditTopic(Topic topic);
        bool IsTopicAlreadyExist(Topic topic);
        Task<Topic> GetTopicByThemeAsync(string theme);
    }
}
