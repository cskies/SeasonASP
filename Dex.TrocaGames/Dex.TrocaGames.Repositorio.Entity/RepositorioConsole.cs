using Dex.Repositorio.Comum.Entity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DexDominio = Dex.TrocaGames.Dominio;
namespace Dex.TrocaGames.Repositorio.Entity
{
    public class RepositorioConsole : RepositorioGenerico<DexDominio.Console, long>
    {

        public RepositorioConsole(DbContext contexto) : 
            base(contexto)
        {
            
        }
    }
}
