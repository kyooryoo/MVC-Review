using Bokly.Models;
using Bokly.ViewModels;
using System.Collections.Generic;
using System.Web.Mvc;
using System.Data.Entity;
using System.Linq;
using System;

namespace Bokly.Controllers
{
	public class BooksController : Controller
	{
		public ApplicationDbContext _context;

		public BooksController()
		{
			_context = new ApplicationDbContext();
		}

		protected override void Dispose(bool disposing)
		{
			_context.Dispose();
		}

		public ViewResult Index()
		{
			var books = _context.Books.Include(b => b.Genre).ToList();
			return View(books);
		}

		public ActionResult Details(int id)
		{
			var book = _context.Books.Include(b => b.Genre).SingleOrDefault(b => b.Id == id);
			if (book == null)
			{
				return HttpNotFound();
			}
			return View(book);
		}

		public ViewResult New()
		{
			var genres = _context.Genres.ToList();
			var viewModel = new BookFormViewModel
			{
				Genres = genres
			};
			return View("BookForm", viewModel);
		}

		public ActionResult Edit(int id)
		{
			var book = _context.Books.SingleOrDefault(c => c.Id == id);
			if (book == null) return HttpNotFound();
			var viewModel = new BookFormViewModel()
			{
				Book = book,
				Genres = _context.Genres.ToList()
			};
			return View("BookForm", viewModel);
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Save(Book book)
		{
			if (book.Id == 0)
			{
				book.DateAdded = DateTime.Now;
				_context.Books.Add(book);
			}
			else
			{
				var bookInDb = _context.Books.Single(m => m.Id == book.Id);
				bookInDb.Name = book.Name;
				bookInDb.GenreId = book.GenreId;
				bookInDb.NumberInStock = book.NumberInStock;
				bookInDb.ReleaseDate = book.ReleaseDate;
			}
			_context.SaveChanges();
			return RedirectToAction("Index", "Books");
		}
	}
}