using Senai.Rental.WebApi.Samuel.Domains;
using Senai.Rental.WebApi.Samuel.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Rental.WebApi.Samuel.Repositories
{
    public class ClienteRepository : IClienteRepository
    {

        //public const string CONEXAO = "Data Source=NOTE0113C2\\SQLEXPRESS; initial catalog=T_RENTAL_Samuel; user Id=sa; pwd=Senai@132";
        public const string CONEXAO = "Data Source=PANZERII\\SQLEXPRESS; initial catalog=T_RENTAL_Samuel; user Id=sa; pwd=senai@#132";



        public void Atualizar(ClienteDomain clienteAtualizado)
        {
            if (clienteAtualizado.nome != null)
            {
                using (SqlConnection conect = new SqlConnection(CONEXAO))
                {
                    string queryUpdateBody = "UPDATE CLIENTE SET nome = @nome, sobrenome = @sobrenome, cnh = @cnh WHERE idCliente = @idCliente";

                    using (SqlCommand atualizar = new SqlCommand(queryUpdateBody, conect))
                    {
                        atualizar.Parameters.AddWithValue("@nome", clienteAtualizado.nome);
                        atualizar.Parameters.AddWithValue("@sobrenome", clienteAtualizado.sobrenome);
                        atualizar.Parameters.AddWithValue("@cnh", clienteAtualizado.cnh);
                        atualizar.Parameters.AddWithValue("@idCliente", clienteAtualizado.idCliente);

                        conect.Open();

                        atualizar.ExecuteNonQuery();

                    }
                }
            }
        }






        public ClienteDomain BuscarPor(int idCliente)
        {
            using (SqlConnection conect = new SqlConnection(CONEXAO))
            {
                string querySelectById = "SELECT idCliente, nome, sobrenome, cnh FROM CLIENTE WHERE idCliente = @idCliente";

                conect.Open();

                SqlDataReader reader;

                using (SqlCommand escolher = new SqlCommand(querySelectById, conect))
                {
                    escolher.Parameters.AddWithValue("@idCliente", idCliente);

                    reader = escolher.ExecuteReader();

                    if (reader.Read())
                    {
                        ClienteDomain clienteEncontrado = new ClienteDomain()
                        {
                            idCliente = Convert.ToInt32(reader[0]),
                            nome = reader[1].ToString(),
                            sobrenome = reader[2].ToString(),
                            cnh = reader[3].ToString()
                        };

                        return clienteEncontrado;
                    }

                    return null;
                }
            }
        }





        public ClienteDomain BuscarPor(string nomeCliente)
        {
            using (SqlConnection conect = new SqlConnection(CONEXAO))
            {
                string querySelectById = "SELECT idCliente, nome, sobrenome, cnh FROM CLIENTE WHERE nome = @nomeCliente";

                conect.Open();

                SqlDataReader reader;

                using (SqlCommand escolher = new SqlCommand(querySelectById, conect))
                {
                    escolher.Parameters.AddWithValue("@nomeCliente", nomeCliente);

                    reader = escolher.ExecuteReader();

                    if (reader.Read())
                    {
                        ClienteDomain clienteEncontrado = new ClienteDomain()
                        {
                            idCliente = Convert.ToInt32(reader[0]),
                            nome = reader[1].ToString(),
                            sobrenome = reader[2].ToString(),
                            cnh = reader[3].ToString()
                        };

                        return clienteEncontrado;
                    }

                    return null;
                }
            }
        }






        public void Deletar(int idCliente)
        {
            using (SqlConnection conect = new SqlConnection(CONEXAO))
            {
                string queryDelete = "DELETE FROM CLIENTE WHERE idCliente = @idCliente";

                using (SqlCommand deletar = new SqlCommand(queryDelete, conect))
                {
                    deletar.Parameters.AddWithValue("@idCliente", idCliente);

                    conect.Open();

                    deletar.ExecuteNonQuery();

                }
            }
        }






        public void Inserir(ClienteDomain novoCliente)
        {
            using (SqlConnection conect = new SqlConnection(CONEXAO))
            {
                string queryInsert = "INSERT INTO CLIENTE (nome, sobrenome, cnh) VALUES (@nomeCliente,@sobrenomeCliente,@cnhCliente)";

                conect.Open();

                using (SqlCommand inserir = new SqlCommand(queryInsert, conect))
                {
                    inserir.Parameters.AddWithValue("@nomeCliente", novoCliente.nome);
                    inserir.Parameters.AddWithValue("@sobrenomeCliente", novoCliente.sobrenome);
                    inserir.Parameters.AddWithValue("@cnhCliente", novoCliente.cnh);

                    inserir.ExecuteNonQuery();
                }
            }
        }






        public List<ClienteDomain> Listar()
        {
            List<ClienteDomain> listaClientes = new List<ClienteDomain>();

            using (SqlConnection conexao = new SqlConnection(CONEXAO))
            {
                string querySelect = "SELECT idCliente, nome, sobrenome, cnh FROM CLIENTE";

                conexao.Open();

                SqlDataReader reader;

                using (SqlCommand listar = new SqlCommand(querySelect, conexao))
                {
                    reader = listar.ExecuteReader();

                    while (reader.Read())
                    {
                        ClienteDomain cliente = new ClienteDomain()
                        {
                            idCliente = Convert.ToInt32(reader[0]),
                            nome = reader[1].ToString(),
                            sobrenome = reader[2].ToString(),
                            cnh = reader[3].ToString()
                        };

                        listaClientes.Add(cliente);
                    }
                }
            }

            return listaClientes;
        }
    }
}
