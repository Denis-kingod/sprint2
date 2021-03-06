using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Properties.Domains
{
    public class JogosDomain
    {
        public int IdJogo { get; set; }

        public int IdEstudio { get; set; }

      
        public string NomeJogo { get; set; }

        
        public string Descricao { get; set; }

        
        public DateTime DataLancamento { get; set; }

        
        public decimal Valor { get; set; }

        public EstudiosDomain Estudio { get; set; }
    }
}
