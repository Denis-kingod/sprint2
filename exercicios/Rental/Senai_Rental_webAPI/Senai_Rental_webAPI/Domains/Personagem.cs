using System;
using System.Collections.Generic;

#nullable disable

namespace Senai_Rental_webAPI.Domains
{
    public partial class Personagem
    {
        public byte IdPersonagem { get; set; }
        public byte? IdClasses { get; set; }
        public string NomePersonagem { get; set; }
        public byte VidaMax { get; set; }
        public byte ManaMax { get; set; }
        public DateTime DataAtt { get; set; }
        public DateTime DataCriada { get; set; }

        public virtual Class IdClassesNavigation { get; set; }
    }
}
