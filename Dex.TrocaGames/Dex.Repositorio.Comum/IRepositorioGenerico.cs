using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//camada generica pra todo mundo, inclusive pra quem usa entity
namespace Dex.Repositorio.Comum
{
    public interface IRepositorioGenerico<TDominio, Tchave>
        where TDominio : class
    {
        List<TDominio> Select(Func<TDominio, bool> where = null);
        TDominio SelectPorID(Tchave id);
        void Insert(TDominio entidade);
        void Update(TDominio entidade);
        void Delete(TDominio entidade);
    }
}
