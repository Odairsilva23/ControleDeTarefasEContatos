using ControleDeTarefasEContatos.ConsoleApp.Controlador;
using ControleDeTarefasEContatos.ConsoleApp.Dominios;
using System;

namespace ControleDeTarefasEContatos.ConsoleApp.Telas
{
    public class TelaContato : TelaBase<Contato>
    {
        private  ControladorContato controlador;
        public TelaContato(Controlador<Contato> controlador) : base(controlador)
        {
            this.controlador = (ControladorContato)controlador;
            Menu();
        }

        #region Metodos Override
        public override Contato ObterRegistro()
        {
            Console.Clear();
            Console.WriteLine("Inserindo Um Novo Contato...");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("-------------------------------------------------------------------------------------------------------------------");
            Console.ResetColor();

            Console.Write("Insira o Nome do Contato: ");
            string nome = Console.ReadLine();
            Console.Write("Insira o E-mail do Contato: ");
            string email = Console.ReadLine();
            Console.Write("Insira o Telefone do Contato: ");
            string telefone = Console.ReadLine();
            Console.Write("Insira a Empresa do Contato: ");
            string empresa = Console.ReadLine();
            Console.Write("Insira O Cargo  ( 1-ARQUITETO | 2-DESENVOLVEDOR | 3-TESTER | 4- ESTAGIARIO|" +
                "5- GERENTE | 6- DIRETOR| 7-RH | 8- MARKT | 9- FINANCEIRO | 10- VENDAS) ");
            int ncargo =Convert.ToInt32(Console.ReadLine());

            Contato contato = new Contato(nome, email, telefone, empresa,ConverterNumeroEmPalavrasPorExtenso(ncargo));

            return ValidarContato(contato);
        }
        public override string ConverterNumeroEmPalavrasPorExtenso(int nCargo)
        {
            switch (nCargo)
            {
                case 1: return "ARQUITETO";
                case 2: return "DESENVOLVEDOR";
                case 3: return "TESTER";
                case 4: return "ESTAGIARIO";
                case 5: return "GERENTE";
                case 6: return "DIRETOR";
                case 7: return "RH";
                case 8: return "MARKTING";
                case 9: return "FINANCEIRO";
                case 10: return "VENDAS";
                default: return "";
            }
        }
        public override void VisualizarRegistro()
        {
            Console.Clear();
            Console.WriteLine("\nInsira 1 para Visualizar seus Contatos Salvos");
            Console.ForegroundColor = ConsoleColor.DarkRed;
            switch (Console.ReadLine())
            {   
                case "1": VisualizarContatosqeEstaoSalvos(); break;              
                default: MensagemErro(); break;
            }
            Console.ResetColor();
        }
        #endregion

        #region Metodos Privados
        private void VisualizarContatosqeEstaoSalvos()
        {
            Console.Clear();
            if (controlador.VisualizarContatosSalvos().Count == 0)
            {
                Console.WriteLine("Nenhuma tarefa pendente por enquanto!");
                Console.ReadLine();
                return;
            }
            controlador.VisualizarContatosSalvos().ForEach(x => Console.WriteLine(x));
            Console.ReadLine();
        }

        private Contato ValidarContato(Contato contato)
        {
            if (controlador.ValidarRegistros(contato))
                return contato;
           
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\nDados incorretos, tente novamente!");
                Console.ResetColor();
                Console.ReadLine();
                return ObterRegistro();
            }
        }
        #endregion
    }
}