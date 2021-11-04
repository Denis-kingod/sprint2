using System;
using System.Collections.Generic;

#nullable disable

namespace Senai_Rental_webAPI.Domains
{
    public partial class Class
    {
        public Class()
        {
            HabClasses = new HashSet<HabClass>();
            Personagems = new HashSet<Personagem>();
        }

        public byte IdClasses { get; set; }
        public byte? IdHabilidade { get; set; }
        public string NomeClasse { get; set; }

        public virtual Habilidade IdHabilidadeNavigation { get; set; }
        public virtual ICollection<HabClass> HabClasses { get; set; }
        public virtual ICollection<Personagem> Personagems { get; set; }
    }
}
