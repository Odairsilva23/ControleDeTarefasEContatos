using ControleDeTarefasEContatos.ConsoleApp.Dominios;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleDeTarefasEContatos.ConsoleApp.Controlador
{
     public class ControladorTarefa : Controlador<Tarefa>
    {
        public List<Tarefa> VisualizarTarefasPendentes()
        {
            return VisualizarTodosRegistros().FindAll(x => x.Percentual < 100).OrderBy(x => x.Prioridade == "BAIXA").ThenBy(x => x.Prioridade == "MEDIA").ThenBy(x => x.Prioridade == "ALTA").ToList();
        }
        public List<Tarefa> VisualizarTarefasFinalizadas()
        {
            return VisualizarTodosRegistros().FindAll(x => x.Percentual >= 100).OrderBy(x => x.Prioridade == "BAIXA").ThenBy(x => x.Prioridade == "MEDIA").ThenBy(x => x.Prioridade == "ALTA").ToList();
        }
        public bool ValidarRegistros(Tarefa tarefa)
        {
            if (string.IsNullOrEmpty(tarefa.Titulo))
                return false;
            if (tarefa.Percentual > 100 || tarefa.Percentual < 0)
                return false;
            if (tarefa.Prioridade != "ALTA" && tarefa.Prioridade != "MEDIA" && tarefa.Prioridade != "BAIXA")
                return false;
            if (tarefa.DataCriacao > tarefa.DataConclusao)
                return false;

            return true;
        }

        #region Metodos Override
        public override string Tabela => "TBTAREFAS";
        public override string Valores => "[TITULO],[NIVELDEPRIORIDADE],[DATADECRIACAO],[DATACONCLUSAO],[PERCENTUALCONCLUIDO]";
        public override string Atualizar => "[TITULO] = @TITULO,[NIVELDEPRIORIDADE] = @NIVELDEPRIORIDADE,[DATACONCLUSAO] = @DATACONCLUSAO,[PERCENTUALCONCLUIDO] = @PERCENTUALCONCLUIDO";
        public override void Inserir(SqlCommand comandoInsercao, Tarefa tarefa)
        {
            comandoInsercao.Parameters.AddWithValue("TITULO", tarefa.Titulo);
            comandoInsercao.Parameters.AddWithValue("NIVELDEPRIORIDADE", tarefa.Prioridade);
            comandoInsercao.Parameters.AddWithValue("DATADECRIACAO", tarefa.DataCriacao);
            comandoInsercao.Parameters.AddWithValue("DATACONCLUSAO", tarefa.DataConclusao);
            comandoInsercao.Parameters.AddWithValue("PERCENTUALCONCLUIDO", tarefa.Percentual);
        }
        public override void Editar(SqlCommand comandoEdicao, int id, Tarefa tarefa)
        {
            comandoEdicao.Parameters.AddWithValue("ID", id);
            comandoEdicao.Parameters.AddWithValue("TITULO", tarefa.Titulo);
            comandoEdicao.Parameters.AddWithValue("NIVELDEPRIORIDADE", tarefa.Prioridade);
            comandoEdicao.Parameters.AddWithValue("DATACONCLUSAO", tarefa.DataConclusao);
            comandoEdicao.Parameters.AddWithValue("PERCENTUALCONCLUIDO", tarefa.Percentual);
        }
        #endregion
    }
}
