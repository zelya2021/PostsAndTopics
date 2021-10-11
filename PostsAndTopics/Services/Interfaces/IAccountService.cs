using PostsAndTopics.Dto;
using PostsAndTopics.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PostsAndTopics.Services.Interfaces
{
    public interface IAccountService
    {
        Task<User> AccountActiveAsync(LoginDto dto);
        User GetUserIdAsync(string userName);
        Task<User> GetUserByNameAsync(string userName);
    }
}
