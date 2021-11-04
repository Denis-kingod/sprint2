﻿using System.Collections.Generic;
using WebApplication1.Properties.Domains;

namespace senai.inLock.webAPI.Interfaces
{
    interface IJogoRepository
    {
        List<JogosDomain> ListarTodos();
        JogosDomain BuscarPorId(int id);
        void Cadastrar(JogosDomain novoJogo);
        void Atualizar(int id, JogosDomain jogoAtualizado);
        void Deletar(int id);
        void Atualizar(JogosDomain jogoAtualizar);
    }
}
