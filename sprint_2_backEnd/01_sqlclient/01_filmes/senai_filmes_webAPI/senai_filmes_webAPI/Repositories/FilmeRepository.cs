using senai_filmes_webAPI.Domains;
using senai_filmes_webAPI.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace senai_filmes_webAPI.Repositories
{
    public class FilmeRepository : IFilmeRepository
    {
        private string stringConexao = @"Data Source = PANZERII\SQLEXPRESS; initial catalog = CATALOGO_T; user Id = sa; pwd = senai@#132";

        public void AtualizarIdCorpo(FilmeDomain filmeAtualizado)
        {
            throw new NotImplementedException();
        }




        public void AtualizarIdUrl(int idFilme, FilmeDomain filmeAtualizado)
        {
            throw new NotImplementedException();
        }




        public FilmeDomain BuscarPorId(int idFilme)
        {
            throw new NotImplementedException();
        }




        public void Cadastrar(FilmeDomain novoFilme)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string queryInsert;

                if (novoFilme.idGenero != null)
                {
                    queryInsert = $"INSERT INTO FILME (idGenero, tituloFilme) VALUES ({novoFilme.idGenero},'{novoFilme.tituloFilme}')";
                }
                else
                {
                    queryInsert = $"INSERT INTO FILME (tituloFilme) VALUES ('{novoFilme.tituloFilme}')";
                }

                con.Open();

                using (SqlCommand cmd = new SqlCommand(queryInsert, con))
                {
                    cmd.ExecuteNonQuery();
                }

            }

        }


            public void DeletarFilme(int idFilme)
            {
                throw new NotImplementedException();
            }




            public List<FilmeDomain> ListarTodos()
            {
                //throw new NotImplementedException();
                List<FilmeDomain> listaFilmes = new List<FilmeDomain>();

                using (SqlConnection con = new SqlConnection(stringConexao))
                {
                    string querySelectAll = "SELECT idFilme [ID do Filme], ISNULL(CONVERT(VARCHAR(20), FILME.idGenero), 'NÃO CADASTRADO') AS 'ID do Gênero', tituloFilme 'Título do Filme', ISNULL(nomeGenero, 'NÃO CADASTRADO') 'Gênero do Filme' FROM FILME LEFT JOIN GENERO ON GENERO.idGenero = FILME.idGenero;";

                    con.Open();

                    SqlDataReader rdr;

                    using (SqlCommand cmd = new SqlCommand(querySelectAll, con))
                    {
                        rdr = cmd.ExecuteReader();

                        while (rdr.Read())
                        {
                            FilmeDomain filme = new FilmeDomain()
                            {
                                idFilme = Convert.ToInt32(rdr[0]),
                                idGenero = rdr[1].ToString(),
                                tituloFilme = rdr[2].ToString(),
                                nomeGenero = rdr[3].ToString()
                            };

                            listaFilmes.Add(filme);
                        }

                    }

                }

                return listaFilmes;

            }
        }
    }
