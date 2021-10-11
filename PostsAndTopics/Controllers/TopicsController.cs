using Microsoft.AspNetCore.Mvc;
using PostsAndTopics.Dto;
using PostsAndTopics.Models;
using PostsAndTopics.Models.Database;
using PostsAndTopics.Services.Interfaces;

namespace PostsAndTopics.Controllers
{
    public class TopicsController : Controller
    {
        private ITopicService _topicService;
        private IAccountService _accountService;

        public TopicsController(ITopicService topicService, IAccountService accountService)
        {
            _topicService = topicService; 
            _accountService = accountService;
        }

        public IActionResult ViewTopic()
        {
            var currentUserName= HttpContext.User.Identity.Name.ToString();
            ViewBag.UserId = _accountService.GetUserIdAsync(currentUserName).Id;
            //ViewBag.UserName = _topicService.IncludeTopicsInUserAsync()

            return View(_topicService.GetAllTopicsAsync().Result);
        }

        public IActionResult DetailTopic()
        {
            return View();
        }

        public IActionResult CreateTopic()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateTopic(Topic topicDto)
        {
            if(_topicService.IsTopicAlreadyExist(topicDto) == true)
            {
                return RedirectToAction("CreateTopic");
            }
            topicDto.UserId = (int)_accountService.GetUserIdAsync(HttpContext.User.Identity.Name.ToString()).Id;
            _topicService.CreateTopicAsync(topicDto);
            return RedirectToAction("ViewTopic", _topicService.GetAllTopicsAsync().Result);
        }

        public ActionResult DeleteTopic(int? id)
        {
            if (id is null)
            {
            }

            _topicService.DeleteTopicById(id.Value);

            return RedirectToAction("ViewTopic", _topicService.GetAllTopicsAsync().Result);
        }

        public ActionResult EditTopic(long id)
        {
            return View(_topicService.GetTopicByIdAsync(id).Result);
        }

        [HttpPost]
        public ActionResult EditTopic(Topic topic)
        {
            topic.UserId = (int)_accountService.GetUserIdAsync(HttpContext.User.Identity.Name.ToString()).Id;
            _topicService.EditTopic(topic);

            return RedirectToAction("ViewTopic", _topicService.GetAllTopicsAsync().Result);
        }
    }
}
