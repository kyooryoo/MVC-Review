using Bokly.Models;
using System.Web.Mvc;

namespace Bokly.Controllers
{
	public class BookController : Controller
	{
		// GET: Movie/Random
		public ActionResult Random()
		{
			var book = new Book() { Name = "Shrek!" };
			return View(book);
		}
	}
}