using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai_Rental_webAPI.Properties.Domains
{
    public class AluguelDomain
    {
        public int IdAluguel { get; set; }
        public int IdCliente { get; set; }
        public int IdVeiculo { get; set; }
        public DateTime Data1 { get; set; }
        public ClienteDomain Cliente { get; set; }
        public VeiculoDomain Veiculo { get; set; }
    }
}
