using Bokly.Models;
using Bokly.ViewModels;
using System.Collections.Generic;
using System.Web.Mvc;

namespace Bokly.Controllers
{
	public class BooksController : Controller
	{
		public ViewResult Index()
		{
			var books = GetBooks();
			return View(books);
		}

		private IEnumerable<Book> GetBooks()
		{
			return new List<Book>
			{
				new Book { Id = 1, Name = "Shrek"},
				new Book { Id = 2, Name = "Wall-e"}
			};
		}
	}
}