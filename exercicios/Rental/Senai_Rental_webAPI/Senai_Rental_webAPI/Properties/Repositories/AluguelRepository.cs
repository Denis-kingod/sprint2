using senai_rental_webAPI.Properties.Interfaces;
using Senai_Rental_webAPI.Properties.Domains;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace senai_rental_webAPI.Properties.Repositories
{
    public class AluguelRepository : IAluguelRepository
    {
        private readonly string stringConexao = "Data Source=NOTE0113C1\\SQLEXPRESS; initial catalog=LOCADORA; user Id=sa; pwd=Senai@132";
        public void Atualizar(AluguelDomain AluguelAtualizado)
        {
            using SqlConnection con = new SqlConnection(stringConexao);
            string queryUpdate = "UPDATE Aluguel SET idVeiculo = @NovoVeiculo, idCliente = @NovoCliente, Data1 = @novaData1 WHERE idAluguel = @idaluguel;";

            con.Open();

            using SqlCommand cmd = new(queryUpdate, con);
            cmd.Parameters.AddWithValue("@novoVeiculo", AluguelAtualizado.IdVeiculo);
            cmd.Parameters.AddWithValue("@novoCliente", AluguelAtualizado.IdCliente);
            cmd.Parameters.AddWithValue("@novaData1", AluguelAtualizado.Data1);

            cmd.Parameters.AddWithValue("@idaluguel", AluguelAtualizado.IdAluguel);

            cmd.ExecuteNonQuery();
        }

           
        public AluguelDomain BuscarPorId(int IdProcurar)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string queryselectById = "SELECT IdAluguel, Cliente.idCliente, NomeCliente,  NomeModelo, Aluguel.idVeiculo, CorVeiculo, Data1 FROM Aluguel INNER JOIN Cliente ON Aluguel.IdCliente = Cliente.IdCliente INNER JOIN Veiculo ON Aluguel.IdVeiculo = Veiculo.IdVeiculo INNER JOIN Modelo ON Veiculo.IdModelo = Modelo.IdModelo WHERE IdAluguel = @idaluguel;";

                con.Open();

                SqlDataReader rdr;

                using (SqlCommand cmd = new SqlCommand(queryselectById, con))
                {
                    cmd.Parameters.AddWithValue("@idaluguel", IdProcurar);

                    rdr = cmd.ExecuteReader();

                    if (rdr.Read())
                    {
                        AluguelDomain aluguelBuscado = new AluguelDomain()
                        {

                            IdAluguel = Convert.ToInt32(rdr[0]),
                            IdCliente = Convert.ToInt32(rdr[1]),
                            IdVeiculo = Convert.ToInt32(rdr[4]),
                            Cliente = new ClienteDomain()
                            {
                                idCliente = Convert.ToInt32(rdr[1]),
                                NomeCliente = rdr[2].ToString(),
                            },
                            Veiculo = new VeiculoDomain()
                            {
                                Modelo = new ModeloDomain()
                                {
                                    NomeModelo = rdr[3].ToString()
                                },
                                IdVeiculo = Convert.ToInt32(rdr[4]),
                                CorVeiculo = rdr[5].ToString()
                            },
                            Data1 = Convert.ToDateTime(rdr[6]),
                        };

                        return aluguelBuscado;
                    }
                }

                return null;
            }
        }


        public void Cadastrar(AluguelDomain NovoAluguel)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string queryInsert = "INSERT INTO Aluguel(IdVeiculo, IdCliente, Data1) VALUES (@novoVeiculo, @novoCliente, @novaData1);";

                con.Open();

                using (SqlCommand cmd = new SqlCommand(queryInsert, con))
                {
                    cmd.Parameters.AddWithValue("@novoVeiculo", NovoAluguel.IdVeiculo);
                    cmd.Parameters.AddWithValue("@novoCliente", NovoAluguel.IdCliente);
                    cmd.Parameters.AddWithValue("@novaData1", NovoAluguel.Data1);

                    cmd.ExecuteNonQuery();

                }
            }
        }

        public void Deletar(int IdDeletar)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string queryDelete = "DELETE FROM Aluguel WHERE IdAluguel = @idaluguel;";

                con.Open();

                using (SqlCommand cmd = new SqlCommand(queryDelete, con))
                {
                    cmd.Parameters.AddWithValue("@idaluguel", IdDeletar);

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public List<AluguelDomain> ListarTodos()
        {
            List<AluguelDomain> ListaAlugueis = new List<AluguelDomain>();

            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string queryselectAll = "SELECT IdAluguel, Cliente.idCliente, NomeCliente,  NomeModelo, Aluguel.idVeiculo, CorVeiculo, Data1 FROM Aluguel INNER JOIN Cliente ON Aluguel.IdCliente = Cliente.IdCliente INNER JOIN Veiculo ON Aluguel.IdVeiculo = Veiculo.IdVeiculo INNER JOIN Modelo ON Veiculo.IdModelo = Modelo.IdModelo;";

                con.Open();

                SqlDataReader rdr;

                using (SqlCommand cmd = new SqlCommand(queryselectAll, con))
                {
                    rdr = cmd.ExecuteReader();

                    while (rdr.Read())
                    {
                        AluguelDomain aluguel = new AluguelDomain()
                        {


                            IdAluguel = Convert.ToInt32(rdr[0]),
                            IdCliente = Convert.ToInt32(rdr[1]),
                            IdVeiculo = Convert.ToInt32(rdr[4]),
                            Cliente = new ClienteDomain()
                            {
                                idCliente = Convert.ToInt32(rdr[1]),
                                NomeCliente = rdr[2].ToString(),
                            },
                            Veiculo = new VeiculoDomain()
                            {
                                Modelo = new ModeloDomain()
                                {
                                    NomeModelo = rdr[3].ToString()
                                },
                                IdVeiculo = Convert.ToInt32(rdr[4]),
                                CorVeiculo = rdr[5].ToString()
                            },
                            Data1 = Convert.ToDateTime(rdr[6]),
                        };

                        ListaAlugueis.Add(aluguel);
                    }
                }

                return ListaAlugueis;
            }
        }
    }
}