using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Dex.TrocaGames.Web.ViewModels.Usuario
{
    public class UsuarioViewModel
    {
        [Required(ErrorMessage = "O id é obrigatório")]
        public long Id { get; set; }

        [Required(ErrorMessage = "O endereço de email é obrigatório")]
        [DataType(DataType.EmailAddress, ErrorMessage = "Insira um endereço de email válido")]
        public string Email { get; set; }

        [Required(ErrorMessage = "A senha é obrigatória")]
        [DataType(DataType.Password)]
        public string Senha { get; set; }
    }
}