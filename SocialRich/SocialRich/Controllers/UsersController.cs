using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SocialRich.Models;
using SocialRich.ViewModels;

namespace SocialRich.Controllers
{
    public class UsersController : Controller
    {
        private SocialContext db = new SocialContext();

        // GET: Users
        public ActionResult Index()
        {
            List<UsersIndexData> usersList = db.Users
                .Include(user => user.FavouriteSocialNetwork)
                .Select(user =>
                new UsersIndexData
                {
                    UserId = user.UserId,
                    Name = user.Name,
                    Surname = user.Surname,
                    FavouriteSocialNetwork = user.FavouriteSocialNetwork,
                    SocialNetworksCount = user.SocialNetworks.Count()
                }).ToList();

            return View(usersList);
        }

        // GET: Users/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User user = db.Users.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        // GET: Users/Create
        public ActionResult Create()
        {
            ViewBag.SocialNetworksMultiple =
                new MultiSelectList(db.SocialNetworks, "SocialNetworkId", "Name");
            return View();
        }

        // POST: Users/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(
            [Bind(Include = "UserId,Name,Surname,FavouriteSocialNetworkId")] User user,
            string[] SocialNetworksMultiple)
        {
            UpdateSocialNetworks(user, SocialNetworksMultiple);

            // Establece la primera red social seleccionada como favorita
            if (SocialNetworksMultiple != null)
            {
                user.FavouriteSocialNetworkId = int.Parse(SocialNetworksMultiple[0]);
            }

            if (ModelState.IsValid)
            {
                db.Users.Add(user);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.SocialNetworksMultiple =
                new MultiSelectList(db.SocialNetworks, "SocialNetworkId", "Name");
            return View(user);
        }

        // GET: Users/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            User user = db.Users.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }

            PopulateSocialNetworksLists(user);
            return View(user);
        }

        // POST: Users/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(
            [Bind(Include = "UserId,Name,Surname,FavouriteSocialNetworkId")] User user, 
            string[] SocialNetworksMultiple)
        {
            var userToUpdate = db.Users
                .Include(u => u.FavouriteSocialNetwork)
                .Include(u => u.SocialNetworks)
                .Where(u => u.UserId == user.UserId)
                .Single();

            if (TryUpdateModel(userToUpdate, "",
                new string[] { "UserId" , "Name", "Surname", "FavouriteSocialNetworkId" }))
            {
                try
                {
                    UpdateSocialNetworks(userToUpdate, SocialNetworksMultiple);

                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                catch (RetryLimitExceededException)
                {
                    ModelState.AddModelError("DbERR", "Ha ocurrido un error actualizando el usuario");
                }
            }

            PopulateSocialNetworksLists(user);
            return View(user);
        }

        // GET: Users/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User user = db.Users.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        // POST: Users/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            User user = db.Users.Find(id);
            db.Users.Remove(user);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        public void PopulateSocialNetworksLists(User user)
        {
            var userSocialNetworks = user.SocialNetworks.Select(sn => sn.SocialNetworkId);

            ViewBag.FavouriteSocialNetworkId =
                new SelectList(user.SocialNetworks, "SocialNetworkId", "Name", user.FavouriteSocialNetworkId);
            ViewBag.SocialNetworksMultiple =
                new MultiSelectList(db.SocialNetworks, "SocialNetworkId", "Name", userSocialNetworks);
        }

        public void UpdateSocialNetworks(User userToUpdate, string[] selectedSocialNetworks)
        {
            if (selectedSocialNetworks == null)
            {
                return;
            }

            userToUpdate.SocialNetworks = new List<SocialNetwork>();
            foreach (string socialNetwork in selectedSocialNetworks)
            {
                var socialNetworkQuery = db.SocialNetworks.Find(int.Parse(socialNetwork));
                userToUpdate.SocialNetworks.Add(socialNetworkQuery);
            }
        }
    }
}
