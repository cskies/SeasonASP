using Dex.TrocaGames.AcessoDados.Entity.Context;
using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Dex.TrocaGames.Web.Infraestrutura.IoC.Modulos
{
    public class DbContextModule : NinjectModule
    {
        public override void Load()
        {
            Bind<DbContext>()
                .To<TrocaGamesDbContext>();
        }
    }
}