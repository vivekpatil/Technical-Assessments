using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VideoStore.Models;

namespace VideoStore.Controllers
{
    public class HiresController : Controller
    {
        private VideoDbContext db = new VideoDbContext();

        //
        // GET: /Hires/

        public ActionResult Index()
        {

            return View(db.HireTransactions.ToList());
        }

        //
        // GET: /Hires/Details/5

        public ActionResult Details(int id = 0)
        {
            Hire hire = db.HireTransactions.Find(id);
            if (hire == null)
            {
                return HttpNotFound();
            }
            return View(hire);
        }

        //
        // GET: /Hires/Create

        public ActionResult Create()
        {
            List<SelectListItem> lstUsers = new List<SelectListItem>();
            List<SelectListItem> lstVideos = new List<SelectListItem>();

            var users = (from u in db.Users select u).ToArray();
            for (int i = 0; i < users.Length; i++)
                lstUsers.Add(new SelectListItem { Text = users[i].FirstName + " " + users[i].LastName, Value = users[i].UserId.ToString() });
            ViewBag.UserList = lstUsers;
            //ViewData["UserList"] = lstUsers;

            var videos = (from v in db.Videos select v).ToArray();
            for (int i = 0; i < videos.Length; i++)
                lstVideos.Add(new SelectListItem { Text = videos[i].Title, Value = videos[i].VideoId.ToString() });
            ViewBag.VideoList = lstVideos;
            //ViewData["VideoList"] = lstVideos;
            Hire h = new Hire();
            
            h.User = db.Users.Find(1);
            h.Video = db.Videos.Find(1);
            return View("Create",h);
        }

        //
        // POST: /Hires/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Hire hire)
        {
            hire.UserId = Convert.ToInt32(Request.Form["User"]);
            hire.VideoId = Convert.ToInt32(Request.Form["Video"]);
            hire.User = db.Users.Find(hire.UserId);
            hire.Video = db.Videos.Find(hire.VideoId);
           //if (ModelState.IsValid)
           //     {
                    db.HireTransactions.Add(hire);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                //}

            //return View(hire);
        }

        //
        // GET: /Hires/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Hire hire = db.HireTransactions.Find(id);
            if (hire == null)
            {
                return HttpNotFound();
            }
            return View(hire);
        }

        //
        // POST: /Hires/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Hire hire)
        {
            if (ModelState.IsValid)
            {
                db.Entry(hire).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(hire);
        }

        //
        // GET: /Hires/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Hire hire = db.HireTransactions.Find(id);
            if (hire == null)
            {
                return HttpNotFound();
            }
            return View(hire);
        }

        //
        // POST: /Hires/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Hire hire = db.HireTransactions.Find(id);
            db.HireTransactions.Remove(hire);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}