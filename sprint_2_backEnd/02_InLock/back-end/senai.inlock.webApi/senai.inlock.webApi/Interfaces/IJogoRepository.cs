using senai.inlock.webApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai.inlock.webApi.Interfaces
{
    interface IJogoRepository
    {
        // ADMINISTRADOR poderá aadastrar novo Jogo
        void Cadastrar(JogoDomain novoJovo);

        // Listar todos os jogos e respectivos estudios - CLIENTE E ADMINISTRADOR;
        List<JogoDomain> ListarTodos();

        // Buscar um jogo por idJogo - CLIENTE E ADMINISTRADOR;
        JogoDomain BuscarPorId(int idJogo);

    }
}
