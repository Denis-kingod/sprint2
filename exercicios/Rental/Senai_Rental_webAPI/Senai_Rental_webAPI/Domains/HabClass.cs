using System;
using System.Collections.Generic;

#nullable disable

namespace Senai_Rental_webAPI.Domains
{
    public partial class HabClass
    {
        public byte IdHabClasses { get; set; }
        public byte? IdHabilidade { get; set; }
        public byte? IdClasses { get; set; }

        public virtual Class IdClassesNavigation { get; set; }
        public virtual Habilidade IdHabilidadeNavigation { get; set; }
    }
}
