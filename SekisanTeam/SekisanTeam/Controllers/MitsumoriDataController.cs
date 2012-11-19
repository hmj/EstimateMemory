using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SekisanTeam.Models;

namespace SekisanTeam.Controllers
{
    public class MitsumoriDataController : Controller
    {
        //
        // GET: /MitsumoriData/

        public ActionResult Index()
        {
            return View();
        }

        //
        // GET: /MitsumoriData/Details/5

        public ActionResult Details(int id)
        {
            return View();
        }

        //
        // GET: /MitsumoriData/Create

        public ActionResult Create()
        {
            return View();
        } 

        //
        // POST: /MitsumoriData/Create

        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
        
        //
        // GET: /MitsumoriData/Edit/5
 
        public ActionResult Edit(int id)
        {
            return View();
        }

        //
        // POST: /MitsumoriData/Edit/5

        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here
 
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /MitsumoriData/Delete/5
 
        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /MitsumoriData/Delete/5

        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
 
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
