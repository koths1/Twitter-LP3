using Npgsql;
using NpgsqlTypes;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace Fafa10052018
{
    public class Usuario
    {
        private int id;
        private string nome;
        private string senha;
        private int seguidores;
        private byte[] imagem;

        public Usuario(int id,string nome, string senha)
        {
            this.id = id;
            this.nome = nome;
            this.senha = senha;
        }

        public Usuario(string nome, string senha)
        {
            this.nome = nome;
            this.senha = senha;
        }

        public Usuario(int id)
        {
            this.id = id;
            pegarDados();
        }

        public void setId(int id)
        {
            this.id = id;
        }

        public int getId()
        {
            return this.id;
        }

        public void setNome(string nome)
        {
            this.nome = nome;
        }

        public string getNome()
        {
            return this.nome;
        }

        public void setSenha(string senha)
        {
            this.senha = senha;
        }

        public string getSenha()
        {
            return this.senha;
        }

        public void setSeguidores(int seg)
        {
            this.seguidores = seg;
        }

        public int getSeguidores()
        {
            return this.seguidores;
        }

        public void setImagem(byte[] imagem)
        {
            this.imagem = imagem;
        }

        public byte[] getImagem()
        {
            return this.imagem;
        }

        public bool gravarUsuarioFoto(byte[] img)
        {
            Banco bd = new Banco();

            NpgsqlConnection cn = bd.abrirConexao();

            NpgsqlTransaction tran = null;

            NpgsqlCommand cmd = new NpgsqlCommand();
            tran = cn.BeginTransaction();

            cmd.Connection = cn;
            cmd.Transaction = tran;
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "insert into Perfil(Nome,Senha,Foto) values (@nome, @senha, @foto)";
            cmd.Parameters.Add("@nome", NpgsqlDbType.Varchar);
            cmd.Parameters.Add("@senha", NpgsqlDbType.Varchar);
            cmd.Parameters.Add("@foto", NpgsqlDbType.Bytea);
            cmd.Parameters[0].Value = nome;
            cmd.Parameters[1].Value = senha;
            cmd.Parameters[2].Value = img;

            try
            {
                cmd.ExecuteNonQuery();
                tran.Commit();
                return true;
            }
            catch (Exception)
            {
                tran.Rollback();                
                return false;
            }
            finally
            {
                bd.fecharConexao();
            }
        }

        public bool gravarUsuario()
        {
            Banco bd = new Banco();

            NpgsqlConnection cn = bd.abrirConexao();

            NpgsqlTransaction tran = null;

            NpgsqlCommand cmd = new NpgsqlCommand();
            tran = cn.BeginTransaction();

            cmd.Connection = cn;
            cmd.Transaction = tran;
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "insert into Perfil(Nome, Senha) values (@nome, @senha)";
            cmd.Parameters.Add("@nome", NpgsqlDbType.Varchar);
            cmd.Parameters.Add("@senha", NpgsqlDbType.Varchar);
            cmd.Parameters[0].Value = nome;
            cmd.Parameters[1].Value = senha;

            try
            {
                cmd.ExecuteNonQuery();
                tran.Commit();
                return true;
            }
            catch (Exception)
            {
                tran.Rollback();
                return false;
            }
            finally
            {
                bd.fecharConexao();
            }
        }


        public void pegarDados()
        {
            Banco bd = new Banco();
            NpgsqlConnection cn = bd.abrirConexao();
            NpgsqlTransaction tran = null;
            NpgsqlCommand cmd = new NpgsqlCommand();
            tran = cn.BeginTransaction();

            try
            {
                cmd.Connection = cn;
                cmd.Transaction = tran;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "select Nome,Senha,Foto from Perfil where idperfil=@id";
                cmd.Parameters.Add("@id", NpgsqlDbType.Integer);
                cmd.Parameters[0].Value = id;
                NpgsqlDataAdapter DA = new NpgsqlDataAdapter(cmd);
                DataTable DT = new DataTable();
                DA.Fill(DT);
                this.nome=DT.Rows[0]["Nome"].ToString();
                this.senha=DT.Rows[0]["Senha"].ToString();
                if (DT.Rows[0]["Foto"] != DBNull.Value)
                {
                    this.imagem = (byte[])DT.Rows[0]["Foto"];    
                }
                
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                bd.fecharConexao();
            }
        }

        public bool validarUsuario()
        {
            Banco bd = new Banco();

            NpgsqlConnection cn = bd.abrirConexao();

            NpgsqlTransaction tran = null;

            NpgsqlCommand cmd = new NpgsqlCommand();
            tran = cn.BeginTransaction();

            try 
	        {
                cmd.Connection = cn;
                cmd.Transaction = tran;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "select idperfil,Nome,Senha,Foto from Perfil where Nome=@nome and Senha=@senha";
                cmd.Parameters.Add("@nome", NpgsqlDbType.Varchar);
                cmd.Parameters.Add("@senha", NpgsqlDbType.Varchar);
                cmd.Parameters[0].Value = nome;
                cmd.Parameters[1].Value = senha;
                NpgsqlDataAdapter DA = new NpgsqlDataAdapter(cmd);
                DataTable DT = new DataTable();
                DA.Fill(DT);
                if (DT.Rows.Count > 0)
                {
                    this.id = int.Parse(DT.Rows[0]["idperfil"].ToString());
                    if (DT.Rows[0]["foto"] != DBNull.Value)
                    {
                        this.imagem = (byte[])DT.Rows[0]["Foto"];
                    }                    
                    return true;
                }
                else
                {
                    return false;
                }   
	        }
	        catch (Exception ex)
	        {		
		        throw;
	        }            
            finally
            {
                bd.fecharConexao();
            }
        }

        public bool Tweetar(string tweet,DateTime quando)
        {
            Banco bd = new Banco();
            NpgsqlConnection cn = bd.abrirConexao();
            NpgsqlTransaction tran = null;
            NpgsqlCommand cmd = new NpgsqlCommand();
            tran = cn.BeginTransaction();

            try
            {                
                cmd.Connection = cn;
                cmd.Transaction = tran;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "insert into Tweet(Conteudo,Perfil,quando) Values(@conteudo,@perfil,@quando)";
                cmd.Parameters.Add("@conteudo", NpgsqlDbType.Varchar);
                cmd.Parameters.Add("@perfil", NpgsqlDbType.Integer);
                cmd.Parameters.Add("@quando", NpgsqlDbType.Timestamp);
                cmd.Parameters[0].Value = tweet;
                cmd.Parameters[1].Value = id;
                cmd.Parameters[2].Value = quando;
                cmd.ExecuteNonQuery();
                tran.Commit();
                return true;
            }
            catch (Exception)
            {
                tran.Rollback();
                return false;
                throw;
            }
            finally
            {
                bd.fecharConexao();
            }
        }
        public DataTable pegarTweets()
        {
            Banco bd = new Banco();
            NpgsqlConnection cn = bd.abrirConexao();
            NpgsqlTransaction tran = null;
            NpgsqlCommand cmd = new NpgsqlCommand();
            tran = cn.BeginTransaction();

            try
            {
                cmd.Connection = cn;
                cmd.Transaction = tran;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "select nome,foto,conteudo,quando from tweet,perfil where perfil.idperfil=tweet.perfil and perfil=@id order by quando desc";
                cmd.Parameters.Add("@id", NpgsqlDbType.Integer);
                cmd.Parameters[0].Value = id;
                NpgsqlDataAdapter DA = new NpgsqlDataAdapter(cmd);
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
                bd.fecharConexao();
            }
        }

        public DataTable pegarTweetsSeguidos()
        {
            Banco bd = new Banco();
            NpgsqlConnection cn = bd.abrirConexao();
            NpgsqlTransaction tran = null;
            NpgsqlCommand cmd = new NpgsqlCommand();
            tran = cn.BeginTransaction();

            try
            {
                cmd.Connection = cn;
                cmd.Transaction = tran;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "Select idperfil,nome,foto,conteudo,quando from tweet,perfil where perfil.idperfil=tweet.perfil AND tweet.perfil in (select perfil from seguidores where seguidor=@id) union select idperfil,nome,foto,conteudo,quando from tweet,perfil where perfil.idperfil=tweet.perfil and perfil=@id order by quando desc";
                cmd.Parameters.Add("@id", NpgsqlDbType.Integer);
                cmd.Parameters[0].Value = id;
                NpgsqlDataAdapter DA = new NpgsqlDataAdapter(cmd);
                DataTable DT = new DataTable();
                DA.Fill(DT);
                return DT;
            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                bd.fecharConexao();
            }
        }

        public DataTable buscaSeguidores()
        {
            Banco bd = new Banco();
            NpgsqlConnection cn = bd.abrirConexao();
            NpgsqlTransaction tran = null;
            NpgsqlCommand cmd = new NpgsqlCommand();
            tran = cn.BeginTransaction();

            try
            {
                cmd.Connection = cn;
                cmd.Transaction = tran;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "select seguidor from seguidores where perfil=@perfil";
                cmd.Parameters.Add("@perfil", NpgsqlDbType.Integer);
                cmd.Parameters[0].Value = id;
                NpgsqlDataAdapter DA = new NpgsqlDataAdapter(cmd);
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
                bd.fecharConexao();
            }
        }

        public bool seguir(int seguidor)
        {
            Banco bd = new Banco();
            NpgsqlConnection cn = bd.abrirConexao();
            NpgsqlTransaction tran = null;
            NpgsqlCommand cmd = new NpgsqlCommand();
            tran = cn.BeginTransaction();

            try
            {
                cmd.Connection = cn;
                cmd.Transaction = tran;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "insert into Seguidores(perfil,seguidor) values (@perfil,@seguidor)";
                cmd.Parameters.Add("@perfil", NpgsqlDbType.Integer);
                cmd.Parameters.Add("@seguidor", NpgsqlDbType.Integer);
                cmd.Parameters[0].Value = id;
                cmd.Parameters[1].Value = seguidor;
                cmd.ExecuteNonQuery();
                tran.Commit();
                return true;
            }
            catch (Exception)
            {
                tran.Rollback();
                throw;
            }
            finally
            {
                bd.fecharConexao();
            }
        }

        public bool pararDeSeguir(int seguidor)
        {
            Banco bd = new Banco();
            NpgsqlConnection cn = bd.abrirConexao();
            NpgsqlTransaction tran = null;
            NpgsqlCommand cmd = new NpgsqlCommand();
            tran = cn.BeginTransaction();
            cmd.Connection = cn;
            cmd.Transaction = tran;
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "delete from Seguidores where perfil=@perfil and seguidor=@seguidor";
            cmd.Parameters.Add("@perfil", NpgsqlDbType.Integer);
            cmd.Parameters.Add("@seguidor", NpgsqlDbType.Integer);
            cmd.Parameters[0].Value = id;
            cmd.Parameters[1].Value = seguidor;

            try
            {
                cmd.ExecuteNonQuery();
                tran.Commit();
                return true;
            }
            catch (Exception)
            {
                tran.Rollback();
                return false;
            }
            finally
            {
                bd.fecharConexao();
            }
        }

        public bool alterarFoto()
        {
            Banco bd = new Banco();
            NpgsqlConnection cn = bd.abrirConexao();
            NpgsqlTransaction tran = null;
            NpgsqlCommand cmd = new NpgsqlCommand();
            tran = cn.BeginTransaction();

            cmd.Connection = cn;
            cmd.Transaction = tran;
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "update Perfil set foto=@foto where idperfil=@id";
            cmd.Parameters.Add("@foto", NpgsqlDbType.Bytea);
            cmd.Parameters.Add("@id", NpgsqlDbType.Integer);
            cmd.Parameters[0].Value = imagem;
            cmd.Parameters[1].Value = id;

            try
            {
                cmd.ExecuteNonQuery();
                tran.Commit();
                return true;
            }
            catch (Exception)
            {
                tran.Rollback();
                return false;
            }
            finally
            {
                bd.fecharConexao();
            }
        }
    }
}