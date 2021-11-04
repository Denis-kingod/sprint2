using System.Collections.Generic;
using WebApplication1.Properties.Domains;

namespace senai.inLock.webAPI.Interfaces
{
    interface IEstudiosRepository
    {
        List<EstudiosDomain> ListarComJogos();
        List<EstudiosDomain> ListarTodos();
        EstudiosDomain BuscarPorId(int id);
        void Cadastrar(EstudiosDomain novoEstudio);
        void Atualizar(int id, EstudiosDomain estudioAtualizado);
        void Deletar(int id);
    }
}
