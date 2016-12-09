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
using Dex.Repositorio.Comum;
using Dex.TrocaGames.Repositorio.Entity;

namespace Dex.TrocaGames.Web.Controllers
{
    public class LugaresController : Controller
    {
        //private TrocaGamesDbContext db = new TrocaGamesDbContext();
        private IRepositorioGenerico<Lugar, long> _repositorio =
            new RepositorioLugar(new TrocaGamesDbContext());
        
        // GET: Lugares
        public ActionResult Index()
        {
            return View(_repositorio.Select());
        }

        // GET: Lugares/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Lugar lugar = _repositorio.SelectPorID(id.Value);
            if (lugar == null)
            {
                return HttpNotFound();
            }
            return View(lugar);
        }

        // GET: Lugares/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Lugares/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Nome,Endereco")] Lugar lugar)
        {
            if (ModelState.IsValid)
            {
                _repositorio.Insert(lugar);
                return RedirectToAction("Index");
            }

            return View(lugar);
        }

        // GET: Lugares/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Lugar lugar = _repositorio.SelectPorID(id.Value);
            if (lugar == null)
            {
                return HttpNotFound();
            }
            return View(lugar);
        }

        // POST: Lugares/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Nome,Endereco")] Lugar lugar)
        {
            if (ModelState.IsValid)
            {
                _repositorio.Update(lugar);
                return RedirectToAction("Index");
            }
            return View(lugar);
        }

        // GET: Lugares/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Lugar lugar = _repositorio.SelectPorID(id.Value);
            if (lugar == null)
            {
                return HttpNotFound();
            }
            return View(lugar);
        }

        // POST: Lugares/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Lugar lugar = _repositorio.SelectPorID(id);
            _repositorio.Delete(lugar);
            return RedirectToAction("Index");
        }
    }
}
