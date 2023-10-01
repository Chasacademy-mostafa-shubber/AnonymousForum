using AnonymousForum.Data;
using AnonymousForum.Models;
using Microsoft.AspNetCore.Mvc;

namespace AnonymousForum.Controllers
{
    public class PostController : Controller
    {
        private readonly ForumDBContext _ctx;

        public PostController(ForumDBContext ctx)
        {
            _ctx = ctx;
        }


        public IActionResult Index(int id)
        {

            var topicDetails = (from _topic in _ctx.Topics
                                select new ViewModels
                                {
                                    Topic = _topic
                                }).FirstOrDefault(x => x.Topic.TopicID == id);

            ViewBag.postList = (from _post in _ctx.Posts
                                select new ViewModels
                                {
                                    Post = _post
                                }).Where(x=> x.Post.TopicID==id).ToList();

            return View(topicDetails);
        }

        
       
        public IActionResult Create(int id)
        {
            var createPost = (from _topic in _ctx.Topics
                         select new ViewModels
                         {
                             Topic = _topic
                         }).FirstOrDefault(x=> x.Topic.TopicID==id);

            return View();
        }
      

        [HttpPost]
        public IActionResult Create(int id, ViewModels viewModels)
        {

            var createPost = (from  _topic in _ctx.Topics
                         select new ViewModels
                         {
                          Topic = _topic
                         }).FirstOrDefault(x => x.Topic.TopicID == id);

            var newPost = new Post
            {
                Title = viewModels.Title,
                Description = viewModels.Description,
                TopicID =  createPost.Topic.TopicID
            };

            _ctx.Posts.Add(newPost);
            _ctx.SaveChanges();
            return RedirectToAction("Index", "Home");

        }

        
    }
}
