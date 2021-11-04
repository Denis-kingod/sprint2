using Senai_Rental_webAPI.Properties.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai_rental_webAPI.Properties.Interfaces
{
    interface IClienteRepository
    {
        List<ClienteDomain> ListarTodos();

        ClienteDomain BuscarPorId(int IdProcurar);

        void Cadastrar(ClienteDomain NovoCliente);

        void Atualizar(ClienteDomain ClienteAtualizado);

        void Deletar(int IdDeletar);
    }
}
