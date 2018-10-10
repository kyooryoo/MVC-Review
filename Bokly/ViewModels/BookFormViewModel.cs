using Bokly.Models;
using System.Collections.Generic;

namespace Bokly.ViewModels
{
	public class BookFormViewModel
	{
		public IEnumerable<Genre> Generes { get; set; }
		public Book Book { get; set; }
		public string Title
		{
			get
			{
				if (Book != null && Book.Id != 0)
					return "Edit Book";
				return "New Book";
			}
		}

		public List<Genre> Genres { get; internal set; }
	}
}