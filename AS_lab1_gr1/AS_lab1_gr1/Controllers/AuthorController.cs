using AS_lab1_gr1.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

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
            var authors = _db.Authors.ToList();
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
                // return PartialView(author);
            }
            return View("ErrorNoData");
        }

        public IActionResult AddOrUpdate(int id = -1)
        {

            if (id != -1)
            {
                var author = _db.Authors!
                    .FirstOrDefault(a => a.AuthorId == id);
                @ViewBag.Header = "Edytuj autora";
                @ViewBag.ButtonText = "Edytuj";
                return View(author);
            }
            else
            {
                @ViewBag.Header = "Dodaj autora";
                @ViewBag.ButtonText = "Dodaj";
                return View();
            }

        }

        [HttpPost]
        public IActionResult AddOrUpdate(Author author)
        {
            if (author.AuthorId != 0)
            {
                var a = _db.Authors!.FirstOrDefault(a => a.AuthorId == author.AuthorId);
                if (a != null)
                {
                    a.FirstName = author.FirstName;
                    a.LastName = author.LastName;
                }
            }
            else
            {
                _db.Authors!.Add(author);
            }
            _db.SaveChanges();
            return RedirectToAction("Details", new { id = author.AuthorId });
        }

		public IActionResult Delete(int? id)
		{
			if (id == null)
			{
				return NotFound();
			}

			var author = _db.Authors!
				.FirstOrDefault(a => a.AuthorId == id);
			if (author == null)
			{
				return NotFound();
			}

			return View(author);
		}

		[HttpPost]
		//[ValidateAntiForgeryToken]
		public IActionResult Delete(int id)
		{
			try
			{
                // usuwanie autora bez usuwania artykułów
				var author = _db.Authors!
					.FirstOrDefault(a => a.AuthorId == id);
				_db.Authors!.Remove(author!);
				_db.SaveChanges();
			}
			catch (Exception ex)
			{

			}
			return RedirectToAction("Index");
		}
	}
}
