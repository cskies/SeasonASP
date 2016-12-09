using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dex.TrocaGames.Dominio
{
    public class Jogador
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public int Idade { get; set; }

        //prop tranziente (virtual nesse caso, "navigation property") 
        //somente representacao (não será persistindo no bd) 
        public virtual Jogo Jogo { get; set; } //criar lista de jogadores n pra n na class (prop tranziente ICollection<Jogador>)
        public long JogoId { get; set; }
    }
}
