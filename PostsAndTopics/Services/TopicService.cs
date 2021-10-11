using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using PostsAndTopics.Dto;
using PostsAndTopics.Models;
using PostsAndTopics.Services.Interfaces;
using PostsAndTopics.Services.Repositories;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PostsAndTopics.Services
{
    public class TopicService : ITopicService
    {
        private IRepositoryWrapper _repoWrapper;
        
        public TopicService(IRepositoryWrapper repoWrapper)
        {
            _repoWrapper = repoWrapper;
        }

        public void CreateTopicAsync(Topic topicModel)
        {
            _repoWrapper.Topic.Create(topicModel);
        }

        public async Task<List<Topic>> GetAllTopicsAsync()
        {
            return await Task.FromResult(_repoWrapper.Topic.FindAll().ToList());
        }

        public void DeleteTopicById(int id)
        {
            _repoWrapper.Topic.Delete(_repoWrapper.Topic.FindByCondition(x => x.Id == id).FirstOrDefault());
        }

        public async Task<Topic> GetTopicByIdAsync(long id)
        {
           return await Task.FromResult(_repoWrapper.Topic.FindByCondition(x => x.Id == id).FirstOrDefault());
        }

        public async Task<Topic> GetTopicByThemeAsync(string theme)
        {
            return await Task.FromResult(_repoWrapper.Topic.FindByCondition(x => x.Theme == theme).FirstOrDefault());
        }

        public void EditTopic(Topic topic)
        {
            _repoWrapper.Topic.Update(topic);
        }

        public bool IsTopicAlreadyExist(Topic topic)
        {
           return _repoWrapper.Topic.FindByCondition(x => x.Theme == topic.Theme).FirstOrDefault() == null ? false : true;
        }
    }
}
