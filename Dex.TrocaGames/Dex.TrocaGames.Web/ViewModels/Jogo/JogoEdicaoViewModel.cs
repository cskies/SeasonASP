using Dex.TrocaGames.Dominio.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Dex.TrocaGames.Web.ViewModels.Jogo
{
    public class JogoEdicaoViewModel
    {
        [Display(Name = "Id")]
        [Required(ErrorMessage="O id do jogo é obrigatório")]
        public long Id { get; set; }

        [Display(Name = "Nome do Jogo")]
        [Required(ErrorMessage = "O nome do jogo é obrigatório")]
        [MaxLength(50, ErrorMessage= "O campo nome pode possuir no máximo 50 caracteres")]
        public string Nome { get; set; }

        [Display(Name = "Data de Lançamento")]
        [Required(ErrorMessage = "A Data de Lançamento é obrigatório")]
        [DataType(DataType.Date)]
        public DateTime DataLancamento { get; set; }

        [Display(Name = "Gênero do Jogo")]
        [Required(ErrorMessage = "O gênero do jogo é obrigatório")]
        public GeneroEnum Genero { get; set; }

        [Display(Name = "Faixa Etária")]
        [Required(ErrorMessage = "A faixa etária do jogo é obrigatória")]
        public FaixaEtariaEnum FaixaEtaria { get; set; }
    }
}