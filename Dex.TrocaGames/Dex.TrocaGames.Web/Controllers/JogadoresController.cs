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
using Dex.TrocaGames.Repositorio.Entity;
using Dex.Repositorio.Comum;
using AutoMapper;
using Dex.TrocaGames.Web.ViewModels.Jogador;

namespace Dex.TrocaGames.Web.Controllers
{
    public class JogadoresController : Controller
    {
        private IRepositorioGenerico<Jogador, int> _repositorioJogador;

        private IRepositorioGenerico<Jogo, long> _repositorioJogo
            = new RepositorioJogo(new TrocaGamesDbContext());

        public JogadoresController(IRepositorioGenerico<Jogador, int> repositorioJogador, 
            IRepositorioGenerico<Jogo, long> repositorioJogo)
        {
            _repositorioJogador = repositorioJogador;
            _repositorioJogo = repositorioJogo;
        }

        // GET: Jogadores
        public ActionResult Index()
        {
            List<Jogador> jogadores = _repositorioJogador.Select();
            return View(Mapper.Map<List<Jogador>, List<JogadorViewModel>>(jogadores));
        }

        //apontando para json
        public ActionResult PesquisarPorNome(string nomeJogador) 
        {
            List<Jogador> jogadores = _repositorioJogador.Select(j => j.Nome.ToLower().Contains(nomeJogador.ToLower()));
            return Json(Mapper.Map<List<Jogador>, List<JogadorViewModel>>(jogadores), JsonRequestBehavior.AllowGet);
        }

        // GET: Jogadores/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Jogador jogador = _repositorioJogador.SelectPorID(id.Value);
            if (jogador == null)
            {
                return HttpNotFound();
            }
            return View(Mapper.Map<Jogador, JogadorViewModel>(jogador));
        }

        // GET: Jogadores/Create
        public ActionResult Create()
        {
            CriarListaJogosViewBag();
            return View();
        }

        private void CriarListaJogosViewBag()
        {
            List<SelectListItem> jogosListItens = new List<SelectListItem>();
            List<Jogo> jogos = _repositorioJogo.Select();
            jogos.ForEach(jogo =>
            {
                jogosListItens.Add(new SelectListItem
                {
                    Value = jogo.Id.ToString(),
                    Text = jogo.Nome,
                    Selected = false
                });
            });

            ViewBag.Jogos = jogosListItens;
        }

        // POST: Jogadores/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Nome,Idade,JogoId")] JogadorEdicaoViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                Jogador jogador = Mapper.Map<JogadorEdicaoViewModel, Jogador>(viewModel);
                _repositorioJogador.Insert(jogador);
                return RedirectToAction("Index");
            }

            CriarListaJogosViewBag();
            //ViewBag.JogoId = new SelectList(db.Jogos, "Id", "Nome", jogador.JogoId);
            return View(viewModel);
        }

        // GET: Jogadores/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Jogador jogador = _repositorioJogador.SelectPorID(id.Value);
            if (jogador == null)
            {
                return HttpNotFound();
            }
            
            CriarListaJogosViewBag();
            return View(Mapper.Map<Jogador, JogadorEdicaoViewModel>(jogador));
        }

        // POST: Jogadores/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Nome,Sobrenome,Idade,JogoId")] JogadorEdicaoViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                Jogador jogador = Mapper.Map<JogadorEdicaoViewModel, Jogador>(viewModel);
                _repositorioJogador.Update(jogador);
                return RedirectToAction("Index");
            }

            CriarListaJogosViewBag();
            return View(viewModel);
        }

        // GET: Jogadores/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Jogador jogador = _repositorioJogador.SelectPorID(id.Value);
            if (jogador == null)
            {
                return HttpNotFound();
            }

            return View(Mapper.Map<Jogador, JogadorViewModel>(jogador));
        }

        // POST: Jogadores/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Jogador jogador = _repositorioJogador.SelectPorID(id);
            _repositorioJogador.Delete(jogador);
            return RedirectToAction("Index");
        }
    }
}
