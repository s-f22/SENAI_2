using senai.inlock.webApi.Domains;
using senai.inlock.webApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace senai.inlock.webApi.Repositories
{
    public class EstudioRepository : IEstudioRepository
    {
        //private const string CONEXAO = "Data Source=NOTE0113C2\\SQLEXPRESS; initial catalog=inlock_games_tarde; user Id=sa; pwd=Senai@132";
        private const string CONEXAO = "Data Source=PANZERII\\SQLEXPRESS; initial catalog=inlock_games_tarde; user Id=sa; pwd=senai@#132";


        public List<EstudioDomain> ListarTodos()
        {
            List<EstudioDomain> listaEstudios = new List<EstudioDomain>();

            using (SqlConnection conexao = new SqlConnection(CONEXAO))
            {
                
                string querySelect = @" SELECT ESTUDIOS.idEstudio, ESTUDIOS.nomeEstudio, JOGOS.idJogo, JOGOS.nomeJogo, JOGOS.descricao, JOGOS.dataLancamento, JOGOS.idEstudio, JOGOS.valor FROM JOGOS 
                                        INNER JOIN ESTUDIOS 
                                        ON JOGOS.idEstudio = ESTUDIOS.idEstudio";

                conexao.Open();

                SqlDataReader reader;

                using (SqlCommand listar = new SqlCommand(querySelect, conexao))
                {
                    reader = listar.ExecuteReader();

                    while (reader.Read())
                    {
                        EstudioDomain estudio = new EstudioDomain()
                        {
                            idEstudio = Convert.ToInt32(reader[0]),
                            nomeEstudio = reader[1].ToString(),
                        };
                        JogoDomain jogo = new JogoDomain()
                        {
                            idJogo = Convert.ToInt32(reader[2]),
                            nomeJogo = reader[3].ToString(),
                            descricao = reader[4].ToString(),
                            dataLancamento = Convert.ToDateTime(reader[5]),
                            idEstudio = Convert.ToInt32(reader[6]),
                            valor = Convert.ToDouble(reader[7])
                        };



                        listaEstudios.Add(estudio);
                    }
                }
            }

            return listaEstudios;
        }
    }
}
