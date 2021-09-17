using senai.inlock.webApi.Domains;
using senai.inlock.webApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace senai.inlock.webApi.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private const string CONEXAO = "Data Source=NOTE0113C2\\SQLEXPRESS; initial catalog=inlock_games_tarde; user Id=sa; pwd=Senai@132";
        //private const string CONEXAO = "Data Source=PANZERII\\SQLEXPRESS; initial catalog=inlock_games_tarde; user Id=sa; pwd=senai@#132";

        public UsuarioDomain Login(string email, string senha)
        {
            using (SqlConnection abrirBD = new SqlConnection(CONEXAO))
            {
                string querySelect = @" SELECT idUsuario, email, senha, idTipoUsuario FROM USUARIOS
                                        WHERE email = @email AND senha = @senha;                                        
                                        ";
                using (SqlCommand aoAbrirExec = new SqlCommand(querySelect, abrirBD))
                {
                    aoAbrirExec.Parameters.AddWithValue("@email", email);
                    aoAbrirExec.Parameters.AddWithValue("senha", senha);

                    abrirBD.Open();

                    SqlDataReader ler = aoAbrirExec.ExecuteReader();

                    if (ler.Read())
                    {
                        UsuarioDomain usuarioAutenticado = new UsuarioDomain
                        {
                            idUsuario = Convert.ToInt32(ler["idUsuario"]),
                            email = ler["email"].ToString(),
                            senha = ler["senha"].ToString(),
                            idTipoUsuario = Convert.ToInt32(ler["idTipoUsuario"]),
                            tipoUsuario = new TipoUsuarioDomain()
                            {

                                titulo = ler[""].ToString()
                            }

                        };

                        return usuarioAutenticado;
                    }

                    return null;
                }
            }
        }
    }
}
