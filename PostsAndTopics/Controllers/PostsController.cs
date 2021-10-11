using Microsoft.AspNetCore.Mvc;
using PostsAndTopics.Models;
using PostsAndTopics.Services.Interfaces;
using System.Collections.Generic;

namespace PostsAndTopics.Controllers
{
    public class PostsController : Controller
    {
        private IPostService _postService;
        private ITopicService _topicService;
        private IAccountService _accountService;


        public PostsController(IPostService postService, ITopicService topicService, IAccountService accountService)
        {
            _postService = postService;
            _topicService = topicService;
            _accountService = accountService;
        }

        public ActionResult ShowPosts(int id)
        {
            return View();
        }

        public ActionResult ViewPosts(int id)
        {
            ViewBag.TopicName = _topicService.GetTopicByIdAsync(id).Result.Theme;
            ViewBag.UserId = _accountService.GetUserIdAsync(HttpContext.User.Identity.Name).Id;

            var res = _postService.GetAllPostByTopicIdsAsync(id).Result;

            return View(_postService.GetAllPostByTopicIdsAsync(id).Result);
        }

        public IActionResult CreatePost()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreatePost(string topicName, Post post)
        {
            ViewBag.TopicName = topicName;
            post.UserId = (int)_accountService.GetUserIdAsync(HttpContext.User.Identity.Name.ToString()).Id;
            post.TopicId = (int)_topicService.GetTopicByThemeAsync(topicName).Result.Id;
            _postService.CreatePostAsync(post);
            return RedirectToPage("/Posts/ViewPosts", new { _postService.GetAllPostByTopicIdsAsync(post.TopicId).Result });
        }

        public ActionResult DeletePost(int id)
        {
            _postService.DeletePostById(id);

            return RedirectToAction("ShowPosts");
        }

        public ActionResult EditPost(long id)
        {
            return View(_postService.GetPostByIdAsync(id).Result);
        }

        [HttpPost]
        public ActionResult EditPost(Post post)
        {
            post.UserId = (int)_accountService.GetUserIdAsync(HttpContext.User.Identity.Name.ToString()).Id;
            _postService.EditPost(post);

            return RedirectToAction("ShowPosts");
        }
    }
}
