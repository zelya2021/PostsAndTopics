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
    public class AccountService: IAccountService
    {
        private IRepositoryWrapper _repoWrapper;
        public AccountService(IRepositoryWrapper repoWrapper)
        {
            _repoWrapper = repoWrapper;
        }

        public async Task<User> AccountActiveAsync(LoginDto dto)
        {
            var resUser = _repoWrapper.User.FindByCondition(u => u.UserName == dto.userName && u.Password == dto.password).FirstOrDefault();
            if(resUser == null)
            {
                return null;
            }
            else return await Task.FromResult(_repoWrapper.User.FindByCondition(u => u.UserName == dto.userName && u.Password == dto.password).FirstOrDefault());
        }

        public async Task<User> GetUserByNameAsync(string userName)
        {
            return await Task.FromResult(_repoWrapper.User.FindByCondition(u => u.UserName == userName).FirstOrDefault());
        }

        public User GetUserIdAsync(string userName)
        {
            return _repoWrapper.User.FindByCondition(x => x.UserName == userName).FirstOrDefault();
        }
    }
}
