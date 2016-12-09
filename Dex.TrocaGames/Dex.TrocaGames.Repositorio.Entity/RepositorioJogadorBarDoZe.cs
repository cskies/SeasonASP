using Dex.Repositorio.Comum.Entity;
using Dex.TrocaGames.AcessoDados.Entity.Context;
using Dex.TrocaGames.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace Dex.TrocaGames.Repositorio.Entity
{
    public class RepositorioJogadorBarDoZe : RepositorioGenerico<Jogador, int>
    {
        public RepositorioJogadorBarDoZe(TrocaGamesDbContext contexto)
            : base(contexto) // necessario devido a utilizacao do ctor nao padrao
        {
        }

        public override List<Jogador> Select(Func<Jogador, bool> where = null)
        {
            List<Jogador> jogadores = new List<Jogador>();
            
            if (where == null) 
            {
                jogadores = _contexto.Set<Jogador>().Include(p=> p.Jogo).ToList(); 
            }
            else
            {
                jogadores = _contexto.Set<Jogador>()
                    .Include(p => p.Jogo)
                    .Where(where)
                    .ToList();
            }

            for (int i = 0; i < jogadores.Count; i++)
            {
                jogadores[i].Sobrenome += " [Bar do Zé]";
            }

            return jogadores;
        }

        public override Jogador SelectPorID(int id)
        {
            return _contexto.Set<Jogador>()
                .Include(p => p.Jogo)
                .Where(p => p.Id == id)
                .SingleOrDefault(); //qdo eh retornado um soh na lista *o first pega o primeiro onde uma lista tem mais de 1
        }
    }
}
