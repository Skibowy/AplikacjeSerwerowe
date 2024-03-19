using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AS_lab1_gr1.Models;

namespace AS_lab1_gr1.Controllers
{
    public class ArticleController : Controller
    {
        private MyDbContext _db;

        public ArticleController(MyDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            var articles = _db.Articles;
            //_ = _db.Authors.ToList();
            //var authorsList = new List<SelectListItem>();
            /*foreach (var a in authors)
            {
                string text = a.FirstName + " " + a.LastName;
                string id = a.AuthorId.ToString();
                authorsList.Add(new SelectListItem(text, id));
            }
            ViewBag.authorsList = authorsList;*/
            if (articles != null)
            {
                return View(articles);
            }
            return View("ErrorNoData");
        }

        public IActionResult Details(int id)
        {
            _ = _db.Authors;
            var article = _db.Articles.FirstOrDefault(a => a.ArticleId == id);

            if (article != null)
            {
                return View(article);
            }
            return View("ErrorNoData");
        }

        public IActionResult Add()
        {
            var authors = _db.Authors.ToList();
            var authorList = new List<SelectListItem>();
            foreach (var a in authors)
            {
                string text = a.FirstName + " " + a.LastName;
                string id = a.AuthorId.ToString();
                authorList.Add(new SelectListItem(text, id));
            }
            ViewBag.authorList = authorList;

            var tags = _db.Tags.ToList();
            var tagList = new List<SelectListItem>();
            foreach (var t in tags)
            {
                string text = t.Name;
                string id = t.TagId.ToString();
                tagList.Add(new SelectListItem(text, id));
            }
            ViewBag.tagList = tagList;

            return View();
        }

        [HttpPost]
        public IActionResult Add(Article article, List<int> tags)
        {
            if (ModelState.IsValid)
            {
                article.CreationDate = DateTime.Now;
                var articleTags = _db.Tags.Where(t => tags.Contains(t.TagId)).ToList();
                article.Tags = articleTags;

                var author = _db.Authors.FirstOrDefault(a => a.AuthorId == article.AuthorId);
                if (author == null) 
                { 
                    return View("Error");
                }
                article.Author = author;

                _db.Articles.Add(article);

                try
                {
                    _db.SaveChanges();
                }
                catch (Exception ex)
                {
                    return View("ErrorSave");
                }

                return View("Added", article);
            }
            return View("Error");
        }
    }
}
