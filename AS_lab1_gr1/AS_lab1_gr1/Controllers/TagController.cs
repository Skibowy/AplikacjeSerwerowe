using AS_lab1_gr1.Models;
using Microsoft.AspNetCore.Mvc;

namespace AS_lab1_gr1.Controllers
{
    public class TagController : Controller
    {
        private MyDbContext _db;

        public TagController(MyDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            var tags = _db.Tags!.ToList();
            if (tags != null)
            {
                return View(tags);
            }
            return View("ErrorNoData");
        }

        public IActionResult Details(int id)
        {
            var tag = _db.Tags!
                .FirstOrDefault(t => t.TagId == id);

            if(tag != null)
            {
                return View(tag);
            }
            else
            {
                return View("ErrorNoData");
            }
        }

        public IActionResult AddOrUpdate(int id = -1)
        {

            if (id != -1)
            {
                var tag = _db.Tags!
                    .FirstOrDefault(t => t.TagId == id);
                @ViewBag.Header = "Edytuj tag";
                @ViewBag.ButtonText = "Edytuj";
                return View(tag);
            }
            else
            {
                @ViewBag.Header = "Dodaj tag";
                @ViewBag.ButtonText = "Dodaj";
                return View();
            }
        }

        [HttpPost]
        public IActionResult AddOrUpdate(Tag tag)
        {
            if (tag.TagId != 0)
            {
                var t = _db.Tags!
                    .FirstOrDefault(t => t.TagId == tag.TagId);
                if (t != null)
                {
                    t.Name = tag.Name;
                }
            }
            else
            {
                _db.Tags!.Add(tag);
            }
            _db.SaveChanges();
            return RedirectToAction("Details", new { id = tag.TagId } );
        }
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tag = _db.Tags!
                .FirstOrDefault(t => t.TagId == id);
            if (tag == null)
            {
                return NotFound();
            }
            else
            {
                return View(tag);
            }
        }

        [HttpPost]
		//[ValidateAntiForgeryToken]
		public IActionResult Delete(int id)
        {
            try
            {
                var tag = _db.Tags!
                    .FirstOrDefault(t => t.TagId == id);
                _db.Tags!.Remove(tag!);
                _db.SaveChanges();
            }
            catch
            {

            }
            return RedirectToAction("Index");
        }
    }
}
