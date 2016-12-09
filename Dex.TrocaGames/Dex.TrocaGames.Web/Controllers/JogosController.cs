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
using Dex.TrocaGames.Web.ViewModels.Jogo;
using AutoMapper;

namespace Dex.TrocaGames.Web.Controllers
{
    public class JogosController : Controller
    {
        //repo pattern para quebrar acoplamento com bd
        //private TrocaGamesDbContext db = new TrocaGamesDbContext();
        private IRepositorioGenerico<Jogo, long> _repositorio;

        public JogosController(IRepositorioGenerico<Jogo, long> repositorio)
        {
            _repositorio = repositorio;
        }

        // GET: Jogos
        public ActionResult Index()
        {
            List<Jogo> jogos = _repositorio.Select();
            return View(Mapper.Map<List<Jogo>, List<JogoViewModel>>(jogos));
        }

        // GET: Jogos/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Jogo jogo = _repositorio.SelectPorID(id.Value);
            if (jogo == null)
            {
                return HttpNotFound();
            }
            JogoViewModel viewModel = Mapper.Map<Jogo, JogoViewModel>(jogo);
            return View(viewModel);
        }

        // GET: Jogos/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Jogos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Nome,DataLancamento,Genero,FaixaEtaria")] JogoEdicaoViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                Jogo jogo = Mapper.Map<JogoEdicaoViewModel, Jogo>(viewModel);
                _repositorio.Insert(jogo);
                return RedirectToAction("Index");
            }

            return View(viewModel);
        }

        // GET: Jogos/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Jogo jogo = _repositorio.SelectPorID(id.Value);
            if (jogo == null)
            {
                return HttpNotFound();
            }
            JogoEdicaoViewModel viewModel = Mapper.Map<Jogo, JogoEdicaoViewModel>(jogo);
            return View(viewModel);
        }

        // POST: Jogos/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken] //Bind avoid Overpost attack
        public ActionResult Edit([Bind(Include = "Id,Nome,DataLancamento,Genero,FaixaEtaria")] JogoEdicaoViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                _repositorio.Update(Mapper.Map<JogoEdicaoViewModel, Jogo>(viewModel));
                return RedirectToAction("Index");
            }
            return View(viewModel);
        }

        // GET: Jogos/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Jogo jogo = _repositorio.SelectPorID(id.Value);
            if (jogo == null)
            {
                return HttpNotFound();
            }
            JogoEdicaoViewModel viewModel = Mapper.Map<Jogo, JogoEdicaoViewModel>(jogo);
            return View(viewModel);
        }

        // POST: Jogos/Delete/5
        [HttpPost, ActionName("Delete")] // ActionName intercepta independente do nome do método
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            Jogo jogo = _repositorio.SelectPorID(id);
            
            _repositorio.Delete(jogo);
            return RedirectToAction("Index");
        }
    }
}
