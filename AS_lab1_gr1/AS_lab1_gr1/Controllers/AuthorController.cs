using AS_lab1_gr1.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace AS_lab1_gr1.Controllers
{
    public class AuthorController : Controller
    {
        private MyDbContext _db;

        public AuthorController(MyDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            var authors = _db.Authors;
            if (authors != null)
            {
                return View(authors);
            }
            return View("ErrorNoData");
        }

        public IActionResult Details(int id)
        {
            var author = _db.Authors.FirstOrDefault(a => a.AuthorId == id);

            if (author != null)
            {
                return View(author);
            }
            return View("ErrorNoData");
        }

        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(Author author)
        {
            if (ModelState.IsValid)
            {
                _db.Authors.Add(author);

                try
                {
                    _db.SaveChanges();
                }
                catch (Exception ex)
                {
                    return View("ErrorSave");
                }

                return View("Added", author);
            }
            return View("Error");
        }
    }
}
