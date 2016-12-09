using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dex.TrocaGames.Dominio.Enums;
namespace Dex.TrocaGames.Dominio
{
    public class Jogo
    {
        public long Id { get; set; }
        public string Nome { get; set; }
        public DateTime DataLancamento { get; set; }
        public GeneroEnum Genero { get; set; }
        public FaixaEtariaEnum FaixaEtaria { get; set; }

        public virtual ICollection<Jogador> Jogadores { get; set; }
    }
}
