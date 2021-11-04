using System;
using System.Collections.Generic;

#nullable disable

namespace inlock_manha_webAPI.Domains
{
    public partial class Usuario
    {
        public Usuario()
        {
            InverseIdTipoUsuarioNavigation = new HashSet<Usuario>();
        }

        public int IdUsuario { get; set; }
        public int? IdTipoUsuario { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }

        public virtual Usuario IdTipoUsuarioNavigation { get; set; }
        public virtual ICollection<Usuario> InverseIdTipoUsuarioNavigation { get; set; }
    }
}
