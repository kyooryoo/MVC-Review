﻿using Bokly.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Bokly.ViewModels
{
	public class RandomBookViewModel
	{
		public Book Book { get; set; }
		public List<Customer> Customers { get; set; }
	}
}