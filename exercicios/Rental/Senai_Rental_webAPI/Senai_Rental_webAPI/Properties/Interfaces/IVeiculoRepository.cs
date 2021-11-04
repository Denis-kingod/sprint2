using Senai_Rental_webAPI.Properties.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai_rental_webAPI.Properties.Interfaces
{
    interface IVeiculoRepository
    {
        List<VeiculoDomain> ListarTodos();

        VeiculoDomain BuscarPorId(int IdProcurar);

        void Cadastrar(VeiculoDomain NovoVeiculo);

        void Atualizar(VeiculoDomain VeiculoAtualizado);

        void Deletar(int IdDeletar);
    }
}
