﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using AS_lab1_gr1.Models;
using Microsoft.EntityFrameworkCore;

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
            var articles = _db.Articles.ToList();
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
            //_ = _db.Authors;
            var article = _db.Articles.FirstOrDefault(a => a.ArticleId == id);

            if (article != null)
            {
                return View(article);
            }
            return View("ErrorNoData");
        }

        public IActionResult AddOrUpdate(int id = -1)
        {
			var authors = _db.Authors.ToList();
			var authorList = new List<SelectListItem>();
			foreach (var a in authors)
			{
				string text = a.FirstName + " " + a.LastName;
				string authorId = a.AuthorId.ToString();
				authorList.Add(new SelectListItem(text, authorId));
			}
			ViewBag.authorList = authorList;

			var tags = _db.Tags.ToList();
			var tagList = new List<SelectListItem>();
			foreach (var t in tags)
			{
				string text = t.Name;
				string tagId = t.TagId.ToString();
				tagList.Add(new SelectListItem(text, tagId));
			}
			ViewBag.tagList = tagList;

			var categories = _db.Categories.ToList();
            var categoryList = new List<SelectListItem>();
            foreach (var c in categories)
            {
                string text = c.Name;
                string authorId = c.CategoryId.ToString();
                categoryList.Add(new SelectListItem(text, authorId));
            }
            ViewBag.categoryList = categoryList;

            if (id != -1)
            {
				var article = _db.Articles!
					.FirstOrDefault(a => a.ArticleId == id);
				var checkedList = article?.Tags?.ToList();
				var checkedTagList = new List<SelectListItem>();
				foreach (var t in checkedList)
				{
					string text = t.Name;
					string tagId = t.TagId.ToString();
					checkedTagList.Add(new SelectListItem(text, tagId));
				}
				ViewBag.checkedTagList = checkedTagList;

				@ViewBag.Header = "Edytuj artykuł";
				@ViewBag.ButtonText = "Edytuj";
				return View(article);
            }
            else
            {
				@ViewBag.Header = "Dodaj artykuł";
				@ViewBag.ButtonText = "Dodaj";
				return View();
			}
        }

        [HttpPost]
        public IActionResult AddOrUpdate(Article article, List<int> tags)
        {
			if (article.ArticleId != 0)
			{
				var a = _db.Articles!.Include(t => t.Tags).FirstOrDefault(a => a.ArticleId == article.ArticleId);
				if (a != null)
				{
					a.Title = article.Title;
                    a.Lead = article.Lead;
                    a.Content = article.Content;
                    a.CreationDate = article.CreationDate;
					var articleTags2 = new List<Tag>();
					var articleTags = _db.Tags.ToList();
					foreach (var t in articleTags)
					{
						if (tags.Contains(t.TagId))
						{
							articleTags2.Add(t);
						}
					}
					a.Tags = articleTags2;
					var author = _db.Authors.FirstOrDefault(author => author.AuthorId == article.AuthorId);
					if (author == null)
					{
						return View("Error");
					}
					a.Author = author;
					var category = _db.Categories.FirstOrDefault(category => category.CategoryId == article.CategoryId);
					if (category == null)
					{
						return View("Error");
					}
					a.Category = category;
				}
			}
			else
			{
				article.CreationDate = DateTime.Now;
				var articleTags2 = new List<Tag>();
				var articleTags = _db.Tags.ToList();
				foreach (var t in articleTags)
				{
					if (tags.Contains(t.TagId))
					{
						articleTags2.Add(t);
					}
				}
				article.Tags = articleTags2;
				_db.Articles!.Add(article);
			}
			_db.SaveChanges();
			return RedirectToAction("Details", new { id = article.ArticleId });
        }

		public IActionResult Delete(int? id)
		{
			if (id == null)
			{
				return NotFound();
			}

			var article = _db.Articles!
				.FirstOrDefault(a => a.ArticleId == id);
			if (article == null)
			{
				return NotFound();
			}

			return View(article);
		}

		[HttpPost]
		//[ValidateAntiForgeryToken]
		public IActionResult Delete(int id)
		{
			try
			{
				var article = _db.Articles!.Where(a => a.ArticleId == id)
					.FirstOrDefault();
				_db.Articles!.Remove(article!);
				_db.SaveChanges();
			}
			catch (Exception ex)
			{

			}
			return RedirectToAction("Index");
		}
	}
}
