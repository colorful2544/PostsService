using Microsoft.AspNetCore.Mvc;
using PostsService.Interface;
using PostsService.ViewModels.PostServiceViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PostsService.Controllers
{
    public class PostController : Controller
    {
        private readonly IPostService _postService;

        public PostController(IPostService postService)
        {
            _postService = postService;
        }

        public IActionResult Index()
        {
            var result = _postService.Get();
            return View(result);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(PostRequest request)
        {
            //Console.WriteLine(request.imagesList.Count);
            if (ModelState.IsValid)
            {
                if (!string.IsNullOrEmpty(request.Name) || !string.IsNullOrEmpty(request.detail) || !(request.imagesList == null))
                {
                    string postId = _postService.Create(request);
                    if (!string.IsNullOrEmpty(postId)) return RedirectToAction(nameof(Index));
                }
            }
            return View(request);
        }
    }
}
