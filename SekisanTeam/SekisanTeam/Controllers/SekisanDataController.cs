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
    public class SekisanDataController : Controller
    {
        private defaultEntity db = new defaultEntity();

        //
        // GET: /SekisanData/

        public ViewResult Index()
        {
            var t_sekisan_data = db.T_SEKISAN_DATA.Include("T_CLIENT").Include("T_MASTER_DIFFICULT").Include("T_MASTER_RATE").Include("T_MEMBER");
            return View(t_sekisan_data.ToList());
        }

        //
        // GET: /SekisanData/Details/5

        public ViewResult Details(int id)
        {
            T_SEKISAN_DATA t_sekisan_data = db.T_SEKISAN_DATA.Single(t => t.ID == id);
            return View(t_sekisan_data);
        }

        //
        // GET: /SekisanData/Create

        public ActionResult Create()
        {
            ViewBag.ID_CLIENT = new SelectList(db.T_CLIENT, "ID", "NAME");
            ViewBag.ID_DIFFICULT = new SelectList(db.T_MASTER_DIFFICULT, "ID", "NAME");
            ViewBag.ID_RATIO = new SelectList(db.T_MASTER_RATE, "ID", "NAME");
            ViewBag.ID = new SelectList(db.T_MEMBER, "ID", "NAME");
            return View();
        } 

        //
        // POST: /SekisanData/Create

        [HttpPost]
        public ActionResult Create(T_SEKISAN_DATA t_sekisan_data)
        {
            if (ModelState.IsValid)
            {
                db.T_SEKISAN_DATA.AddObject(t_sekisan_data);
                db.SaveChanges();
                return RedirectToAction("Index");  
            }

            ViewBag.ID_CLIENT = new SelectList(db.T_CLIENT, "ID", "NAME", t_sekisan_data.ID_CLIENT);
            ViewBag.ID_DIFFICULT = new SelectList(db.T_MASTER_DIFFICULT, "ID", "NAME", t_sekisan_data.ID_DIFFICULT);
            ViewBag.ID_RATIO = new SelectList(db.T_MASTER_RATE, "ID", "NAME", t_sekisan_data.ID_RATIO);
            ViewBag.ID = new SelectList(db.T_MEMBER, "ID", "NAME", t_sekisan_data.ID);
            return View(t_sekisan_data);
        }
        
        //
        // GET: /SekisanData/Edit/5
 
        public ActionResult Edit(int id)
        {
            T_SEKISAN_DATA t_sekisan_data = db.T_SEKISAN_DATA.Single(t => t.ID == id);
            ViewBag.ID_CLIENT = new SelectList(db.T_CLIENT, "ID", "CODE", t_sekisan_data.ID_CLIENT);
            ViewBag.ID_DIFFICULT = new SelectList(db.T_MASTER_DIFFICULT, "ID", "CODE", t_sekisan_data.ID_DIFFICULT);
            ViewBag.ID_RATIO = new SelectList(db.T_MASTER_RATE, "ID", "CODE", t_sekisan_data.ID_RATIO);
            ViewBag.ID = new SelectList(db.T_MEMBER, "ID", "CODE", t_sekisan_data.ID);
            return View(t_sekisan_data);
        }

        //
        // POST: /SekisanData/Edit/5

        [HttpPost]
        public ActionResult Edit(T_SEKISAN_DATA t_sekisan_data)
        {
            if (ModelState.IsValid)
            {
                db.T_SEKISAN_DATA.Attach(t_sekisan_data);
                db.ObjectStateManager.ChangeObjectState(t_sekisan_data, EntityState.Modified);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ID_CLIENT = new SelectList(db.T_CLIENT, "ID", "CODE", t_sekisan_data.ID_CLIENT);
            ViewBag.ID_DIFFICULT = new SelectList(db.T_MASTER_DIFFICULT, "ID", "CODE", t_sekisan_data.ID_DIFFICULT);
            ViewBag.ID_RATIO = new SelectList(db.T_MASTER_RATE, "ID", "CODE", t_sekisan_data.ID_RATIO);
            ViewBag.ID = new SelectList(db.T_MEMBER, "ID", "CODE", t_sekisan_data.ID);
            return View(t_sekisan_data);
        }

        //
        // GET: /SekisanData/Delete/5
 
        public ActionResult Delete(int id)
        {
            T_SEKISAN_DATA t_sekisan_data = db.T_SEKISAN_DATA.Single(t => t.ID == id);
            return View(t_sekisan_data);
        }

        //
        // POST: /SekisanData/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {            
            T_SEKISAN_DATA t_sekisan_data = db.T_SEKISAN_DATA.Single(t => t.ID == id);
            db.T_SEKISAN_DATA.DeleteObject(t_sekisan_data);
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