using senai_rental_webAPI.Properties.Interfaces;
using Senai_Rental_webAPI.Properties.Domains;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace senai_rental_webAPI.Properties.Repositories
{
    public class VeiculoRepository : IVeiculoRepository
    {
        private readonly string stringConexao = "Data Source=NOTE0113C1\\SQLEXPRESS; initial catalog=LOCADORA; user Id=sa; pwd=Senai@132";

        public void Atualizar(VeiculoDomain VeiculoAtualizado)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string queryUpdate = "UPDATE Veiculo SET IdModelo = @idModelo, CorVeiculo = @NovoCorVeiculo, IdEmpresa = @idEmpresa WHERE IdVeiculo = @IdVeiculo;";

                con.Open();

                using (SqlCommand cmd = new SqlCommand(queryUpdate, con))
                {
                    cmd.Parameters.AddWithValue("@idModelo", VeiculoAtualizado.IdModelo);
                    cmd.Parameters.AddWithValue("@NovoCorVeiculo", VeiculoAtualizado.CorVeiculo);
                    cmd.Parameters.AddWithValue("@idEmpresa", VeiculoAtualizado.IdEmpresa);
                    cmd.Parameters.AddWithValue("@idVeiculo", VeiculoAtualizado.IdVeiculo);

                    cmd.ExecuteNonQuery();

                }
            }
        }

        public VeiculoDomain BuscarPorId(int IdProcurar)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string querySelectById = "SELECT IdVeiculo, Empresa.IdEmpresa, NomeEmpresa, NomeMarca, CorVeiculo  FROM Veiculo LEFT JOIN Empresa ON Veiculo.IdEmpresa = Empresa.IdEmpresa INNER JOIN Modelo ON Veiculo.IdModelo = Modelo.IdModelo INNER JOIN Marca ON Modelo.IdMarca = Marca.IdMarca WHERE IdVeiculo = @idVeiculo;";

                con.Open();

                SqlDataReader rdr;

                using (SqlCommand cmd = new(querySelectById, con))
                {
                    cmd.Parameters.AddWithValue("@idVeiculo", IdProcurar);

                    rdr = cmd.ExecuteReader();

                    if (rdr.Read())
                    {
                        VeiculoDomain veiculoBuscado = new VeiculoDomain()
                        {
                            IdVeiculo = Convert.ToInt32(rdr[0]),
                            Empresa = new EmpresaDomain()
                            {
                                IdEmpresa = Convert.ToInt32(rdr[1]),
                                NomeEmpresa = rdr[2].ToString()
                            },
                            Marca = new MarcaDomain()
                            {
                                NomeMarca = rdr[3].ToString()

                            },
                            CorVeiculo = rdr[4].ToString()
                        };
                        return veiculoBuscado;
                    }
                    return null;
                }
            }
        }

        public void Cadastrar(VeiculoDomain NovoVeiculo)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string queryInsert = "INSERT INTO Veiculo(IdEmpresa,IdModelo,CorVeiculo) VALUES (@novaEmpresa, @novoModelo, @novaCorVeiculo)";

                con.Open();

                using (SqlCommand cmd = new SqlCommand(queryInsert, con))
                {
                    cmd.Parameters.AddWithValue("@novaEmpresa", NovoVeiculo.IdEmpresa);
                    cmd.Parameters.AddWithValue("@novoModelo", NovoVeiculo.IdModelo);
                    cmd.Parameters.AddWithValue("@novaCorVeiculo", NovoVeiculo.CorVeiculo);

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void Deletar(int IdDeletar)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string queryDelete = "DELETE FROM Veiculos WHERE IdVeiculo = @idVeiculo;";

                con.Open();

                using (SqlCommand cmd = new SqlCommand(queryDelete, con))
                {
                    cmd.Parameters.AddWithValue("@idVeiculo", IdDeletar);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public List<VeiculoDomain> ListarTodos()
        {
            List<VeiculoDomain> ListaVeiculos = new List<VeiculoDomain>();

            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string querySelectAll = "SELECT IdVeiculo, NomeEmpresa,  NomeMarca, CorVeiculo FROM Veiculo LEFT JOIN Empresa ON Veiculo.IdEmpresa = Empresa.IdEmpresa INNER JOIN Modelo ON Veiculo.IdModelo = Modelo.IdModelo INNER JOIN Marca ON Modelo.IdMarca = Marca.IdMarca;";
                con.Open();

                SqlDataReader rdr;

                using (SqlCommand cmd = new SqlCommand(querySelectAll, con))
                {

                    rdr = cmd.ExecuteReader();

                    while (rdr.Read())
                    {
                        VeiculoDomain veiculo = new VeiculoDomain()
                        {
                            IdVeiculo = Convert.ToInt32(rdr[0]),
                            Empresa = new EmpresaDomain()
                            {
                                NomeEmpresa = rdr[1].ToString()
                            },
                            Modelo = new ModeloDomain()
                            {
                                NomeModelo = rdr[2].ToString(),
                            },
                        };
                        ListaVeiculos.Add(veiculo);
                    }
                    return ListaVeiculos;
                }
            }
        }
    }
}
