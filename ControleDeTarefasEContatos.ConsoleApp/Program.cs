using ControleDeTarefasEContatos.ConsoleApp.Dominios;
using ControleDeTarefasEContatos.ConsoleApp.Telas;
using System;


namespace ControleDeTarefasEContatos.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(new Contato("Odair", "TioDaia@gmail.com", "998151515", "ndd", "Stagiario"));
            Console.ReadLine();
            new TelaPrincipal();
        }
    }
}
