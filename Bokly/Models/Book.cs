using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Bokly.Models
{
	public class Book
	{
		// input prop then press tab to quickly create properties
		public int Id { get; set; }

		[Required]
		[StringLength(255)]
		public string Name { get; set; }

		public Genre Genre { get; set; }

		[Display(Name = "Genre")]
		[Required]
		public byte GenreId { get; set; }

		public DateTime DateAdded { get; set; }

		[Display(Name = "Release Date")]
		[Required]
		public DateTime ReleaseDate { get; set; }

		[Display(Name = "Number in Stock")]
		[Range(1, 20)]
		[Required]
		public byte NumberInStock { get; set; }
	}
}