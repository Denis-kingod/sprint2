using senai.inLock.webAPI.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using WebApplication1.Properties.Domains;

namespace senai.inLock.webAPI.Repositories
{
    public class JogosRepository : IJogosRepository
    {
        private readonly string stringConexao = @"Data Source=LAPTOP-404RQHFB\SQLEXPRESS; initial catalog=inLock_games; user Id=sa; pwd=Alexandre2002";

        public void Atualizar(int id, JogosDomain jogoAtualizado)
        {
            throw new NotImplementedException();
        }

        public JogosDomain BuscarPorId(int id)
        {
            throw new NotImplementedException();
        }

        public void Cadastrar(JogosDomain novoJogo)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string queryInsert = "INSERT INTO jogos(nomeJogo, descricao, dataLancamento, valor, idEstudio)" +
                                     "VALUES(@nomeJogo, @descricao, @dataLancamento, @valor, @idEstudio)";

                using (SqlCommand cmd = new SqlCommand(queryInsert, con))
                {
                    cmd.Parameters.AddWithValue("@nomeJogo", novoJogo.NomeJogo);
                    cmd.Parameters.AddWithValue("@descricao", novoJogo.Descricao);
                    cmd.Parameters.AddWithValue("@dataLancamento", novoJogo.DataLancamento);
                    cmd.Parameters.AddWithValue("@valor", novoJogo.Valor);
                    cmd.Parameters.AddWithValue("@idEstudio", novoJogo.IdEstudio);

                    con.Open();

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void Deletar(int id)
        {
            throw new NotImplementedException();
        }

        public List<JogosDomain> ListarTodos()
        {
            List<JogosDomain> listaJogos = new List<JogosDomain>();

            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string querySelectAll = "SELECT J.IdJogo, NomeJogo, Descricao, DataLancamento, Valor, J.IdEstudio, E.NomeEstudio FROM Jogos J " +
                                        "INNER JOIN Estudios E " +
                                        "ON J.IdEstudio = E.IdEstudio";

                con.Open();

                SqlDataReader rdr;

                using (SqlCommand cmd = new SqlCommand(querySelectAll, con))
                {
                    rdr = cmd.ExecuteReader();

                    while (rdr.Read())
                    {
                        JogosDomain jogo = new JogosDomain()
                        {
                            IdJogo = Convert.ToInt32(rdr[0]),

                            NomeJogo = rdr[1].ToString(),

                            Descricao = rdr[2].ToString(),

                            DataLancamento = Convert.ToDateTime(rdr[3]),

                            Valor = (Decimal)Convert.ToDecimal(rdr[4]),

                            IdEstudio = Convert.ToInt32(rdr[5]),

                            Estudio = new EstudiosDomain()
                            {
                                NomeEstudio = rdr[6].ToString()
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