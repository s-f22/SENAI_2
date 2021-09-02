using Senai.Rental.WebApi.Samuel.Interfaces;
using Senai.Rental.WebApi_Samuel.Domains;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Rental.WebApi.Samuel.Repositories
{
    public class VeiculoRepository : IVeiculoRepository
    {

        public const string CONEXAO = "Data Source=NOTE0113C2\\SQLEXPRESS; initial catalog=T_RENTAL_Samuel; user Id=sa; pwd=Senai@132";
        //public const string CONEXAO = "Data Source=PANZERII\\SQLEXPRESS; initial catalog=T_RENTAL_Samuel; user Id=sa; pwd=senai@#132";


        public void Atualizar(VeiculoDomain veiculoAtualizado)
        {
            if (veiculoAtualizado.idVeiculo > 0)
            {
                using (SqlConnection conect = new SqlConnection(CONEXAO))
                {
                    string queryUpdateBody = "UPDATE VEICULO SET idModelo = @idModelo, idEmpresa = @idEmpresa, corVeiculo = @corVeiculo WHERE idVeiculo = @idVeiculo";

                    using (SqlCommand atualizar = new SqlCommand(queryUpdateBody, conect))
                    {
                        atualizar.Parameters.AddWithValue("@idModelo", veiculoAtualizado.idModelo);
                        atualizar.Parameters.AddWithValue("@idEmpresa", veiculoAtualizado.idEmpresa);
                        atualizar.Parameters.AddWithValue("@corVeiculo", veiculoAtualizado.corVeiculo);
                        atualizar.Parameters.AddWithValue("@idVeiculo", veiculoAtualizado.idVeiculo);

                        conect.Open();

                        atualizar.ExecuteNonQuery();

                    }
                }
            }
        }






        public VeiculoDomain BuscarPorId(int idVeiculo)
        {
            using (SqlConnection conect = new SqlConnection(CONEXAO))
            {
                string querySelectById = "SELECT idVeiculo, idModelo, idEmpresa, corVeiculo FROM VEICULO WHERE idVeiculo = @idVeiculo";

                conect.Open();

                SqlDataReader reader;

                using (SqlCommand escolher = new SqlCommand(querySelectById, conect))
                {
                    escolher.Parameters.AddWithValue("@idVeiculo", idVeiculo);

                    reader = escolher.ExecuteReader();

                    if (reader.Read())
                    {
                        VeiculoDomain veiculoEncontrado = new VeiculoDomain()
                        {
                            idVeiculo = Convert.ToInt32(reader[0]),
                            idModelo = Convert.ToInt32(reader[1]),
                            idEmpresa = Convert.ToInt32(reader[2]),
                            corVeiculo = reader[3].ToString()
                        };

                        return veiculoEncontrado;
                    }

                    return null;
                }
            }
        }






        public void Deletar(int idVeiculo)
        {
            using (SqlConnection conect = new SqlConnection(CONEXAO))
            {
                string queryDelete = "DELETE FROM VEICULO WHERE idVeiculo = @idVeiculo";

                using (SqlCommand deletar = new SqlCommand(queryDelete, conect))
                {
                    deletar.Parameters.AddWithValue("@idVeiculo", idVeiculo);

                    conect.Open();

                    deletar.ExecuteNonQuery();

                }
            }
        }






        public void Inserir(VeiculoDomain novoVeiculo)
        {
            using (SqlConnection conect = new SqlConnection(CONEXAO))
            {
                string queryInsert = "INSERT INTO VEICULO (idModelo, idEmpresa, corVeiculo) VALUES (@idModelo,@idEmpresa,@corVeiculo)";

                conect.Open();

                using (SqlCommand inserir = new SqlCommand(queryInsert, conect))
                {
                    inserir.Parameters.AddWithValue("@idModelo", novoVeiculo.idModelo);
                    inserir.Parameters.AddWithValue("@idEmpresa", novoVeiculo.idEmpresa);
                    inserir.Parameters.AddWithValue("@corVeiculo", novoVeiculo.corVeiculo);

                    inserir.ExecuteNonQuery();
                }
            }
        }






        public List<VeiculoDomain> Listar()
        {
            List<VeiculoDomain> listaVeiculos = new List<VeiculoDomain>();

            using (SqlConnection conexao = new SqlConnection(CONEXAO))
            {
                string querySelect = "SELECT idVeiculo, idModelo, idEmpresa, corVeiculo FROM VEICULO";

                conexao.Open();

                SqlDataReader reader;

                using (SqlCommand listar = new SqlCommand(querySelect, conexao))
                {
                    reader = listar.ExecuteReader();

                    while (reader.Read())
                    {
                        VeiculoDomain veiculo = new VeiculoDomain()
                        {
                            idVeiculo = Convert.ToInt32(reader[0]),
                            idModelo = Convert.ToInt32(reader[1]),
                            idEmpresa = Convert.ToInt32(reader[2]),
                            corVeiculo = reader[3].ToString()
                        };

                        listaVeiculos.Add(veiculo);
                    }
                }
            }

            return listaVeiculos;
        }
    }
}
