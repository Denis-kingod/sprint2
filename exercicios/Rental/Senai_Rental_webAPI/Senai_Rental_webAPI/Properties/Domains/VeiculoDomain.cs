using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai_Rental_webAPI.Properties.Domains
{
    public class VeiculoDomain
    {
        public int IdVeiculo { get; set; }
        public int IdEmpresa { get; set; }
        public int IdModelo { get; set; }
        public string CorVeiculo { get; set; }

        public EmpresaDomain Empresa { get; set; }
        public ModeloDomain Modelo { get; set; }
        public MarcaDomain Marca { get; internal set; }
    }
}
