using ControleDeTarefasEContatos.ConsoleApp.Dominios;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;


namespace ControleDeTarefasEContatos.ConsoleApp.Controlador
{
    public abstract class Controlador<T> where T : EntidadeBase
    {
        public bool InserirRegistro(T registro)
        {
            SqlConnection conexaoComBanco = AbrindoConexaoComBD();

            SqlCommand comandoInsercao = new SqlCommand();
            comandoInsercao.Connection = conexaoComBanco;

            string sqlInsercao =

                $@"INSERT INTO { Tabela}
                    (
                        { Valores}
	                ) 
	                VALUES
                    (
                        { Formatador(Valores)}
	                ); ";

            sqlInsercao +=
                @"SELECT SCOPE_IDENTITY();";

            comandoInsercao.CommandText = sqlInsercao;

            Inserir(comandoInsercao, registro);

            object id = comandoInsercao.ExecuteScalar();

            registro.Id = Convert.ToInt32(id);

            FechandoConexaoComBD(conexaoComBanco);
            return true;
        }
        public bool EditarRegistro(T registro, int id)
        {
            SqlConnection conexaoComBanco = AbrindoConexaoComBD();

            SqlCommand comandoEdicao = new SqlCommand();
            comandoEdicao.Connection = conexaoComBanco;

            string sqlEdicao =
                $@"UPDATE {Tabela}
	                SET
		                {Atualizar}
	                WHERE 
                        [ID] = @ID";

            comandoEdicao.CommandText = sqlEdicao;

            Editar(comandoEdicao, id, registro);

            comandoEdicao.ExecuteNonQuery();

            FechandoConexaoComBD(conexaoComBanco);
            return true;
        }
        public bool ExcluirRegistro(int id)
        {
            SqlConnection conexaoComBanco = AbrindoConexaoComBD();
            SqlCommand comandoExclusao = new SqlCommand();
            comandoExclusao.Connection = conexaoComBanco;

            string sqlExclusao =

                $@"DELETE FROM {Tabela}
                    WHERE
                        [ID] = @ID";

            comandoExclusao.CommandText = sqlExclusao;

            comandoExclusao.Parameters.AddWithValue("ID", id);

            comandoExclusao.ExecuteNonQuery();

            FechandoConexaoComBD(conexaoComBanco);
            return true;
        }
        public List<T> VisualizarTodosRegistros()
        {
            SqlConnection conexaoComBanco = AbrindoConexaoComBD();

            SqlCommand comandoSelecao = new SqlCommand();
            comandoSelecao.Connection = conexaoComBanco;

            string sqlSelecao = $@"SELECT * FROM {Tabela}";

            comandoSelecao.CommandText = sqlSelecao;

            SqlDataReader leitorTarefas = comandoSelecao.ExecuteReader();

            List<T> registros = new List<T>();

            if (typeof(T) == typeof(Tarefa))
                LerRegistrosDeTarefas(leitorTarefas, registros);
            else
                LerRegistrosDeContatos(leitorTarefas, registros);

            FechandoConexaoComBD(conexaoComBanco);
            return registros;
        }
        public bool ValidarVisualizacao()
        {
            return VisualizarTodosRegistros().Count == 0 ? false : true;
        }

        #region Metodos Privados
        private string Formatador(string valores)
        {
            List<string> palavras = new List<string>();
            palavras = valores.Split(',').ToList();
            string resultado = "";
            palavras.ForEach(x => resultado += "@" + x + ",");
            resultado = resultado.Replace("[", "");
            resultado = resultado.Replace("]", "");
            resultado = resultado.Remove(resultado.Length - 1);
            return resultado;
        }
        private void LerRegistrosDeContatos(SqlDataReader leitorTarefas, List<T> registros)
        {
            while (leitorTarefas.Read())
            {
                int id = Convert.ToInt32(leitorTarefas["ID"]);
                string nome = Convert.ToString(leitorTarefas["NOME"]);
                string email = Convert.ToString(leitorTarefas["EMAIL"]);
                string telefone = Convert.ToString(leitorTarefas["TELEFONE"]);
                string empresa = Convert.ToString(leitorTarefas["EMPRESA"]);
                string cargo = Convert.ToString(leitorTarefas["CARGO"]);

                T registro = (T)Activator.CreateInstance(typeof(T), nome, email, telefone, empresa, cargo);
                registro.Id = id;

                registros.Add(registro);
            }
        }
        private void LerRegistrosDeTarefas(SqlDataReader leitorTarefas, List<T> registros)
        {
            while (leitorTarefas.Read())
            {
                int id = Convert.ToInt32(leitorTarefas["ID"]);
                string titulo = Convert.ToString(leitorTarefas["TITULO"]);
                string prioridade = Convert.ToString(leitorTarefas["NIVELDEPRIORIDADE"]);
                DateTime dataCriacao = Convert.ToDateTime(leitorTarefas["DATADECRIACAO"]);
                DateTime dataConclusao = Convert.ToDateTime(leitorTarefas["DATACONCLUSAO"]);
                double percentual = Convert.ToDouble(leitorTarefas["PERCENTUALCONCLUIDO"]);

                T registro = (T)Activator.CreateInstance(typeof(T), prioridade, titulo, dataCriacao, dataConclusao, percentual);
                registro.Id = id;

                registros.Add(registro);
            }

        }
        private  void FechandoConexaoComBD(SqlConnection conexaoComBanco)
        {
            conexaoComBanco.Close();
        }
        private static SqlConnection AbrindoConexaoComBD()
        {
            string enderecoDBEmpresa =
                @"Data Source=(LocalDb)\MSSqlLocalDB;Initial Catalog=DBTarefas;Integrated Security=True;Pooling=False";

            SqlConnection conexaoComBanco = new SqlConnection();
            conexaoComBanco.ConnectionString = enderecoDBEmpresa;
            conexaoComBanco.Open();
            return conexaoComBanco;
        }
        #endregion

        #region Metodos abstract
        public abstract string Tabela { get;  }
        public abstract string Valores { get;  }
        public abstract string Atualizar { get; }
        public abstract void Inserir(SqlCommand comandoInsercao, T registro);
        public abstract void Editar(SqlCommand comandoEdicao, int id, T registro);
        #endregion
    }
}