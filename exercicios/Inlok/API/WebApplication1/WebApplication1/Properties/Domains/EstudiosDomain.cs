using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Properties.Domains
{
    public class EstudiosDomain
    {
        public int IdEstudio { get; set; }
        public string NomeEstudio { get; set; }
        public List<JogosDomain> ListaJogos { get; set; }
    }
}
