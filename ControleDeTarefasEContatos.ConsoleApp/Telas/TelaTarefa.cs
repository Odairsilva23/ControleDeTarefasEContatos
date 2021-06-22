using ControleDeTarefasEContatos.ConsoleApp.Controlador;
using ControleDeTarefasEContatos.ConsoleApp.Dominios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleDeTarefasEContatos.ConsoleApp.Telas
{
    public class TelaTarefa : TelaBase<Tarefa>
    {
        private ControladorTarefa controlador;

        public TelaTarefa(Controlador<Tarefa> controlador) : base(controlador)
        {
            this.controlador = (ControladorTarefa)controlador;
            Menu();
        }

        #region Metodos Override
        public override string ConverterNumeroEmPalavrasPorExtenso(int numPrioridade)
        {
            switch (numPrioridade)
            {
                case 1: return "ALTA";
                case 2: return "MEDIA";
                case 3: return "BAIXA";
                default: return "";
            }
        }
        public override void VisualizarRegistro()
        {
            Console.Clear();
            Console.WriteLine("Insira 1 para Visualizar Tarefas Pendentes");
            Console.WriteLine("Insira 2 para Visualizar Tarefas Concluídas");
            switch (Console.ReadLine())
            {
                case "1": VisualizarTarefasPendentes(); break;
                case "2": VisualizarTarefasFinalizadas(); break;
                default: MensagemErro(); break;
            }
        }
        public override Tarefa ObterRegistro()
        {
            Console.Clear();
            Console.WriteLine("Inserindo Uma Nova Tarefa...");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("-------------------------------------------------------------------------------------------------------------------");
            Console.ResetColor();
           
            Console.Write("Insira o Título da Tarefa: ");
            string titulo = Console.ReadLine();
            Console.Write("Insira a Prioridade da Tarefa ( 1-ALTA | 2-MEDIA | 3-BAIXA ): ");
            int numPrioridade = Convert.ToInt32(Console.ReadLine());
            Console.Write("Insira a Data de Criação da Tarefa: ");
            DateTime dataCriacao = Convert.ToDateTime(Console.ReadLine());
            Console.Write("Insira a Data Prevista Para Conclusão da Tarefa: ");
            DateTime dataConclusao = Convert.ToDateTime(Console.ReadLine());
            Console.Write("Se a Tarefa Ja esta iniciada informe o Percentual de Conclusão  da Tarefa: ");
            double percentual = Convert.ToDouble(Console.ReadLine());

            Tarefa tarefa = new Tarefa(ConverterNumeroEmPalavrasPorExtenso(numPrioridade), titulo, dataCriacao, dataConclusao, percentual);

            return ValidarTarefa(tarefa);
        }
        public override Tarefa ObterTarefaEditar()
        {
            Console.Clear();
            Console.WriteLine("Editanto Uma Tarefa Tarefa...");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("-------------------------------------------------------------------------------------------------------------------");
            Console.ResetColor();

            Console.Write("Insira o Título da Tarefa: ");
            string titulo = Console.ReadLine();
            Console.Write("Insira a Prioridade da Tarefa ( 1-ALTA | 2-MEDIA | 3-BAIXA ): ");
            int numPrioridade = Convert.ToInt32(Console.ReadLine());
            DateTime dataCriacao = DateTime.Now;
            Console.Write("Insira a Data de Conclusão da Tarefa: ");
            DateTime dataConclusao = Convert.ToDateTime(Console.ReadLine());
            Console.Write("Insira o Percentual da Tarefa: ");
            double percentual = Convert.ToDouble(Console.ReadLine());

            Tarefa tarefa = new Tarefa(ConverterNumeroEmPalavrasPorExtenso(numPrioridade), titulo, dataCriacao, dataConclusao, percentual);

            return ValidarTarefa(tarefa);
        }
        #endregion

        #region Metodos Privados
        private Tarefa ValidarTarefa(Tarefa tarefa)
        {
            if (controlador.ValidarRegistros(tarefa))
                return tarefa;
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\nDados incorretos, tente novamente!");
                Console.ResetColor();
                Console.ReadLine();
                return ObterRegistro();
            }
        }
        private void VisualizarTarefasFinalizadas()
        {
            Console.Clear();
            if (controlador.VisualizarTarefasFinalizadas().Count == 0)
            {
                Console.WriteLine("Nenhuma tarefa finalizada por enquanto!");
                Console.ReadLine();
                return;
            }
            controlador.VisualizarTarefasFinalizadas().ForEach(x => Console.WriteLine(x));
            Console.ReadLine();
        }
        private void VisualizarTarefasPendentes()
        {
            Console.Clear();
            if (controlador.VisualizarTarefasPendentes().Count == 0)
            {
                Console.WriteLine("Nenhuma tarefa pendente por enquanto!");
                Console.ReadLine();
                return;
            }
            controlador.VisualizarTarefasPendentes().ForEach(x => Console.WriteLine(x));
            Console.ReadLine();
        }
        #endregion]
    }
}
