using System;
using System.Collections.Generic;

#nullable disable

namespace inlock_manha_webAPI.Domains
{
    public partial class Jogo
    {
        public int IdJogo { get; set; }
        public int? IdEstudio { get; set; }
        public string NomeJogo { get; set; }
        public string Descricao { get; set; }
        public DateTime DataLancamento { get; set; }
        public decimal Valor { get; set; }

        public virtual Estudio IdEstudioNavigation { get; set; }
    }
}
