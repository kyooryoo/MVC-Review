using Bokly.Models;
using Bokly.ViewModels;
using System.Collections.Generic;
using System.Web.Mvc;
using System.Data.Entity;
using System.Linq;

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
	}
}