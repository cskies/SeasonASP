using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Dex.TrocaGames.AcessoDados.Entity.Context;
using Dex.TrocaGames.Dominio;

namespace Dex.TrocaGames.Web.Controllers
{
    public class ProjetoresController : Controller
    {
        private TrocaGamesDbContext db = new TrocaGamesDbContext();

        // GET: Projetores
        public ActionResult Index()
        {
            return View(db.Projetores.ToList());
        }

        // GET: Projetores/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Projetor projetor = db.Projetores.Find(id);
            if (projetor == null)
            {
                return HttpNotFound();
            }
            return View(projetor);
        }

        // GET: Projetores/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Projetores/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Nome,Marca,DataCompra")] Projetor projetor)
        {
            if (ModelState.IsValid)
            {
                db.Projetores.Add(projetor);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(projetor);
        }

        // GET: Projetores/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Projetor projetor = db.Projetores.Find(id);
            if (projetor == null)
            {
                return HttpNotFound();
            }
            return View(projetor);
        }

        // POST: Projetores/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Nome,Marca,DataCompra")] Projetor projetor)
        {
            if (ModelState.IsValid)
            {
                db.Entry(projetor).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(projetor);
        }

        // GET: Projetores/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Projetor projetor = db.Projetores.Find(id);
            if (projetor == null)
            {
                return HttpNotFound();
            }
            return View(projetor);
        }

        // POST: Projetores/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Projetor projetor = db.Projetores.Find(id);
            db.Projetores.Remove(projetor);
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
