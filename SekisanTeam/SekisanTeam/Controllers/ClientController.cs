using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SekisanTeam.Models;

namespace SekisanTeam.Controllers
{ 
    public class ClientController : Controller
    {
        private defaultEntity db = new defaultEntity();

        //
        // GET: /Client/

        public ViewResult Index()
        {
            return View(db.T_CLIENT.ToList());
        }

        //
        // GET: /Client/Details/5

        public ViewResult Details(int id)
        {
            T_CLIENT t_client = db.T_CLIENT.Single(t => t.ID == id);
            return View(t_client);
        }

        //
        // GET: /Client/Create

        public ActionResult Create()
        {
            return View();
        } 

        //
        // POST: /Client/Create

        [HttpPost]
        public ActionResult Create(T_CLIENT t_client)
        {
            if (ModelState.IsValid)
            {
                db.T_CLIENT.AddObject(t_client);
                db.SaveChanges();
                return RedirectToAction("Index");  
            }

            return View(t_client);
        }
        
        //
        // GET: /Client/Edit/5
 
        public ActionResult Edit(int id)
        {
            T_CLIENT t_client = db.T_CLIENT.Single(t => t.ID == id);
            return View(t_client);
        }

        //
        // POST: /Client/Edit/5

        [HttpPost]
        public ActionResult Edit(T_CLIENT t_client)
        {
            if (ModelState.IsValid)
            {
                db.T_CLIENT.Attach(t_client);
                db.ObjectStateManager.ChangeObjectState(t_client, EntityState.Modified);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(t_client);
        }

        //
        // GET: /Client/Delete/5
 
        public ActionResult Delete(int id)
        {
            T_CLIENT t_client = db.T_CLIENT.Single(t => t.ID == id);
            return View(t_client);
        }

        //
        // POST: /Client/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {            
            T_CLIENT t_client = db.T_CLIENT.Single(t => t.ID == id);
            db.T_CLIENT.DeleteObject(t_client);
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