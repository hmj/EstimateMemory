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
    public class MemberController : Controller
    {
        private defaultEntity db = new defaultEntity();

        //
        // GET: /Member/

        public ViewResult Index()
        {
            return View(db.T_MEMBER.ToList());
        }

        //
        // GET: /Member/Details/5

        public ViewResult Details(int id)
        {
            T_MEMBER t_member = db.T_MEMBER.Single(t => t.ID == id);
            return View(t_member);
        }

        //
        // GET: /Member/Create

        public ActionResult Create()
        {
            return View();
        } 

        //
        // POST: /Member/Create

        [HttpPost]
        public ActionResult Create(T_MEMBER t_member)
        {
            if (ModelState.IsValid)
            {
                db.T_MEMBER.AddObject(t_member);
                db.SaveChanges();
                return RedirectToAction("Index");  
            }

            return View(t_member);
        }
        
        //
        // GET: /Member/Edit/5
 
        public ActionResult Edit(int id)
        {
            T_MEMBER t_member = db.T_MEMBER.Single(t => t.ID == id);
            return View(t_member);
        }

        //
        // POST: /Member/Edit/5

        [HttpPost]
        public ActionResult Edit(T_MEMBER t_member)
        {
            if (ModelState.IsValid)
            {
                db.T_MEMBER.Attach(t_member);
                db.ObjectStateManager.ChangeObjectState(t_member, EntityState.Modified);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(t_member);
        }

        //
        // GET: /Member/Delete/5
 
        public ActionResult Delete(int id)
        {
            T_MEMBER t_member = db.T_MEMBER.Single(t => t.ID == id);
            return View(t_member);
        }

        //
        // POST: /Member/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {            
            T_MEMBER t_member = db.T_MEMBER.Single(t => t.ID == id);
            db.T_MEMBER.DeleteObject(t_member);
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