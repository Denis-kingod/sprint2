using System;
using System.Collections.Generic;

#nullable disable

namespace Senai_Rental_webAPI.Domains
{
    public partial class Habilidade
    {
        public Habilidade()
        {
            Classes = new HashSet<Class>();
            HabClasses = new HashSet<HabClass>();
        }

        public byte IdHabilidade { get; set; }
        public byte? IdTipoHabilidade { get; set; }
        public string NomeHabilidade { get; set; }

        public virtual TipoHabilidade IdTipoHabilidadeNavigation { get; set; }
        public virtual ICollection<Class> Classes { get; set; }
        public virtual ICollection<HabClass> HabClasses { get; set; }
    }
}
