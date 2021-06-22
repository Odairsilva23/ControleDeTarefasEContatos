using ControleDeTarefasEContatos.ConsoleApp.Controlador;
using ControleDeTarefasEContatos.ConsoleApp.Dominios;
using System;

namespace ControleDeTarefasEContatos.ConsoleApp.Telas
{
    public abstract class TelaBase<T> where T : EntidadeBase
    {
        private Controlador<T> controlador;
        public TelaBase(Controlador<T> controlador)
        {
            this.controlador = controlador;
        }
            
        public void Menu()
        {
            string opcao = "";
            while (opcao != "S")
            {
                Console.Clear();
                Console.WriteLine("Insira 1 para Inserir novo Registro");
                Console.WriteLine("Insira 2 para Visualizar Registros");
                Console.WriteLine("Insira 3 para Editar Registro");
                Console.WriteLine("Insira 4 para Excluir Registro");
                Console.WriteLine("Insira S para Sair");
                Console.Write("Opção: ");
                opcao = Console.ReadLine().ToUpper();

                switch (opcao)
                {
                    case "1": InserirRegistro(); continue;
                    case "2": VisualizarRegistro(); continue;
                    case "3": EditarRegistro(); continue;
                    case "4": ExcluirRegistro(); continue;
                    case "S": break;
                    default: MensagemErro(); continue;
                }
            }
        }
        public void ExcluirRegistro()
        {
           
            Console.Clear();

            if (!controlador.ValidarVisualizacao())
            {
                Console.WriteLine("Nenhum registro cadastrada por enquanto!");
                Console.ReadLine();
                return;
            }
            controlador.VisualizarTodosRegistros().ForEach(x => Console.WriteLine(x));

            Console.Write("\nInsira o ID do registro que deseja Excluir: ");
            int id = Convert.ToInt32(Console.ReadLine());

            controlador.ExcluirRegistro(id);
        }
        public void EditarRegistro()
        {
    
            Console.Clear();
            if (!controlador.ValidarVisualizacao())
            {
                Console.WriteLine("Nenhum registro cadastrado !");
                Console.ReadLine();
                return;
            }
            controlador.VisualizarTodosRegistros().ForEach(x => Console.WriteLine(x));
            Console.Write("\nInsira o ID do registro que deseja Editar: ");
            int id = Convert.ToInt32(Console.ReadLine());

            T registro = typeof(T) == typeof(Tarefa) ? ObterTarefaEditar() : ObterRegistro();

            controlador.EditarRegistro(registro, id);
        }
        public void InserirRegistro()
        {

            T registro = ObterRegistro();
            controlador.InserirRegistro(registro);
        }
        public void MensagemErro()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("\nOpção Inválida");
            Console.ResetColor();
            Console.ReadLine();
        }

        #region Metodos Virtuais
        public virtual T ObterTarefaEditar() { return (T)Activator.CreateInstance(typeof(T)); }
        public virtual void VisualizarRegistro()
        {
            Console.Clear();
            if (controlador.VisualizarTodosRegistros().Count == 0)
            {
                Console.WriteLine("Nenhum registro Cadastrado!");
                Console.ReadLine();
                return;
            }
            controlador.VisualizarTodosRegistros().ForEach(x => Console.WriteLine(x));
            Console.ReadLine();
        }
        #endregion

        #region Metodos Abastratos
        public abstract T ObterRegistro();
        public abstract string ConverterNumeroEmPalavrasPorExtenso(int numPrioridade);
        #endregion
    }

}
