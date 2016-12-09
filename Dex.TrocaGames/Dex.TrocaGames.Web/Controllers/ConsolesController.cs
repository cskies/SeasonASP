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
using DexDominio = Dex.TrocaGames.Dominio;
using Dex.Repositorio.Comum;
using Dex.TrocaGames.Repositorio.Entity;

namespace Dex.TrocaGames.Web.Controllers
{
    public class ConsolesController : Controller
    {
        //private TrocaGamesDbContext db = new TrocaGamesDbContext();

        private IRepositorioGenerico<DexDominio.Console, long> _repositorio =
            new RepositorioConsole(new TrocaGamesDbContext());

        // GET: Consoles
        public ActionResult Index()
        {
            return View(_repositorio.Select());
        }

        // GET: Consoles/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Dex.TrocaGames.Dominio.Console console = _repositorio.SelectPorID(id.Value);
            if (console == null)
            {
                return HttpNotFound();
            }
            return View(console);
        }

        // GET: Consoles/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Consoles/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Nome,DataLancamento")] Dex.TrocaGames.Dominio.Console console)
        {
            if (ModelState.IsValid)
            {
                _repositorio.Insert(console);
                return RedirectToAction("Index");
            }

            return View(console);
        }

        // GET: Consoles/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Dex.TrocaGames.Dominio.Console console = _repositorio.SelectPorID(id.Value);
            if (console == null)
            {
                return HttpNotFound();
            }
            return View(console);
        }

        // POST: Consoles/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Nome,DataLancamento")] Dex.TrocaGames.Dominio.Console console)
        {
            if (ModelState.IsValid)
            {
                _repositorio.Update(console);
                return RedirectToAction("Index");
            }
            return View(console);
        }

        // GET: Consoles/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Dex.TrocaGames.Dominio.Console console = _repositorio.SelectPorID(id.Value);
            if (console == null)
            {
                return HttpNotFound();
            }
            return View(console);
        }

        // POST: Consoles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Dex.TrocaGames.Dominio.Console console = _repositorio.SelectPorID(id);
            _repositorio.Delete(console);

            return RedirectToAction("Index");
        }

        
    }
}
