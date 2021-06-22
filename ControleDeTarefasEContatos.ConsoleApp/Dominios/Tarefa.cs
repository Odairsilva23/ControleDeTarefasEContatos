using System;


namespace ControleDeTarefasEContatos.ConsoleApp.Dominios
{
    public class Tarefa : EntidadeBase
    {
        public Tarefa(string prioridade, string titulo, DateTime dataCriacao, DateTime dataConclusao, double percentual)
        {
            this.Titulo = titulo;
            this.Prioridade = prioridade;
            this.DataCriacao = dataCriacao;
            this.DataConclusao = dataConclusao;
            this.Percentual = percentual;
        }

        public string Titulo { get; set; }
        public string Prioridade { get;  set; }
        public DateTime DataCriacao { get; set; }
        public DateTime DataConclusao { get;  set; }
        public double Percentual { get;  set; }
        public override string ToString()
        {
            return $"ID: {Id} \nNivel de Prioridade: {Prioridade} \nTítulo: {Titulo} \nData de Criação: {DataCriacao.ToString("d")}" +
                $" \nData de Conclusão: {DataConclusao.ToString("d")} \nPercentual de Conclusão: {Percentual}%" +
                $"\n------------------------------------------------------------------------------------------------------------------------";
        }
    }
}
