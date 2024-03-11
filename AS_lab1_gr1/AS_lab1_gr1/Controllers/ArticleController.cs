using Microsoft.AspNetCore.Mvc;
using AS_lab1_gr1.Models;

namespace AS_lab1_gr1.Controllers
{
    public class ArticleController : Controller
    {
        
        public IActionResult Index(int id=1)
        {
            var articles = new List<Article>
            {
                new Article
                {
                    ArticleId = 1,
                    Title = "Artykuł 1",
                    Content = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.",
                    CreationDate = DateTime.Now
                },
                new Article
                {
                    ArticleId = 2,
                    Title = "Artykuł 2",
                    Content = "Lorem 2 ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.",
                    CreationDate = DateTime.Now
                },new Article
                {
                    ArticleId = 3,
                    Title = "Artykuł 3",
                    Content = "Lorem 3 ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.",
                    CreationDate = DateTime.Now
                }
            };
            
            return View(articles[id-1]);
        }
    }
}
