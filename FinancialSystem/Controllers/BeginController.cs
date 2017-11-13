using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FinancialSystem.Controllers
{
    public class BeginController : Controller
    {
        // GET: Begin
        public ActionResult Index()
        {
            return View();
        }

        // GET: Begin/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Begin/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Begin/Create
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

        // GET: Begin/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Begin/Edit/5
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

        // GET: Begin/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Begin/Delete/5
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
