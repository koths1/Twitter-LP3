using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace Fafa10052018
{
    class Banco
    {
        private string conexao = "Server=127.0.0.1;Port=5432;Database=fafa;User Id=postgres;Password=1234;";
        private NpgsqlConnection Conn;
        private void Conexecao()
        {
            Conn = new NpgsqlConnection(conexao);
        }
        public NpgsqlConnection abrirConexao()
        {
            try
            {
                Conexecao();
                Conn.Open();
                return Conn;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public void fecharConexao()
        {
            try
            {
                Conn.Close();
            }
            catch (Exception)
            {
                throw;
            }
        }
        public DataTable Consultar(String sql)
        {
            abrirConexao();
            try
            {
                NpgsqlCommand command = new NpgsqlCommand(sql, Conn);
                command.ExecuteNonQuery();
                NpgsqlDataAdapter DA = new NpgsqlDataAdapter(command);
                DataTable DT = new DataTable();
                DA.Fill(DT);
                return DT;
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                fecharConexao();
            }
        }
    }
}