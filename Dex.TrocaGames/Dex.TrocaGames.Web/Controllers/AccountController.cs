using Dex.TrocaGames.Web.Infraestrutura.Identity;
using Dex.TrocaGames.Web.ViewModels.Usuario;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Dex.TrocaGames.Web.Controllers
{
    public class AccountController : Controller
    {
        // GET: Account
        public ActionResult CriarUsuario()
        {
            return View();
        }

        //usando a porra do identity
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CriarUsuario(UsuarioViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                //guardar os usuarios no identity
                UserStore<IdentityUser> userStore
                    = new UserStore<IdentityUser>(new TrocaGamesIdentityContext());

                UserManager<IdentityUser> userManager
                    = new UserManager<IdentityUser>(userStore);

                IdentityUser novoUsuario = new IdentityUser
                {
                    UserName = viewModel.Email,
                    Email = viewModel.Email
                };

                IdentityResult resultado = userManager.Create(novoUsuario, viewModel.Senha);

                if (resultado.Succeeded) 
                {
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError("erro_identity", resultado.Errors.First());
                    return View(viewModel);
                }
            }

            return View(viewModel);
        }
    }
}