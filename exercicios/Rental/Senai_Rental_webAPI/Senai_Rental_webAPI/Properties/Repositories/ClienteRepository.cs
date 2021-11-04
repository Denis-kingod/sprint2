using senai_rental_webAPI.Properties.Interfaces;
using Senai_Rental_webAPI.Properties.Domains;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace senai_rental_webAPI.Properties.Repositories
{
    public class ClienteRepository : IClienteRepository
    {
        private readonly string stringConexao = "Data Source=NOTE0113C1\\SQLEXPRESS; initial catalog=LOCADORA; user Id=sa; pwd=Senai@132";

        public void Atualizar(ClienteDomain ClienteAtualizado)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string queryUpdate = "UPDATE Alugueis SET IdVeiculo = @novoVeiculo, IdCliente = @novoCliente, DataInicio = @novaData1, DataFim = @novaDataD WHERE IdAluguel = @idaluguel;";

                con.Open();
                using (SqlCommand cmd = new(queryUpdate, con))
                {
                    cmd.Parameters.AddWithValue("@NovoNome", ClienteAtualizado.NomeCliente);
                    cmd.Parameters.AddWithValue("@novoCPF", ClienteAtualizado.CPF);
                    cmd.Parameters.AddWithValue("@Id", ClienteAtualizado.idCliente);

                    cmd.ExecuteNonQuery();

                }
            }
        }

        public ClienteDomain BuscarPorId(int IdProcurar)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string querySelectById = "SELECT IdCliente, NomeCliente, CPF FROM Cliente WHERE idCliente = @idCliente;";

                con.Open();

                SqlDataReader rdr;

                using SqlCommand cmd = new(querySelectById, con);
                cmd.Parameters.AddWithValue("@idCliente", IdProcurar);

                rdr = cmd.ExecuteReader();

                if (rdr.Read())
                {
                    ClienteDomain clienteBuscado = new ClienteDomain()
                    {
                        idCliente = Convert.ToInt32(rdr[0]),
                        NomeCliente = rdr[1].ToString(),
                        CPF = rdr[2].ToString()
                    };
                    return clienteBuscado;
                }
                return null;
            }
        }

        public void Cadastrar(ClienteDomain NovoCliente)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string queryInsert = "INSERT INTO Clientes(Nome, CPF) VALUES (@novoNome, @novoCPF";

                con.Open();

                using (SqlCommand cmd = new SqlCommand(queryInsert, con))
                {
                    cmd.Parameters.AddWithValue("@novoNome", NovoCliente.NomeCliente);
                    cmd.Parameters.AddWithValue("@novoCPF", NovoCliente.CPF);

                    cmd.ExecuteNonQuery();

                }
            }
        }

        public void Deletar(int IdDeletar)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string queryDelete = "DELETE FROM Clientes WHERE IdCliente = @idCliente";

                con.Open();

                using (SqlCommand cmd = new SqlCommand(queryDelete, con))
                {
                    cmd.Parameters.AddWithValue("@idCliente", IdDeletar);

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public List<ClienteDomain> ListarTodos()
        {
            List<ClienteDomain> ListaClientes = new List<ClienteDomain>();

            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string querySelectAll = "SELECT IdCliente, NomeCliente, CPF FROM Cliente";

                con.Open();

                SqlDataReader rdr;

                using (SqlCommand cmd = new SqlCommand(querySelectAll, con))
                {
                    rdr = cmd.ExecuteReader();

                    while (rdr.Read())
                    {
                        ClienteDomain cliente = new ClienteDomain()
                        {
                            idCliente = Convert.ToInt32(rdr[0]),
                            NomeCliente = rdr[1].ToString(),
                            CPF = rdr[2].ToString()
                        };

                        ListaClientes.Add(cliente);

                    }
                }
            }
            return ListaClientes;
        }
    }
}