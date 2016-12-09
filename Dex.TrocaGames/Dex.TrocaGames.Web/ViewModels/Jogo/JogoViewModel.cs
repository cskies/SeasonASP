using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Dex.TrocaGames.Web.ViewModels.Jogo
{
    public class JogoViewModel
    {
        //componentmodel
        [Display(Name="Id")]
        public long Id { get; set; }

        [Display(Name = "Nome do Jogo")]
        public string Nome { get; set; }

        [Display(Name = "Data de Lançamento")]
        [DataType(DataType.Date)]
        public DateTime DataLancamento { get; set; }
        
        [Display(Name = "Gênero do Jogo")]
        public string Genero { get; set; }

        [Display(Name = "Faixa Etária")]
        public string FaixaEtaria { get; set; }
    }
}