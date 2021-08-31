using senai_filmes_webAPI.Domains;
using senai_filmes_webAPI.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace senai_filmes_webAPI.Repositories
{
    public class GeneroRepository : IGeneroRepository
    {
        private string stringConexao = @"Data Source = PANZERII\SQLEXPRESS; initial catalog = CATALOGO_T; user Id = sa; pwd = senai@#132";
        public void AtualizarIdCorpo(GeneroDomain generoAtualizado)
        {
            throw new NotImplementedException();
        }


        //---------------------------------------------------------------------------------------------------


        public void AtualizarIdUrl(int idGenero, GeneroDomain generoAtualizado)
        {
            throw new NotImplementedException();
        }


        //---------------------------------------------------------------------------------------------------


        public GeneroDomain BuscarPorId(int idGenero)
        {
            throw new NotImplementedException();
        }


        //---------------------------------------------------------------------------------------------------


        public void Cadastrar(GeneroDomain novoGenero)
        {
            using ( SqlConnection con = new SqlConnection(stringConexao) )
            {
                string queryInsert = "INSERT INTO GENERO (nomeGenero) VALUES ('" + novoGenero.nomeGenero + "')";
                
                con.Open();

                using ( SqlCommand cmd = new SqlCommand(queryInsert, con) ) 
                {
                    cmd.ExecuteNonQuery();
                }
            }
        }


        //---------------------------------------------------------------------------------------------------


        public void Deletar(int idGenero)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string queryDelete = "DELETE FROM GENERO WHERE idGenero = @idGenero";

                using (SqlCommand cmd = new SqlCommand(queryDelete, con) )
                {
                    cmd.Parameters.AddWithValue("@idGenero", idGenero);

                    con.Open();

                    cmd.ExecuteNonQuery();
                }
            }
        }


        //---------------------------------------------------------------------------------------------------


        public List<GeneroDomain> ListarTodos()
        {
            List<GeneroDomain> listaGeneros = new List<GeneroDomain>();

            using ( SqlConnection con = new SqlConnection(stringConexao) )
            {
                string querySelectAll = "SELECT idGenero, nomeGenero FROM genero";

                con.Open();

                SqlDataReader rdr;

                using ( SqlCommand cmd = new SqlCommand(querySelectAll, con) )
                {
                    //Faz a leitura no banco de dados e carrega as informações de querySelectAll em rdr
                    rdr = cmd.ExecuteReader();

                    //rdr esta carregado. Porem, a função ListarTodos() deve retornar uma lista, e por isso devemos ler o objeto rdr e armazenar seus valores em uma lista, que será retornada pela função
                    while ( rdr.Read() )
                    {
                        GeneroDomain genero = new GeneroDomain()
                        {
                            idGenero = Convert.ToInt32( rdr[0] ),
                            nomeGenero = rdr[1].ToString()
                        };

                        listaGeneros.Add(genero);
                    }

                }

            }

            return listaGeneros;

        }
    }
}
