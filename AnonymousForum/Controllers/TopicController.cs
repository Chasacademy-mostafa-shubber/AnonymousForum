using AnonymousForum.Data;
using AnonymousForum.Models;
using Microsoft.AspNetCore.Mvc;

namespace AnonymousForum.Controllers
{
    public class TopicController : Controller
    {
        private readonly ForumDBContext _ctx;

        public TopicController(ForumDBContext ctx)
        {
            _ctx = ctx;
        }

   
        public IActionResult Index()
        {
           var query = (from _topic in _ctx.Topics
                       select new ViewModels
                       {
                           Topic = _topic,
                       }).ToList();
            
           return View(query);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(ViewModels viewmodels)
        {
            var topic = new Topic
            {
                Name = viewmodels.Topic.Name
                
                
            };

            _ctx.Topics.Add(topic);
            _ctx.SaveChanges();
            return RedirectToAction("Index");
        }

      



    }
}
