using Dex.Repositorio.Comum;
using Dex.TrocaGames.Dominio;
using Dex.TrocaGames.Repositorio.Entity;
using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Dex.TrocaGames.Web.Infraestrutura.IoC.Modulos
{
    public class RepositorioJogoModulo : NinjectModule
    {
        public override void Load()
        {
            Bind<IRepositorioGenerico<Jogo, long>>()
                .To<RepositorioJogo>();
        }
    }
}