using senai.inlock.webApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai.inlock.webApi.Interfaces
{
    interface IEstudioRepository
    {
        
        //Listar todos os estúdios;
        List<EstudioDomain> ListarTodos();

        /*
        // Buscar um estúdio por idEstudio;
        EstudioDomain BuscarPor(int idEstudio);

        */
    }
}
