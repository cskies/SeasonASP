using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Dex.TrocaGames.Web.ViewModels.Jogador
{
    public class JogadorEdicaoViewModel
    {
        [Required(ErrorMessage="o id eh obrigatorio")]
        public int Id { get; set; }

        [Display(Name="Nome do jogador")]
        [Required(ErrorMessage = "o nome eh obrigatorio")]
        [MaxLength(100, ErrorMessage="O nome n pode ter mais de 50 caracteres")]
        public string Nome { get; set; }

        [Display(Name = "Idade do fei")]
        [Required(ErrorMessage = "a porra da idade obrigatoria")]
        public int Idade { get; set; }

        [Display(Name = "Jogo a ser jogado")]
        [Required(ErrorMessage = "vc precisa selecionar um jogo")]
        public long JogoId { get; set; }
    }
}