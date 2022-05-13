using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Restaurantes.Models;

namespace Restaurantes.Controllers
{
    public class RestaurantReviewsController : Controller
    {
        private RestaurantContext db = new RestaurantContext();

        // GET: RestaurantReviews
        public ActionResult Index(long? id)
        {
            RestaurantReviewsIndexViewModel model = new RestaurantReviewsIndexViewModel();

            // Busca el restaurante y lo añade al modelo de la vista
            Restaurant restaurant = db.Restaurants.Find(id);
            model.Restaurant = restaurant;

            List<RestaurantReview> restaurantReviews = restaurant.RestaurantReviews.ToList();
            model.RestaurantReviews = restaurantReviews;

            return View(model);
        }

        // GET: RestaurantReviews/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RestaurantReview restaurantReview = db.RestaurantReviews.Find(id);
            if (restaurantReview == null)
            {
                return HttpNotFound();
            }
            return View(restaurantReview);
        }

        // GET: RestaurantReviews/Create
        public ActionResult Create(long? id)
        {
            ViewBag.RestaurantId = id;
            return View();
        }

        // POST: RestaurantReviews/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "RestaurantReviewId,Rating,Body,ReviewerName,RestaurantId")] RestaurantReview restaurantReview)
        {
            if (restaurantReview.ReviewerName == null)
            {
                restaurantReview.ReviewerName = "Anónimo";
            }

            if (ModelState.IsValid)
            {
                db.RestaurantReviews.Add(restaurantReview);
                db.SaveChanges();
                return RedirectToAction("Index", new { id = restaurantReview.RestaurantId });
            }

            ViewBag.RestaurantId = restaurantReview.RestaurantId;
            return View(restaurantReview);
        }

        // GET: RestaurantReviews/Edit/5
        [Authorize(Roles = "Admin,Develop")]
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RestaurantReview restaurantReview = db.RestaurantReviews.Find(id);
            if (restaurantReview == null)
            {
                return HttpNotFound();
            }
            ViewBag.RestaurantId = new SelectList(db.Restaurants, "RestaurantId", "Name", restaurantReview.RestaurantId);
            return View(restaurantReview);
        }

        // POST: RestaurantReviews/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin,Develop")]
        public ActionResult Edit([Bind(Include = "RestaurantReviewId,Rating,Body,ReviewerName,RestaurantId")] RestaurantReview restaurantReview)
        {
            if (ModelState.IsValid)
            {
                db.Entry(restaurantReview).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index", new { id = restaurantReview.RestaurantId });
            }
            ViewBag.RestaurantId = new SelectList(db.Restaurants, "RestaurantId", "Name", restaurantReview.RestaurantId);
            return View(restaurantReview);
        }

        // GET: RestaurantReviews/Delete/5
        [Authorize(Users = "superadmin@restaurante.com")]
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RestaurantReview restaurantReview = db.RestaurantReviews.Find(id);
            if (restaurantReview == null)
            {
                return HttpNotFound();
            }
            return View(restaurantReview);
        }

        // POST: RestaurantReviews/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Users = "superadmin@restaurante.com")]
        public ActionResult DeleteConfirmed(long id)
        {
            RestaurantReview restaurantReview = db.RestaurantReviews.Find(id);
            db.RestaurantReviews.Remove(restaurantReview);
            db.SaveChanges();
            return RedirectToAction("Index", new { id = restaurantReview.RestaurantId });
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
