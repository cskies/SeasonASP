using Dex.Repositorio.Comum.Entity;
using Dex.TrocaGames.AcessoDados.Entity.Context;
using Dex.TrocaGames.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dex.TrocaGames.Repositorio.Entity
{
    public class RepositorioJogo : RepositorioGenerico<Jogo, long>
    {
        public RepositorioJogo(TrocaGamesDbContext contexto)
            : base(contexto)
        {

        }
    }
}
