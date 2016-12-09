using Dex.Repositorio.Comum;
using Dex.TrocaGames.Dominio;
using Dex.TrocaGames.Repositorio.Entity;
using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace Dex.TrocaGames.Web.Infraestrutura.IoC.Modulos
{
    public class RepositorioJogadorModule : NinjectModule
    {
        public override void Load()
        {
            int idCliente = Convert.ToInt32(ConfigurationManager.AppSettings["IdCliente"]);

            if (idCliente == 123)
            {
                Bind<IRepositorioGenerico<Jogador, int>>()
                    .To<RepositorioJogadorBarDoZe>();
            }
            else
            {
                Bind<IRepositorioGenerico<Jogador, int>>()
                .To<RepositorioJogador>();
            }
        }
    }
}