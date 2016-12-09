using Dex.Repositorio.Comum.Entity;
using Dex.TrocaGames.Dominio;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dex.TrocaGames.Repositorio.Entity
{
    public class RepositorioLugar : RepositorioGenerico<Lugar, long>
    {
        public RepositorioLugar(DbContext contexto)
            : base(contexto)
        {

        }
    }
}
 