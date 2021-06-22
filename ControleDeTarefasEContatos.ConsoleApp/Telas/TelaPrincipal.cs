using ControleDeTarefasEContatos.ConsoleApp.Controlador;
using ControleDeTarefasEContatos.ConsoleApp.Dominios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleDeTarefasEContatos.ConsoleApp.Telas
{
    public class TelaPrincipal
    {
        private ControladorTarefa controladorTarefa = new ControladorTarefa();
        private ControladorContato controladorContato = new ControladorContato();

        public TelaPrincipal()
        {
           
            Menu();
        }

        public void Menu()
        {
            string opcao = "";
            while (opcao != "S")
            {
                Console.Clear();
                Console.WriteLine("Controle de Contatos e Tarefas\n");
                Console.WriteLine("Insira 1 para Tarefas");
                Console.WriteLine("Insira 2 para Contatos");
                Console.WriteLine("Insira S para Sair");
                Console.Write("Opção: ");
                opcao = Console.ReadLine().ToUpper();

                switch (opcao)
                {
                    case "1": new TelaTarefa(controladorTarefa); continue;
                    case "2": new TelaContato(controladorContato); continue;
                    case "S": break;
                    default:; continue;
                }
            }
        }
    }
}
