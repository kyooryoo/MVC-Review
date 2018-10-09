﻿using System;
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

		[Required]
		public Genre Genre { get; set; }
		public byte GenreId { get; set; }

		public DateTime DateAdded { get; set; }
		public DateTime ReleaseDate { get; set; }
		public byte NumberInStock { get; set; }
	}
}