using Senai.Rental.WebApi.Samuel.Interfaces;
using Senai.Rental.WebApi.Samuel.Domains;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Rental.WebApi.Samuel.Repositories
{
    public class AluguelRepository : IAluguelRepository
    {
        //public const string CONEXAO = "Data Source=NOTE0113C2\\SQLEXPRESS; initial catalog=T_RENTAL_Samuel; user Id=sa; pwd=Senai@132";
        public const string CONEXAO = "Data Source=PANZERII\\SQLEXPRESS; initial catalog=T_RENTAL_Samuel; user Id=sa; pwd=senai@#132";


        public void Atualizar(AluguelDomain aluguelAtualizado)
        {
            if (aluguelAtualizado.valorAluguel > 0)
            {
                using (SqlConnection conect = new SqlConnection(CONEXAO))
                {
                    string queryUpdateBody = "UPDATE ALUGUEL SET idVeiculo = @idVeiculo, idCliente = @idCliente, dataRetirada = @dataRetirada, dataDevolucao = @dataDevolucao, valorAluguel = @valorAluguel WHERE idAluguel = @idAluguel";

                    using (SqlCommand atualizar = new SqlCommand(queryUpdateBody, conect))
                    {
                        atualizar.Parameters.AddWithValue("@idVeiculo", aluguelAtualizado.idVeiculo);
                        atualizar.Parameters.AddWithValue("@idCliente", aluguelAtualizado.idCliente);
                        atualizar.Parameters.AddWithValue("@dataRetirada", aluguelAtualizado.dataRetirada);                        
                        atualizar.Parameters.AddWithValue("@dataDevolucao", aluguelAtualizado.dataDevolucao);
                        atualizar.Parameters.AddWithValue("@valorAluguel", aluguelAtualizado.valorAluguel);
                        atualizar.Parameters.AddWithValue("@idAluguel", aluguelAtualizado.idAluguel);

                        conect.Open();

                        atualizar.ExecuteNonQuery();

                    }
                }
            }
        }






        public AluguelDomain BuscarPorId(int idAluguel)
        {
            using (SqlConnection conect = new SqlConnection(CONEXAO))
            {
                string querySelectById = "SELECT idAluguel, idVeiculo, idCliente, dataRetirada, dataDevolucao, valorAluguel FROM ALUGUEL WHERE idAluguel = @idAluguel";

                conect.Open();

                SqlDataReader reader;

                using (SqlCommand escolher = new SqlCommand(querySelectById, conect))
                {
                    escolher.Parameters.AddWithValue("@idAluguel", idAluguel);

                    reader = escolher.ExecuteReader();

                    if (reader.Read())
                    {
                        AluguelDomain aluguelEncontrado = new AluguelDomain()
                        {
                            idAluguel = Convert.ToInt32(reader[0]),
                            idVeiculo = Convert.ToInt32(reader[1]),
                            idCliente = Convert.ToInt32(reader[2]),
                            dataRetirada = Convert.ToDateTime(reader[3]),
                            dataDevolucao = Convert.ToDateTime(reader[4]),
                            valorAluguel = Convert.ToDouble(reader[5]),
                        };

                        return aluguelEncontrado;
                    }

                    return null;
                }
            }
        }






        public void Deletar(int idAluguel)
        {
            using (SqlConnection conect = new SqlConnection(CONEXAO))
            {
                string queryDelete = "DELETE FROM ALUGUEL WHERE idAluguel = @idAluguel";

                using (SqlCommand deletar = new SqlCommand(queryDelete, conect))
                {
                    deletar.Parameters.AddWithValue("@idAluguel", idAluguel);

                    conect.Open();

                    deletar.ExecuteNonQuery();

                }
            }
        }






        public void Inserir(AluguelDomain novoAluguel)
        {
            using (SqlConnection conect = new SqlConnection(CONEXAO))
            {
                string queryInsert = "INSERT INTO ALUGUEL (idVeiculo, idCliente, dataRetirada, dataDevolucao, valorAluguel) VALUES (@idVeiculo,@idCliente,@dataRetirada,@dataDevolucao,@valorAluguel)";

                conect.Open();

                using (SqlCommand inserir = new SqlCommand(queryInsert, conect))
                {
                    inserir.Parameters.AddWithValue("@idVeiculo", novoAluguel.idVeiculo);
                    inserir.Parameters.AddWithValue("@idCliente", novoAluguel.idCliente);
                    inserir.Parameters.AddWithValue("@dataRetirada", novoAluguel.dataRetirada);
                    inserir.Parameters.AddWithValue("@dataDevolucao", novoAluguel.dataDevolucao);
                    inserir.Parameters.AddWithValue("@valorAluguel", novoAluguel.valorAluguel);

                    inserir.ExecuteNonQuery();
                }
            }
        }






        public List<AluguelDomain> Listar()
        {
            List<AluguelDomain> listaAlugueis = new List<AluguelDomain>();

            using (SqlConnection conexao = new SqlConnection(CONEXAO))
            {
                //string querySelect = "SELECT idAluguel, idVeiculo, idCliente, dataRetirada, dataDevolucao, valorAluguel FROM ALUGUEL";

                string querySelect = @" SELECT ALUGUEL.idAluguel, ALUGUEL.idVeiculo, ALUGUEL.idCliente, ALUGUEL.dataRetirada, ALUGUEL.dataDevolucao, 
                                        ALUGUEL.valorAluguel, VEICULO.idVeiculo, VEICULO.idModelo, VEICULO.idEmpresa, VEICULO.corVeiculo, 
                                        CLIENTE.idCliente, CLIENTE.nome, CLIENTE.sobrenome, CLIENTE.cnh,
                                        EMPRESA.idEmpresa, EMPRESA.nomeEmpresa, MODELO.idModelo, MODELO.idMarca, MODELO.nomeModelo,
                                        MARCA.idMarca, MARCA.nomeMarca
                                        FROM ALUGUEL
                                        INNER JOIN CLIENTE
                                        ON ALUGUEL.idCliente = CLIENTE.idCliente
                                        INNER JOIN VEICULO
                                        ON VEICULO.IdVeiculo = ALUGUEL.idVeiculo
                                        INNER JOIN MODELO
                                        ON VEICULO.idModelo = MODELO.idModelo
                                        INNER JOIN EMPRESA
                                        ON EMPRESA.idEmpresa = VEICULO.idEmpresa
                                        INNER JOIN MARCA
                                        ON MODELO.idMarca = MARCA.idMarca";

                conexao.Open();

                SqlDataReader reader;

                using (SqlCommand listar = new SqlCommand(querySelect, conexao))
                {
                    reader = listar.ExecuteReader();

                    while (reader.Read())
                    {
                        AluguelDomain veiculo = new AluguelDomain()
                        {
                            idAluguel = Convert.ToInt32(reader[0]),
                            idVeiculo = Convert.ToInt32(reader[1]),                            
                            idCliente = Convert.ToInt32(reader[2]),
                            dataRetirada = Convert.ToDateTime(reader[3]),
                            dataDevolucao = Convert.ToDateTime(reader[4]),
                            valorAluguel = Convert.ToDouble(reader[5]),
                            veiculo = new VeiculoDomain()
                            {
                                idVeiculo = Convert.ToInt32(reader[6]),
                                idModelo = Convert.ToInt32(reader[7]),
                                idEmpresa = Convert.ToInt32(reader[8]),
                                corVeiculo = reader[9].ToString(),
                                empresa = new EmpresaDomain()
                                {
                                    idEmpresa = Convert.ToInt32(reader[14]),
                                    nomeEmpresa = reader[15].ToString(),
                                },
                                modelo = new ModeloDomain()
                                {
                                    idModelo = Convert.ToInt32(reader[16]),
                                    idMarca = Convert.ToInt32(reader[17]),
                                    nomeModelo = reader[18].ToString(),
                                    marca = new MarcaDomain()
                                    {
                                        idMarca = Convert.ToInt32(reader[19]),
                                        nomeMarca = reader[20].ToString(),
                                    }
                                }
                            },
                            cliente = new ClienteDomain()
                            {
                                idCliente = Convert.ToInt32(reader[10]),
                                nome = reader[11].ToString(),
                                sobrenome = reader[12].ToString(),
                                cnh = reader[13].ToString(),
                            },

                        };

                        listaAlugueis.Add(veiculo);
                    }
                }
            }

            return listaAlugueis;
        }



    }
}
