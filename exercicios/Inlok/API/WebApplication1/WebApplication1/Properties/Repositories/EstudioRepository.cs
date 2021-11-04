using senai.inLock.webAPI.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Properties.Domains;

namespace senai_inlock_webAPI.Properties.Repositories
{
    public class EstudiosRepository : IEstudiosRepository
    {
        private readonly string stringConexao = @"Data Source=LAPTOP-404RQHFB\SQLEXPRESS; initial catalog=inLock_games; user Id=sa; pwd=Alexandre2002";


        public void Atualizar(int idEstudio, EstudiosDomain estudioAtualizado)
        {
            if (estudioAtualizado.NomeEstudio != null)
            {
                using (SqlConnection con = new SqlConnection(stringConexao))
                {
                    string queryUpdateBody = "UPDATE Estudio SET nomeEstudio = @novoNome WHERE idEstudio = @idEstudio;";

                    using (SqlCommand cmd = new SqlCommand(queryUpdateBody, con))
                    {
                        cmd.Parameters.AddWithValue("@idEstudio", idEstudio);
                        cmd.Parameters.AddWithValue("@novoNome", estudioAtualizado.NomeEstudio);

                        con.Open();

                        cmd.ExecuteNonQuery();
                    }
                }
            }
        }

        public EstudiosDomain BuscarPorId(int idEstudio)
        {
            EstudiosDomain buscarEstudio = new EstudiosDomain();
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string querySearchById = "SELECT idEstudio, nomeEstudio FROM Estudio WHERE idEstudio= @idEstudio;";

                con.Open();

                SqlDataReader rdr;

                using (SqlCommand cmd = new SqlCommand(querySearchById, con))
                {
                    cmd.Parameters.AddWithValue("@idEstudio", idEstudio);
                    rdr = cmd.ExecuteReader();

                    while (rdr.Read())
                    {
                        buscarEstudio.IdEstudio = Convert.ToInt32(rdr[0]);
                        buscarEstudio.NomeEstudio = rdr[1].ToString();

                    }
                    return (buscarEstudio);
                }
            }
        }

        public void Cadastrar(EstudiosDomain novoEstudio)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {

                string queryInsert = "INSERT INTO Estudio (nomeEstudio) VALUES (@nomeEstudio)";

                using (SqlCommand cmd = new SqlCommand(queryInsert, con))
                {
                    cmd.Parameters.AddWithValue("@nomeEstudio", novoEstudio.NomeEstudio);

                    con.Open();

                    cmd.ExecuteNonQuery();

                }
            }
        }

        public void Deletar(int idEstudio)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string queryDelete = "DELETE FROM Estudio WHERE idEstudio = @id";

                using (SqlCommand cmd = new SqlCommand(queryDelete, con))
                {
                    cmd.Parameters.AddWithValue("@id", idEstudio);

                    con.Open();

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public List<EstudiosDomain> ListarComJogos()
        {
            throw new NotImplementedException();
        }

        public List<EstudiosDomain> ListarTodos()
        {
            List<EstudiosDomain> listaEstudios = new List<EstudiosDomain>();

            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string querySelectAll = "SELECT * FROM Estudios;";

                con.Open();

                SqlDataReader rdr;

                using (SqlCommand cmd = new SqlCommand(querySelectAll, con))
                {

                    rdr = cmd.ExecuteReader();

                    while (rdr.Read())
                    {
                        EstudiosDomain estudio = new EstudiosDomain()
                        {

                            IdEstudio = Convert.ToInt32(rdr[0]),

                            NomeEstudio = rdr[1].ToString(),

                        };

                        listaEstudios.Add(estudio);

                    }
                }
            };
            return listaEstudios;
        }
    }
}

