using senai.inLock.webAPI.Interfaces;
using System;
using System.Data.SqlClient;
using WebApplication1.Properties.Domains;

namespace senai.inLock.webAPI.Repositories
{
    public class UsuarioRepository : IUsuariosRepository
    {

        private readonly string stringConexao = @"Data Source=LAPTOP-404RQHFB\SQLEXPRESS; initial catalog=inLock_games; user Id=sa; pwd=Alexandre2002";
        //private readonly string stringConexao = "Data Source=DESKTOP-C8POL51\\SQLSERVEREXPRESS; initial catalog = inlock_games_manha; user Id = sa; pwd=senai@132";


        public UsuariosDomain Login(string email, string senha)
        {
            using SqlConnection con = new(stringConexao);
            string querySelect = "SELECT idUsuario, email, U.idTipoUsuario, TU.titulo " +
                                 "FROM Usuarios U INNER JOIN TiposDeUsuarios TU ON U.idTipoUsuario = TU.idTipoUsuario " +
                                 "WHERE email = @email AND senha = @senha";

            // Define o comando cmd passando a query e a conexão
            using SqlCommand cmd = new(querySelect, con);
            // Define os valores dos parâmetros
            cmd.Parameters.AddWithValue("@email", email);
            cmd.Parameters.AddWithValue("@senha", senha);

            // Abre a conexão com o banco de dados
            con.Open();

            // Executa o comando e armazena os dados no objeto rdr
            SqlDataReader rdr = cmd.ExecuteReader();

            // Caso dados tenham sido obtidos
            if (rdr.Read())
            {
                // Cria um objeto do tipo UsuarioDomain
                UsuariosDomain usuarioBuscado = new()
                {
                    // Atribui às propriedades os valores das colunas do banco de dados
                    IdUsuarios = Convert.ToInt32(rdr["idUsuario"]),
                    Email = rdr["email"].ToString(),
                    IdTipoUsuario = Convert.ToInt32(rdr["idTipoUsuario"]),
                    TipoUsuario = new TiposDeUsuariosDomain()
                    {
                        Titulo = rdr["titulo"].ToString()
                    }
                };

                // Retorna o usuário buscado
                return usuarioBuscado;
            }

            // Caso não encontre um email e senha correspondente, retorna null
            return null;
        }
    }
}
