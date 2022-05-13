using Restaurantes.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;

namespace Restaurantes.Controllers
{
    public class HomeController : Controller
    {
        private RestaurantContext db = new RestaurantContext();

        public ViewResult Index(string currentFilter, string searchTerm, int? page)
        {
            if (searchTerm != null)
            {
                page = 1;
            } else
            {
                searchTerm = currentFilter;
            }

            ViewBag.CurrentFilter = searchTerm;

            var restaurants = from r in db.Restaurants
                              select r;

            if (!string.IsNullOrEmpty(searchTerm))
            {
                restaurants = restaurants
                    .Where(restaurant => restaurant.Name.Contains(searchTerm));
            }

            restaurants = restaurants
                .OrderByDescending(restaurant => restaurant.RestaurantReviews.Average(review => review.Rating));

            int pageSize = 10;
            int pageNumber = (page ?? 1);
            return View(restaurants.ToPagedList(pageNumber, pageSize));
        }
    }
}