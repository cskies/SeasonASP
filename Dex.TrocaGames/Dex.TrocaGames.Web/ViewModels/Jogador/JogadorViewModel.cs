using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Dex.TrocaGames.Web.ViewModels.Jogador
{
    public class JogadorViewModel
    {
        //automapper vai concat sobrenome
        
        [Display(Name="id do jogador")]
        public int Id { get; set; }

        [Display(Name = "nome do jogador")]
        public string Nome { get; set; }
        //public string Sobrenome { get; set; }

        [Display(Name = "idade do jogador")]
        public int Idade { get; set; }

        [Display(Name = "Jogo vinculado")]
        public string Jogo { get; set; } 
        //public long JogoId { get; set; }
    }
}