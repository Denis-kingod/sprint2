using Senai_Rental_webAPI.Properties.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai_rental_webAPI.Properties.Interfaces
{
    interface IAluguelRepository
    {
        List<AluguelDomain> ListarTodos();

        AluguelDomain BuscarPorId(int IdProcurar);

        void Cadastrar(AluguelDomain NovoAluguel);

        void Atualizar(AluguelDomain AluguelAtualizado);

        void Deletar(int IdDeletar);
    }
}
