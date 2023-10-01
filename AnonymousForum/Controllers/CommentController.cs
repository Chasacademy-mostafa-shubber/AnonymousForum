using AnonymousForum.Data;
using AnonymousForum.Models;
using Microsoft.AspNetCore.Mvc;

namespace AnonymousForum.Controllers
{
    public class CommentController : Controller
    {
        private readonly ForumDBContext _ctx;

        public CommentController(ForumDBContext ctx)
        {
            _ctx = ctx;
        }

        public IActionResult Index(int id)
        {
            var postDetails = (from _post in _ctx.Posts
                               select new ViewModels
                               {
                                   Post = _post
                               }).FirstOrDefault(x=> x.Post.PostID==id);

            ViewBag.commentList = (from _comment in _ctx.Comments
                                   select new ViewModels
                                   {
                                       Comment = _comment
                                   }).Where(x=> x.Comment.PostID==id).ToList();
            return View(postDetails);
        }

        public IActionResult Create(int id)
        {
            var post = (from _post in _ctx.Posts
                        select new ViewModels
                        {
                            Post = _post
                        }).FirstOrDefault(x=> x.Post.PostID==id);


            return View();
        }

        [HttpPost]
        public IActionResult Create(int id, ViewModels viewModels)
        {
            var post = (from _post in _ctx.Posts
                        select new ViewModels
                        {
                            Post = _post
                        }).FirstOrDefault(x => x.Post.PostID == id);

            var newComment = new Comment
            {
                Title = viewModels.Title,
                Description = viewModels.Description,
                PostID = post.Post.PostID
            };

            _ctx.Comments.Add(newComment);
            _ctx.SaveChanges();

            return RedirectToAction("Index", "Home");
        }

    }
}
