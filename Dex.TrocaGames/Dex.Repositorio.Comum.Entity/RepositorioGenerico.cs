using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dex.Repositorio.Comum.Entity
{
    public class RepositorioGenerico<TDominio, TChave> 
        : IRepositorioGenerico<TDominio, TChave> 
        where TDominio : class
    {
        protected DbContext _contexto;

        public RepositorioGenerico(DbContext contexto)
        {
            _contexto = contexto;
        }

        public virtual List<TDominio> Select(Func<TDominio, bool> where = null)
        {
            if (where == null)
            {
                return _contexto.Set<TDominio>().ToList();
            }
            else
            {
                return _contexto.Set<TDominio>().Where(where).ToList();
            }
        }

        public virtual TDominio SelectPorID(TChave id)
        {
            return _contexto.Set<TDominio>().Find(id);
        }

        public virtual void Insert(TDominio entidade)
        {
            _contexto.Set<TDominio>().Add(entidade);
            _contexto.SaveChanges();
        }

        public virtual void Update(TDominio entidade)
        {
            _contexto.Set<TDominio>().Attach(entidade); //reflection Attach por ser classe POCO e voltar sob dominio do EF
            _contexto.Entry(entidade).State = EntityState.Modified;
            _contexto.SaveChanges();
        }

        public virtual void Delete(TDominio entidade)
        {
            _contexto.Set<TDominio>().Attach(entidade); 
            _contexto.Entry(entidade).State = EntityState.Deleted; //enum removed qdo classe POCO gera erro por ser attached
            _contexto.SaveChanges();
        }
    }
}
