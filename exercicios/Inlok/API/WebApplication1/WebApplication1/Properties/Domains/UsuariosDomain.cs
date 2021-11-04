using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Properties.Domains
{
    public class UsuariosDomain
    {
        public int IdUsuarios { get; set; }
        
        [Required(ErrorMessage = "Insira seu e-mail")]
        public string Email { get; set; } 

        [Required(ErrorMessage = "Insira sua senha")]
        [StringLength(100, MinimumLength = 5, ErrorMessage = "A senha deve conter no mínimo 5 caracteres")]
        public string Senha { get; set; }
        public int IdTipoUsuario { get; set; }
        public TiposDeUsuariosDomain TipoUsuario { get; set; }


    }
}
