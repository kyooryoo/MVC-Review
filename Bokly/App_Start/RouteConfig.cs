using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Bokly
{
	public class RouteConfig
	{
		public static void RegisterRoutes(RouteCollection routes)
		{
			routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

			//// use attribute routes to avoid creating specific routing rules
			//routes.MapRoute(
			//	"BooksByPublishDate",
			//	"book/published/{year}/{month}",
			//	new { controller = "Book", action = "ByPublishDate" },
			//	new { year = @"\d{4}", month = @"\d{2}" });

			routes.MapMvcAttributeRoutes();

			routes.MapRoute(
				name: "Default",
				// request to URL of /books/popular will call action or method of Popular() in BooksController
				// request to URL of /books/edit/1 will call action or method of Edit(int id) in BooksController
				url: "{controller}/{action}/{id}",
				// Home and Index are the default values, if no controller or action is specified
				defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
			);
		}
	}
}
