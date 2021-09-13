using senai.inlock.webApi.Domains;
using senai.inlock.webApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace senai.inlock.webApi.Repositories
{
    public class JogoRepository : IJogoRepository
    {
        //private const string CONEXAO = "Data Source=NOTE0113C2\\SQLEXPRESS; initial catalog=inlock_games_tarde; user Id=sa; pwd=Senai@132";
        private const string CONEXAO = "Data Source=PANZERII\\SQLEXPRESS; initial catalog=inlock_games_tarde; user Id=sa; pwd=senai@#132";


        public void Atualizar(JogoDomain jogoAtualizado)
        {
            if (jogoAtualizado.nomeJogo != null)
            {
                using (SqlConnection con = new SqlConnection(CONEXAO))
                {
                    string queryAtualizarCorpo = @" UPDATE JOGOS
                                                SET nomeJogo = @nomeJogo, descricao = @descricao, 
                                                dataLancamento = @dataLancamento, idEstudio = @idEstudio, valor = @valor
                                                WHERE idJogo = @idJogo";
                    using (SqlCommand cmd = new SqlCommand(queryAtualizarCorpo, con))
                    {
                        cmd.Parameters.AddWithValue("@nomeJogo", jogoAtualizado.nomeJogo);
                        cmd.Parameters.AddWithValue("@descricao", jogoAtualizado.descricao);
                        cmd.Parameters.AddWithValue("@dataLancamento", jogoAtualizado.dataLancamento);
                        cmd.Parameters.AddWithValue("@idEstudio", jogoAtualizado.idEstudio);
                        cmd.Parameters.AddWithValue("@valor", jogoAtualizado.valor);
                        cmd.Parameters.AddWithValue("@idJogo", jogoAtualizado.idJogo);

                        con.Open();
                        cmd.ExecuteNonQuery();
                    }

                }
                    
            }
        }






        public JogoDomain BuscarPorId(int idJogo)
        {
            using (SqlConnection con = new SqlConnection(CONEXAO))
            {
                string querySelectById = @" SELECT idJogo, nomeJogo, descricao, dataLancamento, idEstudio, valor FROM JOGOS
                                            WHERE idJogo = @idJogo";

                con.Open();

                SqlDataReader reader;

                using (SqlCommand cmd = new SqlCommand(querySelectById, con))
                {
                    cmd.Parameters.AddWithValue("@idJogo", idJogo);

                    reader = cmd.ExecuteReader();

                    if (reader.Read())
                    {
                        JogoDomain jogoBuscado = new JogoDomain
                        {
                            idJogo = Convert.ToInt32(reader["idJogo"]),
                            nomeJogo = reader["nomeJogo"].ToString(),
                            descricao = reader["descricao"].ToString(),
                            dataLancamento = Convert.ToDateTime(reader["dataLancamento"]),
                            idEstudio = Convert.ToInt32(reader["idEstudio"]),
                            valor = Convert.ToDouble(reader["valor"])
                        };


                        return jogoBuscado;
                    }

                    return null;
                }
            }
        }






        public void Cadastrar(JogoDomain novoJogo)
        {
            using (SqlConnection conect = new SqlConnection(CONEXAO))
            {
                string queryInsert = @" INSERT INTO JOGOS(nomeJogo, descricao, dataLancamento, idEstudio, valor)
                                        VALUES(@nomeJogo, @descricao, @dataLancamento, @idEstudio, @valor); ";

                conect.Open();

                using (SqlCommand cadastrar = new SqlCommand(queryInsert, conect))
                {
                    cadastrar.Parameters.AddWithValue("@nomeJogo", novoJogo.nomeJogo);
                    cadastrar.Parameters.AddWithValue("@descricao", novoJogo.descricao);
                    cadastrar.Parameters.AddWithValue("@dataLancamento", novoJogo.dataLancamento);
                    cadastrar.Parameters.AddWithValue("@idEstudio", novoJogo.idEstudio);
                    cadastrar.Parameters.AddWithValue("@valor", novoJogo.valor);

                    cadastrar.ExecuteNonQuery();
                }
            }
        }






        public void Deletar(int idParaExcluir)
        {
            using (SqlConnection conect = new SqlConnection(CONEXAO))
            {
                string queryDelete = "DELETE FROM JOGOS WHERE idJogo = @idJogo";

                using (SqlCommand deletar = new SqlCommand(queryDelete, conect))
                {
                    deletar.Parameters.AddWithValue("@idJogo", idParaExcluir);

                    conect.Open();

                    deletar.ExecuteNonQuery();

                }
            }
        }






        public List<JogoDomain> ListarTodos()
        {
            List<JogoDomain> listaJogos = new List<JogoDomain>();

            using (SqlConnection conexao = new SqlConnection(CONEXAO))
            {
                //string querySelect = @"SELECT idJogo, nomeJogo, descricao, dataLancamento, idEstudio, valor FROM JOGOS";

                string querySelect = @" SELECT JOGOS.idJogo, JOGOS.nomeJogo, JOGOS.descricao, JOGOS.dataLancamento, JOGOS.idEstudio, JOGOS.valor, ESTUDIOS.idEstudio, ESTUDIOS.nomeEstudio FROM JOGOS
                                        INNER JOIN ESTUDIOS
                                        ON JOGOS.idEstudio = ESTUDIOS.idEstudio";

                conexao.Open();

                SqlDataReader reader;

                using (SqlCommand listar = new SqlCommand(querySelect, conexao))
                {
                    reader = listar.ExecuteReader();

                    while (reader.Read())
                    {
                        JogoDomain jogo = new JogoDomain()
                        {
                            idJogo = Convert.ToInt32(reader[0]),
                            nomeJogo = reader[1].ToString(),
                            descricao = reader[2].ToString(),
                            dataLancamento = Convert.ToDateTime(reader[3]),
                            idEstudio = Convert.ToInt32(reader[4]),
                            valor = Convert.ToDouble(reader[5]),                                                        
                            estudio = new EstudioDomain()
                            {
                                idEstudio = Convert.ToInt32(reader[6]),
                                nomeEstudio = reader[7].ToString()
                            }                          
                        };

                    
                        listaJogos.Add(jogo);
                    }
                }
            }

            return listaJogos;
        }
    }
}
