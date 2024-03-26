using AS_lab1_gr1.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AS_lab1_gr1.Controllers
{
	public class CategoryController : Controller
	{
		private MyDbContext _db;

		public CategoryController(MyDbContext db)
		{
			_db = db;
		}

		public IActionResult Index()
		{
			var categories = _db.Categories.ToList();
			if (categories != null)
			{
				return View(categories);
			}
			return View("ErrorNoData");
		}

		public IActionResult Details(int id)
		{
			var category = _db.Categories
				.FirstOrDefault(c => c.CategoryId == id);
			if (category != null)
			{
				return View(category);
			}
			return View("ErrorNoData");
		}

		public IActionResult AddOrUpdate(int id = -1)
		{
			if (id != -1)
			{
				var category = _db.Categories
					.FirstOrDefault(c => c.CategoryId == id);
				@ViewBag.Header = "Edytuj kategorię";
				@ViewBag.ButtonText = "Edytuj";
				return View(category);
			}
			else
			{
				ViewBag.Header = "Dodaj kategorię";
				ViewBag.ButtonText = "Dodaj";
				return View();
			}
		}

		[HttpPost]
		public IActionResult AddOrUpdate(Category category)
		{
			if (category.CategoryId != 0)
			{
				var c = _db.Categories
					.FirstOrDefault(c => c.CategoryId == category.CategoryId);
				if (c != null)
				{
					c.Name = category.Name;
				}
			}
			else
			{
				_db.Categories!.Add(category);
			}
			_db.SaveChanges();
			return RedirectToAction("Details", new { id = category.CategoryId });
		}

		public ActionResult Delete(int? id)
		{
			if (id == null)
			{
				return NotFound();
			}

			var category = _db.Categories!
				.FirstOrDefault(c => c.CategoryId == id);
			if (category == null)
			{
				return NotFound();
			}

			return View(category);
		}

		[HttpPost]
        //[ValidateAntiForgeryToken]
        public IActionResult Delete(int id)
		{
			try
			{
				var category = _db.Categories!
					.Where(c => c.CategoryId == id)
					.Include(a => a.Articles)
					.FirstOrDefault();
				category!.Articles = null;
				_db.Categories!.Remove(category!);
				_db.SaveChanges();
			}
			catch (Exception ex)
			{

			}
			return RedirectToAction("Index");
		}
	}
}
