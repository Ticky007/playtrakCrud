﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Playtrak;

namespace Playtrak.Controllers
{
    public class tblEmpleadosController : Controller
    {
        private PlaytrakCrudEntities db = new PlaytrakCrudEntities();

        // GET: tblEmpleados
        public ActionResult Index()
        {
            return View(db.tblEmpleados.ToList());
        }

        // GET: tblEmpleados/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblEmpleados tblEmpleados = db.tblEmpleados.Find(id);
            if (tblEmpleados == null)
            {
                return HttpNotFound();
            }
            return View(tblEmpleados);
        }

        // GET: tblEmpleados/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: tblEmpleados/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Nombres,Apellidos")] tblEmpleados tblEmpleados)
        {
            if (ModelState.IsValid)
            {
                db.tblEmpleados.Add(tblEmpleados);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tblEmpleados);
        }

        // GET: tblEmpleados/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblEmpleados tblEmpleados = db.tblEmpleados.Find(id);
            if (tblEmpleados == null)
            {
                return HttpNotFound();
            }
            return View(tblEmpleados);
        }

        // POST: tblEmpleados/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Nombres,Apellidos")] tblEmpleados tblEmpleados)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tblEmpleados).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tblEmpleados);
        }

        // GET: tblEmpleados/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblEmpleados tblEmpleados = db.tblEmpleados.Find(id);
            if (tblEmpleados == null)
            {
                return HttpNotFound();
            }
            return View(tblEmpleados);
        }

        // POST: tblEmpleados/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tblEmpleados tblEmpleados = db.tblEmpleados.Find(id);
            db.tblEmpleados.Remove(tblEmpleados);
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
