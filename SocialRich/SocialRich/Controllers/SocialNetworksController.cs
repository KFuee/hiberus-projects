using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SocialRich.Models;
using SocialRich.ViewModels;

namespace SocialRich.Controllers
{
    public class SocialNetworksController : Controller
    {
        private SocialContext db = new SocialContext();

        // GET: SocialNetworks
        public ActionResult Index()
        {
            List<SocialNetworksIndexData> socialNetworksList = db.SocialNetworks.Select(socialNetwork =>
                new SocialNetworksIndexData
                {
                    SocialNetworkId = socialNetwork.SocialNetworkId,
                    Name = socialNetwork.Name,
                    Url = socialNetwork.Url,
                    UsersCount = socialNetwork.Users.Count()
                }).ToList();

            return View(socialNetworksList);
        }

        // GET: SocialNetworks/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SocialNetwork socialNetwork = db.SocialNetworks.Find(id);
            if (socialNetwork == null)
            {
                return HttpNotFound();
            }
            return View(socialNetwork);
        }

        // GET: SocialNetworks/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: SocialNetworks/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "SocialNetworkId,Name,Url")] SocialNetwork socialNetwork)
        {
            if (ModelState.IsValid)
            {
                db.SocialNetworks.Add(socialNetwork);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(socialNetwork);
        }

        // GET: SocialNetworks/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SocialNetwork socialNetwork = db.SocialNetworks.Find(id);
            if (socialNetwork == null)
            {
                return HttpNotFound();
            }
            return View(socialNetwork);
        }

        // POST: SocialNetworks/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "SocialNetworkId,Name,Url")] SocialNetwork socialNetwork)
        {
            if (ModelState.IsValid)
            {
                db.Entry(socialNetwork).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(socialNetwork);
        }

        // GET: SocialNetworks/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SocialNetwork socialNetwork = db.SocialNetworks.Find(id);
            if (socialNetwork == null)
            {
                return HttpNotFound();
            }
            return View(socialNetwork);
        }

        // POST: SocialNetworks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            var usersWithFavouriteNetwork = db.Users.Where(user => user.FavouriteSocialNetworkId == id);

            foreach (var user in usersWithFavouriteNetwork)
            {
                user.FavouriteSocialNetworkId = null;
            }

            SocialNetwork socialNetwork = db.SocialNetworks.Find(id);
            db.SocialNetworks.Remove(socialNetwork);

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
    }
}
